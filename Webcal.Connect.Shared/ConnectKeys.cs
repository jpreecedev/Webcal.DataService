namespace Connect.Shared
{
    using System;

    [Serializable]
    public class ConnectKeys : IConnectKeys
    {
        public ConnectKeys(string url, int licenseKey, string companyKey, string machineKey, string depotName)
        {
            Url = url;
            LicenseKey = licenseKey;
            CompanyKey = companyKey;
            MachineKey = machineKey;
            DepotName = depotName;
        }

        public string Url { get; set; }
        public int LicenseKey { get; set; }
        public string CompanyKey { get; set; }
        public string MachineKey { get; set; }
        public string DepotName { get; set; }

        public string ConnectKey
        {
            get { return string.Format("{0}-{1}-{2}-{3}", CompanyKey, MachineKey, LicenseKey, DepotName ); }
        }
    }
}