namespace Connect.Shared
{
    using Properties;

    public class ConnectConstants
    {
        //public const string BaseUrl = "https://webcal-connect.local/";
        //public const string ConnectionString = "Server=.;Database=WebcalConnect;User Id=webcal; Password=password;";
        //public static byte[] DefaultCertificate = Resources.Local_Certificate;

        //public const string BaseUrl = "https://www.webcalconnect.com/service/";
        //public const string ConnectionString = "Server=10.168.1.53;Database=webcaldb;User Id=webcaldb; Password=7ZY7K8De;";
        //public static byte[] DefaultCertificate = Resources.Live_Certificate;

        public const string ConnectNamespace = "https://connect/";

        public const string ConnectLicenseKeyClaim = ConnectNamespace + "Claims/LicenseKey";
        public const string ConnectMachineKeyClaim = ConnectNamespace + "Claims/MachineKey";
        public const string ConnectCompanyKeyClaim = ConnectNamespace + "Claims/CompanyKey";
        public const string ConnectTokenType = ConnectNamespace + "Tokens/ConnectToken";

        public const string ConnectTokenPrefix = "ct";
        public const string ConnectUrlPrefix = "url";
        public const string ConnectTokenName = "ConnectToken";
        public const string Id = "Id";
        public const string WsUtilityPrefix = "wsu";
        public const string WsUtilityNamespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd";

        public const string ConnectLicenseKeyElementName = "LicenseKey";
        public const string ConnectMachineKeyElementName = "MachineKey";
        public const string ConnectCompanyKeyElementName = "CompanyKey";

        public const string ConnectAdministratonCompany = "Administration";
    }
}