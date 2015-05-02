namespace Connect.Shared
{
    using System.ServiceModel.Channels;
    using System.ServiceModel.Security.Tokens;

    public class ConnectBindingHelper : IConnectBindingHelper
    {
        public Binding CreateBinding()
        {
            var httpTransport = new HttpTransportBindingElement
            {
                MaxReceivedMessageSize = 10000000
            };

            var messageSecurity = new SymmetricSecurityBindingElement();
            messageSecurity.EndpointSupportingTokenParameters.SignedEncrypted.Add(new ConnectTokenParameters());
            
            var x509ProtectionParameters = new X509SecurityTokenParameters
            {
                InclusionMode = SecurityTokenInclusionMode.Never
            };

            messageSecurity.ProtectionTokenParameters = x509ProtectionParameters;
            return new CustomBinding(messageSecurity, httpTransport);
        }

        public Binding CreateHttpsBinding()
        {
            var httpTransport = new HttpsTransportBindingElement
            {
                MaxReceivedMessageSize = 10000000
            };

            var messageSecurity = new SymmetricSecurityBindingElement();
            messageSecurity.EndpointSupportingTokenParameters.SignedEncrypted.Add(new ConnectTokenParameters());

            var x509ProtectionParameters = new X509SecurityTokenParameters
            {
                InclusionMode = SecurityTokenInclusionMode.Never
            };

            messageSecurity.ProtectionTokenParameters = x509ProtectionParameters;
            return new CustomBinding(messageSecurity, httpTransport);
        }
    }
}