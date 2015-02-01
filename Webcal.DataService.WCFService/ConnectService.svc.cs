namespace Webcal.DataService.WCFService
{
    using System;
    using Shared;

    public class ConnectService : BaseConnectService, IConnectService
    {
        public string Echo()
        {
            return String.Format("Hello. You presented a {0}", FetchClaimValue(Constants.ConnectLicenseKeyClaim));
        }
    }
}