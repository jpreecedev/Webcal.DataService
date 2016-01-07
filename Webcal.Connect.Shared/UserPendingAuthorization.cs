namespace Connect.Shared
{
    using System;
    using Models;

    public class UserPendingAuthorization : BaseModel
    {
        public UserPendingAuthorization()
        {
            
        }

        public UserPendingAuthorization(IConnectKeys connectKeys)
        {
            LicenseKey = connectKeys.LicenseKey;
            CompanyKey = connectKeys.CompanyKey;
            MachineKey = connectKeys.MachineKey;
            DepotKey = connectKeys.DepotName;
        }
        
        public int LicenseKey { get; set; }

        public string CompanyKey { get; set; }

        public string MachineKey { get; set; }

        public string DepotKey { get; set; }

        public DateTime LastAttempt { get; set; }

        public string ConnectKey
        {
            get { return string.Format("{0}-{1}-{2}-{3}", CompanyKey, MachineKey, LicenseKey, DepotKey); }
        }
    }
}