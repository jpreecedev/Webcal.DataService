namespace Webcal.Connect.Service
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IdentityModel.Claims;
    using System.IdentityModel.Policy;
    using System.IdentityModel.Selectors;
    using System.IdentityModel.Tokens;
    using System.Linq;
    using System.ServiceModel;
    using Shared;
    using Data;

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
            using (var context = new ConnectContext())
            {
                var company = context.Companies.FirstOrDefault(c => c.Key == connectKeys.CompanyKey);

                bool companyKeyExists = company != null;
                if (!companyKeyExists)
                {
                    return new FaultException("Connect authentication keys are invalid.");                    
                }

                bool companyAuthorized = company.IsAuthorized;
                if (!companyAuthorized)
                {
                    return new FaultException("The company is not authorized to use Webcal Connect at this time.");                                        
                }

                var node = context.Nodes.FirstOrDefault(c => c.Company.Id == company.Id && c.MachineKey == connectKeys.MachineKey);
                if (node == null || !node.IsAuthorized)
                {
                    return new FaultException("Your computer is not currently authorized to use Webcal Connect at this time.");
                }
            }
            return null;
        }

        private static ConnectTokenAuthorizationPolicy CreateAuthorizationPolicy<T>(string claimType, T resource, string rights)
        {
            return new ConnectTokenAuthorizationPolicy(new DefaultClaimSet(new Claim(claimType, resource, rights)));
        }
    }
}