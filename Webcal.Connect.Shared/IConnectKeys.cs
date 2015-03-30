namespace Connect.Shared
{
    public interface IConnectKeys
    {
        string Url { get; set; }

        int LicenseKey { get; set; }
        string CompanyKey { get; set; }
        string MachineKey { get; set; }

        string ConnectKey { get; }
    }
}