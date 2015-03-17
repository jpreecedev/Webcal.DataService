namespace Webcal.Connect.Shared
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
        }
        
        public int LicenseKey { get; set; }

        public string CompanyKey { get; set; }

        public string MachineKey { get; set; }

        public DateTime LastAttempt { get; set; }

        public string ConnectKey
        {
            get { return string.Format("{0}-{1}-{2}", CompanyKey, MachineKey, LicenseKey); }
        }
    }
}