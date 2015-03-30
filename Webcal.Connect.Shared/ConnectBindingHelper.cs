namespace Connect.Shared
{
    using System.ServiceModel.Channels;
    using System.ServiceModel.Security.Tokens;

    public class ConnectBindingHelper : IConnectBindingHelper
    {
        public Binding CreateBinding(SecurityTokenParameters parameters)
        {
            var httpTransport = new HttpsTransportBindingElement
            {
                MaxReceivedMessageSize = 5000000
            };

            var messageSecurity = new SymmetricSecurityBindingElement();
            messageSecurity.EndpointSupportingTokenParameters.SignedEncrypted.Add(parameters);

            var x509ProtectionParameters = new X509SecurityTokenParameters
            {
                InclusionMode = SecurityTokenInclusionMode.Never
            };
            messageSecurity.ProtectionTokenParameters = x509ProtectionParameters;
            messageSecurity.EnableUnsecuredResponse = true;
            messageSecurity.AllowInsecureTransport = true;

            return new CustomBinding(messageSecurity, httpTransport);
        }
    }
}