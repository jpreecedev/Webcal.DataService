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
            UploadDocument(tachographDocument);
        }

        public void UploadUndownloadabilityDocument(UndownloadabilityDocument undownloadabilityDocument)
        {
            UploadDocument(undownloadabilityDocument);
        }

        public void UploadLetterForDecommissioningDocument(LetterForDecommissioningDocument letterForDecommissioningDocument)
        {
            UploadDocument(letterForDecommissioningDocument);
        }

        private void UploadDocument<T>(T document) where T : Document
        {
            using (var context = new ConnectContext())
            {
                document.User = User;
                context.Set<T>().Add(document);

                context.SaveChanges();
            }
        }
    }
}