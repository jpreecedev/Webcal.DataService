namespace Webcal.Connect.Service
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Claims;
    using System.Linq;
    using System.Linq.Expressions;
    using System.ServiceModel;
    using Data;
    using Shared;

    public class BaseConnectService
    {
        public ConnectUser User
        {
            get
            {
                var connectKeys = GetConnectKeys();
                var connectUser = Fetch<ConnectUser>(c => c.CompanyKey == connectKeys.CompanyKey && c.MachineKey == connectKeys.MachineKey);

                return connectUser ?? new ConnectUser(connectKeys);
            }
        }

        protected IConnectKeys GetConnectKeys()
        {
            int licenseKey = int.Parse(FetchClaimValue(ConnectConstants.ConnectLicenseKeyClaim));
            string companyKey = FetchClaimValue(ConnectConstants.ConnectCompanyKeyClaim);
            string machineKey = FetchClaimValue(ConnectConstants.ConnectMachineKeyClaim);

            return new ConnectKeys(string.Empty, licenseKey, companyKey, machineKey);
        }
        
        protected string FetchClaimValue(string claimType)
        {
            foreach (ClaimSet claimSet in ServiceSecurityContext.Current.AuthorizationContext.ClaimSets)
            {
                string result;
                if (TryGetStringClaimValue(claimSet, claimType, out result))
                {
                    return result;
                }
            }
            return "Unknown";
        }

        private bool TryGetStringClaimValue(ClaimSet claimSet, string claimType, out string claimValue)
        {
            claimValue = null;
            IEnumerable<Claim> matchingClaims = claimSet.FindClaims(claimType, Rights.PossessProperty);
            if (matchingClaims == null || !matchingClaims.Any())
                return false;

            IEnumerator<Claim> enumerator = matchingClaims.GetEnumerator();
            enumerator.MoveNext();
            claimValue = (enumerator.Current.Resource == null) ? null : enumerator.Current.Resource.ToString();

            return true;
        }

        private static T Fetch<T>(Expression<Func<T, bool>> expression) where T : class
        {
            using (var context = new ConnectContext())
            {
                return context.Set<T>().FirstOrDefault(expression.Compile());
            }
        }
    }
}