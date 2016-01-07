using System.Data.Entity;
using Connect.Shared.Models;

namespace Connect.Service
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity.Migrations;
    using System.IdentityModel.Claims;
    using System.IdentityModel.Policy;
    using System.IdentityModel.Selectors;
    using System.IdentityModel.Tokens;
    using System.Linq;
    using System.ServiceModel;
    using Shared;
    using Claim = System.IdentityModel.Claims.Claim;

    public class ConnectTokenAuthenticator : SecurityTokenAuthenticator
    {
        protected override bool CanValidateTokenCore(SecurityToken token)
        {
            return (token is ConnectToken);
        }

        protected override ReadOnlyCollection<IAuthorizationPolicy> ValidateTokenCore(SecurityToken token)
        {
            var connectToken = token as ConnectToken;

            if (connectToken == null)
            {
                throw new ArgumentNullException("token");
            }

            var authorizationException = IsAuthorized(connectToken.ConnectKeys);
            if (authorizationException != null)
            {
                throw authorizationException;
            }

            var policies = new List<IAuthorizationPolicy>(3)
            {
                CreateAuthorizationPolicy(ConnectConstants.ConnectLicenseKeyClaim, connectToken.ConnectKeys.LicenseKey, Rights.PossessProperty),
                CreateAuthorizationPolicy(ConnectConstants.ConnectMachineKeyClaim, connectToken.ConnectKeys.MachineKey, Rights.PossessProperty),
                CreateAuthorizationPolicy(ConnectConstants.ConnectCompanyKeyClaim, connectToken.ConnectKeys.CompanyKey, Rights.PossessProperty),
            };

            return policies.AsReadOnly();
        }

        private static Exception IsAuthorized(IConnectKeys connectKeys)
        {
            Exception result = null;

            if (!LicenseManager.IsValid(connectKeys.LicenseKey.ToString()))
            {
                result = new FaultException("The license key is invalid or has expired.");
            }

            if (result == null)
            {
                using (var context = new ConnectContext())
                {
                    var company = context.Users.FirstOrDefault(c => c.CompanyKey == connectKeys.CompanyKey);
                    if (company == null)
                    {
                        result = new FaultException("Your computer is not currently authorized to use Connect at this time.");
                    }

                    if (result == null)
                    {
                        var connectUserNode = context.UserNodes.FirstOrDefault(c => c.MachineKey == connectKeys.MachineKey && c.CompanyKey == connectKeys.CompanyKey);
                        if (connectUserNode == null)
                        {
                            var connectUser = context.Users.FirstOrDefault(c => c.CompanyKey == connectKeys.CompanyKey);
                            if (connectUser == null)
                            {
                                result = new FaultException("Your computer is not currently authorized to use Connect at this time.");
                                return result;
                            }

                            context.UserNodes.Add(new ConnectUserNode(connectKeys) {IsAuthorized = true, ConnectUser = connectUser});
                            context.SaveChanges();
                            return null;
                        }
                        if (!connectUserNode.IsAuthorized)
                        {
                            result = new FaultException("Your computer is not currently authorized to use Connect at this time.");
                        }
                    }
                }
            }

            return result;
        }

        private static ConnectTokenAuthorizationPolicy CreateAuthorizationPolicy<T>(string claimType, T resource, string rights)
        {
            return new ConnectTokenAuthorizationPolicy(new DefaultClaimSet(new Claim(claimType, resource, rights)));
        }

        private static void AddUnauthorizedUser(ConnectContext context, IConnectKeys connectKeys)
        {
            var unauthorizedUser = context.UnauthorizedUsers.FirstOrDefault(c => c.CompanyKey == connectKeys.CompanyKey &&
                                                                                 c.LicenseKey == connectKeys.LicenseKey &&
                                                                                 c.MachineKey == connectKeys.MachineKey);

            if (unauthorizedUser == null)
            {
                unauthorizedUser = new UserPendingAuthorization(connectKeys);
            }

            unauthorizedUser.LastAttempt = DateTime.Now;

            context.UnauthorizedUsers.AddOrUpdate(unauthorizedUser);
            context.SaveChanges();
        }
    }
}