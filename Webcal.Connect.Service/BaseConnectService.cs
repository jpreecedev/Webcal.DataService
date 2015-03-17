namespace Webcal.Connect.Service
{
    using System.Collections.Generic;
    using System.IdentityModel.Claims;
    using System.Linq;
    using System.ServiceModel;
    using Shared;
    using Shared.Models;

    public class BaseConnectService
    {
        public ConnectUserNode UserNode
        {
            get
            {
                var connectKeys = GetConnectKeys();

                using (var context = new ConnectContext())
                {
                    var connectUser = context.UserNodes.Include("ConnectUser").FirstOrDefault(c => c.CompanyKey == connectKeys.CompanyKey && c.MachineKey == connectKeys.MachineKey);
                    return connectUser ?? new ConnectUserNode(connectKeys);
                }
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

        private static bool TryGetStringClaimValue(ClaimSet claimSet, string claimType, out string claimValue)
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
    }
}