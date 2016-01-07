namespace Connect.Service
{
    using System.Collections.Generic;
    using System.IdentityModel.Claims;
    using System.Linq;
    using System.ServiceModel;
    using Shared;
    using Shared.Models;
    using System.Data.Entity;

    public class BaseConnectService
    {
        public ConnectUserNode GetUserNode()
        {
            using (var context = new ConnectContext())
            {
                return GetUserNode(context);
            }
        }

        public ConnectUserNode GetUserNode(ConnectContext context)
        {
            var connectKeys = GetConnectKeys();
            var connectUser = context.UserNodes.Include(x => x.ConnectUser).FirstOrDefault(c => c.CompanyKey == connectKeys.CompanyKey && c.MachineKey == connectKeys.MachineKey);
            return connectUser ?? new ConnectUserNode(connectKeys);
        }

        public int GetUserId()
        {
            using (var context = new ConnectContext())
            {
                return GetUserId(context);
            }
        }

        public int GetUserId(ConnectContext context)
        {
            var connectKeys = GetConnectKeys();

            var connectUser = context.UserNodes.Include(x=>x.ConnectUser).Select(c => new
            {
                c.ConnectUser.Id,
                c.CompanyKey,
                c.MachineKey,
                c.DepotName
            })
            .FirstOrDefault(c => c.CompanyKey == connectKeys.CompanyKey && c.MachineKey == connectKeys.MachineKey);

            if (connectUser != null)
            {
                return connectUser.Id;
            }

            return -1;
        }

        protected IConnectKeys GetConnectKeys()
        {
            int licenseKey = int.Parse(FetchClaimValue(ConnectConstants.ConnectLicenseKeyClaim));
            string companyKey = FetchClaimValue(ConnectConstants.ConnectCompanyKeyClaim);
            string machineKey = FetchClaimValue(ConnectConstants.ConnectMachineKeyClaim);
            string depotKey = FetchClaimValue(ConnectConstants.ConnectDepotKeyClaim);

            return new ConnectKeys(string.Empty, licenseKey, companyKey, machineKey, depotKey);
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