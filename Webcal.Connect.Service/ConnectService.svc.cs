namespace Webcal.Connect.Service
{
    using Shared;
    using Shared.Models;

    public class ConnectService : BaseConnectService, IConnectService
    {
        public string Echo()
        {
            return "Echo";
        }

        public void UploadTachographDocument(TachographDocument tachographDocument)
        {
            throw new System.NotImplementedException();
        }
    }
}