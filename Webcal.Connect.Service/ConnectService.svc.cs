namespace Webcal.Connect.Service
{
    using System;
    using Connect.Shared;

    public class ConnectService : BaseConnectService, IConnectService
    {
        public string Echo()
        {
            return String.Format("Hello. You presented a {0}", FetchClaimValue(ConnectConstants.ConnectLicenseKeyClaim));
        }
    }
}