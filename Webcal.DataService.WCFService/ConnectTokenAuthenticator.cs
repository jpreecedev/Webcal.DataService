namespace Webcal.DataService.WCFService
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IdentityModel.Claims;
    using System.IdentityModel.Policy;
    using System.IdentityModel.Selectors;
    using System.IdentityModel.Tokens;
    using System.Linq;
    using Data;
    using Shared;

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
            if (!IsValidConnectKeys(connectToken.ConnectKeys))
            {
                throw new SecurityTokenValidationException("Connect authentication keys are invalid.");
            }

            var policies = new List<IAuthorizationPolicy>(3)
            {
                CreateAuthorizationPolicy(Constants.ConnectLicenseKeyClaim, connectToken.ConnectKeys.LicenseKey, Rights.PossessProperty),
                CreateAuthorizationPolicy(Constants.ConnectCompanyKeyClaim, connectToken.ConnectKeys.CompanyKey, Rights.PossessProperty),
                CreateAuthorizationPolicy(Constants.ConnectMachineKeyClaim, connectToken.ConnectKeys.MachineKey, Rights.PossessProperty),
            };

            return policies.AsReadOnly();
        }

        private static bool IsValidConnectKeys(ConnectKeys connectKeys)
        {
            using (var context = new ConnectContext())
            {
                return context.Companies.FirstOrDefault(c => c.Key == connectKeys.CompanyKey) != null;
            }
        }

        private static ConnectTokenAuthorizationPolicy CreateAuthorizationPolicy<T>(string claimType, T resource, string rights)
        {
            return new ConnectTokenAuthorizationPolicy(new DefaultClaimSet(new Claim(claimType, resource, rights)));
        }
    }
}