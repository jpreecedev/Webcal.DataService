namespace Webcal.Connect.Data
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Shared;
    using Shared.Models;

    public class ConnectUser : BaseUserModel
    {
        private Company _company;

        public ConnectUser()
        {
        }

        public ConnectUser(IConnectKeys connectKeys)
        {
            LicenseKey = connectKeys.LicenseKey;
            CompanyKey = connectKeys.CompanyKey;
            MachineKey = connectKeys.MachineKey;
        }

        public bool IsAuthorized { get; set; }

        public int LicenseKey { get; set; }

        public string CompanyKey { get; set; }

        public string MachineKey { get; set; }

        public Company Company
        {
            get { return _company ?? (_company = Fetch<Company>(c => c.Key == CompanyKey)); }
        }
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ConnectUser, int> manager)
        {
            return await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        }

        private static TResult Fetch<TResult>(Expression<Func<TResult, bool>> expression) where TResult : class
        {
            using (var context = new ConnectContext())
            {
                return context.Set<TResult>().FirstOrDefault(expression);
            }
        }
    }
}