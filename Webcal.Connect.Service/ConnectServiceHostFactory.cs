namespace Connect.Service
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Activation;

    public class ConnectServiceHostFactory : ServiceHostFactoryBase
    {
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            return new ConnectServiceHost(new[]
            {
                new Uri(ConnectCredentials.BaseUrl)
            });
        }
    }
}