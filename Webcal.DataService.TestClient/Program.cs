namespace Webcal.DataService.TestClient
{
    using System;
    using System.Security.Cryptography.X509Certificates;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using Shared;

    internal class Program
    {
        private static void Main()
        {
            ChannelFactory<IConnectService> channelFactory = null;
            IConnectService client = null;

            try
            {
                Binding binding = BindingHelper.CreateBinding();
                var serviceAddress = new EndpointAddress(string.Format("https://{0}/ConnectService.svc", "webcal-connect.local"));

                channelFactory = new ChannelFactory<IConnectService>(binding, serviceAddress);

                var credentials = new ConnectClientCredentials(new ConnectKeys(123, "Skillray", "Test"));
                credentials.ServiceCertificate.SetDefaultCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindByIssuerName, Constants.CertificateName);

                channelFactory.Endpoint.Behaviors.Remove(typeof (ClientCredentials));
                channelFactory.Endpoint.Behaviors.Add(credentials);

                client = channelFactory.CreateChannel();

                Console.WriteLine("Echo service returned: {0}", client.Echo());

                ((IChannel) client).Close();
                channelFactory.Close();
            }
            catch (CommunicationException e)
            {
                Abort((IChannel) client, channelFactory);

                // if there is a fault then print it out
                FaultException fe = null;
                Exception tmp = e;
                while (tmp != null)
                {
                    fe = tmp as FaultException;
                    if (fe != null)
                    {
                        break;
                    }
                    tmp = tmp.InnerException;
                }
                if (fe != null)
                {
                    Console.WriteLine("The server sent back a fault: {0}", fe.CreateMessageFault().Reason.GetMatchingTranslation().Text);
                }
                else
                {
                    Console.WriteLine("The request failed with exception: {0}", e);
                }
            }
            catch (TimeoutException)
            {
                Abort((IChannel) client, channelFactory);
                Console.WriteLine("The request timed out");
            }
            catch (Exception e)
            {
                Abort((IChannel) client, channelFactory);
                Console.WriteLine("The request failed with unexpected exception: {0}", e);
            }

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }


        private static void Abort(IChannel channel, ChannelFactory cf)
        {
            if (channel != null)
                channel.Abort();
            if (cf != null)
                cf.Abort();
        }
    }
}