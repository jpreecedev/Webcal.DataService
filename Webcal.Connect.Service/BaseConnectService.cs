namespace Webcal.Connect.Service
{
    using System.Collections.Generic;
    using System.IdentityModel.Claims;
    using System.Linq;
    using System.ServiceModel;
    using Shared;

    public class BaseConnectService
    {
        public ConnectUser User
        {
            get { return new ConnectUser(GetConnectKeys()); }
        }

        protected IConnectKeys GetConnectKeys()
        {
            int licenseKey = int.Parse(FetchClaimValue(ConnectConstants.ConnectLicenseKeyClaim));
            string companyKey = FetchClaimValue(ConnectConstants.ConnectCompanyKeyClaim);
            string machineKey = FetchClaimValue(ConnectConstants.ConnectMachineKeyClaim);

            return new ConnectKeys(string.Empty, licenseKey, companyKey, machineKey);
        }

        private string FetchClaimValue(string claimType)
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
    }
}