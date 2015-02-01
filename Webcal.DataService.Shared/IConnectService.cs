namespace Webcal.DataService.Shared
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IConnectService
    {
        [OperationContract]
        string Echo();
    }
}