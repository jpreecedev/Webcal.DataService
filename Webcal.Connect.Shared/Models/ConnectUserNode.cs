namespace Webcal.Connect.Shared.Models
{
    using Shared;

    public class ConnectUserNode : BaseModel
    {
        public ConnectUserNode()
        {
        }

        public ConnectUserNode(IConnectKeys connectKeys)
        {
            LicenseKey = connectKeys.LicenseKey;
            CompanyKey = connectKeys.CompanyKey;
            MachineKey = connectKeys.MachineKey;
        }
        
        public ConnectUser ConnectUser { get; set; }
        
        public bool IsAuthorized { get; set; }

        public int LicenseKey { get; set; }

        public string CompanyKey { get; set; }

        public string MachineKey { get; set; }

        public void Parse(string connectKey)
        {
            if (string.IsNullOrEmpty(connectKey))
            {
                return;
            }

            var split = connectKey.Split('-');
            if (split.Length != 3)
            {
                return;
            }

            CompanyKey = split[0];
            MachineKey = split[1];

            int parsed;
            if (int.TryParse(split[2], out parsed))
            {
                LicenseKey = parsed;
            }
        }
    }
}