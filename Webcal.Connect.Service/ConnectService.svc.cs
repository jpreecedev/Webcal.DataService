namespace Webcal.Connect.Service
{
    using Data;
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
            using (var context = new ConnectContext())
            {
                tachographDocument.User = User;
                context.TachographDocuments.Add(tachographDocument);

                context.SaveChanges();
            }
        }
    }
}