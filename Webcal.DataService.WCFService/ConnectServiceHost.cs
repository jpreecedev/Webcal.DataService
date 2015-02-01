namespace Webcal.DataService.WCFService
{
    using System;
    using System.Data.Entity;
    using System.Security.Cryptography.X509Certificates;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using Data;
    using Shared;

    public class ConnectServiceHost : ServiceHost
    {
        public ConnectServiceHost(params Uri[] addresses)
            : base(typeof (ConnectService), addresses)
        {
            Database.SetInitializer(new Initializer());

            using (ConnectContext context = new ConnectContext())
            {
                context.Database.CreateIfNotExists();
            }
        }

        protected override void InitializeRuntime()
        {
            // Create a credit card service credentials and add it to the behaviors.
            var serviceCredentials = new ConnectServiceCredentials();
            serviceCredentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindByIssuerName, Constants.CertificateName);

            Description.Behaviors.Remove((typeof (ServiceCredentials)));
            Description.Behaviors.Add(serviceCredentials);

            // Register a credit card binding for the endpoint.
            Binding binding = BindingHelper.CreateBinding();
            AddServiceEndpoint(typeof (IConnectService), binding, string.Empty);

            base.InitializeRuntime();
        }
    }
}