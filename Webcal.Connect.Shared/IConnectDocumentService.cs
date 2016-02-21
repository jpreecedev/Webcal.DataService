namespace Connect.Shared
{
    using System.ServiceModel;
    using Models;

    public partial interface IConnectService
    {
        [OperationContract]
        void AutoUploadTachographDocument(TachographDocument tachographDocument);

        [OperationContract]
        void AutoUploadUndownloadabilityDocument(UndownloadabilityDocument undownloadabilityDocument);

        [OperationContract]
        void AutoUploadLetterForDecommissioningDocument(LetterForDecommissioningDocument letterForDecommissioningDocument);

        [OperationContract]
        void UploadTachographDocument(TachographDocument tachographDocument);

        [OperationContract]
        void UploadUndownloadabilityDocument(UndownloadabilityDocument undownloadabilityDocument);

        [OperationContract]
        void UploadLetterForDecommissioningDocument(LetterForDecommissioningDocument letterForDecommissioningDocument);

        [OperationContract]
        object Find(string registrationNumber, DocumentType documentType);
    }
}
