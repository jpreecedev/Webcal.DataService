namespace Connect.Shared
{
    using System.ServiceModel;
    using Models;

    [ServiceContract]
    [XmlSerializerFormat]
    public interface IConnectService
    {
        [OperationContract]
        string Echo();

        [OperationContract]
        void UploadTachographDocument(TachographDocument tachographDocument);

        [OperationContract]
        void UploadUndownloadabilityDocument(UndownloadabilityDocument undownloadabilityDocument);

        [OperationContract]
        void UploadLetterForDecommissioningDocument(LetterForDecommissioningDocument letterForDecommissioningDocument);

        [OperationContract]
        object Find(string registrationNumber, DocumentType documentType);

        [OperationContract]
        void UploadCustomerContact(CustomerContact customerContact);

        [OperationContract]
        CustomerContact[] FindExistingCustomerContact(string customerName);
    }
}