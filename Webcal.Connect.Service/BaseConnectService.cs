namespace Connect.Service
{
    using System.Data.Entity;
    using System.IdentityModel.Claims;
    using System.Linq;
    using System.ServiceModel;
    using Shared;
    using Shared.Models;

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
                var connectKeys = GetConnectKeys();
                return GetUserId(context, connectKeys.CompanyKey, connectKeys.MachineKey);
            }
        }

        protected IConnectKeys GetConnectKeys()
        {
            var licenseKey = int.Parse(FetchClaimValue(ConnectConstants.ConnectLicenseKeyClaim));
            var companyKey = FetchClaimValue(ConnectConstants.ConnectCompanyKeyClaim);
            var machineKey = FetchClaimValue(ConnectConstants.ConnectMachineKeyClaim);
            var depotKey = FetchClaimValue(ConnectConstants.ConnectDepotKeyClaim);

            return new ConnectKeys(string.Empty, licenseKey, companyKey, machineKey, depotKey);
        }

        protected string FetchClaimValue(string claimType)
        {
            foreach (var claimSet in ServiceSecurityContext.Current.AuthorizationContext.ClaimSets)
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
            var matchingClaims = claimSet.FindClaims(claimType, Rights.PossessProperty).ToList();
            if (!matchingClaims.Any())
                return false;

            var enumerator = matchingClaims.GetEnumerator();
            enumerator.MoveNext();
            claimValue = (enumerator.Current.Resource == null) ? null : enumerator.Current.Resource.ToString();

            return true;
        }

        private static int GetUserId(IConnectContext context, string companyKey, string machineKey)
        {
            var connectUser = context.UserNodes.Include(x => x.ConnectUser).Select(c => new
            {
                c.ConnectUser.Id,
                c.CompanyKey,
                c.MachineKey,
                c.DepotName
            })
                .FirstOrDefault(c => c.CompanyKey == companyKey && c.MachineKey == machineKey);

            if (connectUser != null)
            {
                return connectUser.Id;
            }

            return -1;
        }
    }
}