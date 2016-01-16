namespace Connect.Service
{
    using System;
    using System.Data.Entity;
    using System.Security.Cryptography.X509Certificates;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using Shared;

    public class ConnectServiceHost : ServiceHost
    {
        public ConnectServiceHost(params Uri[] addresses)
            : base(typeof (ConnectService), addresses)
        {
            Database.SetInitializer(new Initializer());

            using (var context = new ConnectContext())
            {
                context.Database.CreateIfNotExists();
            }
        }

        protected override void InitializeRuntime()
        {
            var baseUri = new Uri(ConnectCredentials.BaseUrl);
            var serviceUri = new Uri(baseUri, "ConnectService.svc");

            Description.Behaviors.Remove((typeof (ServiceCredentials)));

            var serviceCredential = new ConnectServiceCredentials();
            serviceCredential.ServiceCertificate.Certificate = new X509Certificate2(ConnectCredentials.DefaultCertificate, ConnectCredentials.CertificatePassword, X509KeyStorageFlags.MachineKeySet);
            Description.Behaviors.Add(serviceCredential);

            var behaviour = new ServiceMetadataBehavior {HttpGetEnabled = true, HttpsGetEnabled = false};
            Description.Behaviors.Add(behaviour);

            Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;
            Description.Behaviors.Find<ServiceDebugBehavior>().HttpHelpPageUrl = serviceUri;

            AddServiceEndpoint(typeof (IConnectService), new ConnectBindingHelper().CreateBinding(), string.Empty);

            base.InitializeRuntime();
        }
    }
}