namespace Webcal.Connect.Service
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
                CreateAuthorizationPolicy(ConnectConstants.ConnectCompanyKeyClaim, connectToken.ConnectKeys.CompanyKey, Rights.PossessProperty),
                CreateAuthorizationPolicy(ConnectConstants.ConnectMachineKeyClaim, connectToken.ConnectKeys.MachineKey, Rights.PossessProperty),
            };

            return policies.AsReadOnly();
        }

        private static Exception IsAuthorized(IConnectKeys connectKeys)
        {
            Exception result = null;

            using (var context = new ConnectContext())
            {
                var connectUserNode = context.UserNodes.Where(u => u.CompanyKey == connectKeys.CompanyKey).FirstOrDefault(c => c.MachineKey == connectKeys.MachineKey);
                if (connectUserNode == null || !connectUserNode.IsAuthorized)
                {
                    result = new FaultException("Your computer is not currently authorized to use Webcal Connect at this time.");
                }

                if (result != null && connectUserNode == null)
                {
                    AddUnauthorizedUser(context, connectKeys);
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