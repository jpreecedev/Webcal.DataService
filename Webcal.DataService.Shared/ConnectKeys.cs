namespace Webcal.DataService.Shared
{
    using System;

    [Serializable]
    public class ConnectKeys
    {
        public ConnectKeys(int licenseKey, string companyKey, string machineKey)
        {
            LicenseKey = licenseKey;
            CompanyKey = companyKey;
            MachineKey = machineKey;
        }

        public int LicenseKey { get; set; }
        public string CompanyKey { get; set; }
        public string MachineKey { get; set; }
    }
}