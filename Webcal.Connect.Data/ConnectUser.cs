namespace Webcal.Connect.Data
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Shared;
    using Shared.Models;

    public class ConnectUser : BaseModel
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

        private static TResult Fetch<TResult>(Expression<Func<TResult, bool>> expression) where TResult : class
        {
            using (var context = new ConnectContext())
            {
                return context.Set<TResult>().FirstOrDefault(expression);
            }
        }
    }
}