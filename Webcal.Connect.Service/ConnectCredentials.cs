namespace Connect.Service
{
    public class ConnectCredentials
    {
#if DEBUG

        public const string BaseUrl = "http://webcal-connect.local/";
        public const string ConnectionString = "Server=.;Database=WebcalConnect;User Id=webcal; Password=P@ssword123;";
        public static byte[] DefaultCertificate = Properties.Resources.Local_Certificate;
        public const string CertificatePassword = "";
#else
        public const string BaseUrl = "http://www.webcalconnect.com/service/";
        public const string ConnectionString = "Server=10.168.1.53;Database=webcaldb;User Id=webcaldb; Password=7ZY7K8De;";
        public static byte[] DefaultCertificate = Properties.Resources.Live_Certificate;
        public const string CertificatePassword = "abc123";
#endif
    }
}