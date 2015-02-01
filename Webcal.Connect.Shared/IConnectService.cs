namespace Webcal.Connect.Shared
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IConnectService
    {
        [OperationContract]
        string Echo();
    }
}