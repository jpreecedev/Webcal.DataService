namespace Webcal.Connect.Shared
{
    using System.ServiceModel;

    [ServiceContract]
    [XmlSerializerFormat]
    public interface IConnectService
    {
        [OperationContract]
        string Echo();

        [OperationContract]
        void UploadTachographDocument();
    }
}