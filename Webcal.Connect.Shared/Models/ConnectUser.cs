namespace Connect.Shared.Models
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Claim = System.Security.Claims.Claim;

    public class ConnectUser : BaseUserModel
    {
        public bool IsAuthorized { get; set; }
        
        public TachoCentreOperator TachoCentre { get; set; }
		
		public string CompanyKey { get; set; }

        public int LicenseKey { get; set; }

        public CustomerContact CustomerContact { get; set; }
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ConnectUser, int> manager)
        {
            var identity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            var additionalRoles = ConnectRoles.GetHigherRoles(identity.FindFirstValue(ClaimsIdentity.DefaultRoleClaimType));

            if (additionalRoles != null && additionalRoles.Length > 0)
            {
                foreach (var additionalRole in additionalRoles)
                {
                    identity.AddClaim(new Claim(ClaimsIdentity.DefaultRoleClaimType, additionalRole, ClaimValueTypes.String));
                }
            }

            return identity;
        }
    }
}