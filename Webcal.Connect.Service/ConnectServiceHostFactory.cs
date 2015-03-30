namespace Connect.Service
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Activation;

    public class ConnectServiceHostFactory : ServiceHostFactoryBase
    {
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            return new ConnectServiceHost(new List<Uri>
            {
                new Uri("https://www.webcalconnect.com/service/")
            }.ToArray());
        }
    }
}