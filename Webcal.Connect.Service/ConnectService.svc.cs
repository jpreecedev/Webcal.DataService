namespace Webcal.Connect.Service
{
    using Shared;

    public class ConnectService : BaseConnectService, IConnectService
    {
        public string Echo()
        {
            return "Echo";
        }

        public void UploadTachographDocument()
        {
            throw new System.NotImplementedException();
        }
    }
}