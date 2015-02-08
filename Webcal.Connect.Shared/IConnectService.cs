namespace Webcal.Connect.Shared
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
    }
}