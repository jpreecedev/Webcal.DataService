namespace Webcal.DataService.Shared
{
    using System.ServiceModel.Channels;
    using System.ServiceModel.Security.Tokens;

    public static class BindingHelper
    {
        public static Binding CreateBinding()
        {
            var httpTransport = new HttpsTransportBindingElement();

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