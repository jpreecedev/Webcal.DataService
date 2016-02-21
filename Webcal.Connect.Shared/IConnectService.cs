namespace Connect.Shared
{
    using System.ServiceModel;
    using Models;

    [ServiceContract]
    [XmlSerializerFormat]
    public partial interface IConnectService
    {
        [OperationContract]
        string Echo();

        [OperationContract]
        void UploadCustomerContact(CustomerContact customerContact);

        [OperationContract]
        CustomerContact[] FindExistingCustomerContact(string customerName);

        [OperationContract]
        ServiceCredentials GetServiceCredentials();
    }
}