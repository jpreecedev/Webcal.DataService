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
        void UpdateTachographDocument(TachographDocument tachographDocument);

        [OperationContract]
        void UpdateUndownloadabilityDocument(UndownloadabilityDocument undownloadabilityDocument);

        [OperationContract]
        void UpdateLetterForDecommissioningDocument(LetterForDecommissioningDocument letterForDecommissioningDocument);
        
        [OperationContract]
        object Find(string registrationNumber, DocumentType documentType);
    }
}
