namespace Connect.Service
{
    using System.IdentityModel.Selectors;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.ServiceModel.Security;
    using Shared;

    public class ConnectServiceCredentialsSecurityTokenManager : ServiceCredentialsSecurityTokenManager
    {

        public ConnectServiceCredentialsSecurityTokenManager(ServiceCredentials serviceCredentials)
            : base(serviceCredentials)
        {

        }

        public override SecurityTokenAuthenticator CreateSecurityTokenAuthenticator(SecurityTokenRequirement tokenRequirement, out SecurityTokenResolver outOfBandTokenResolver)
        {
            if (tokenRequirement.TokenType == ConnectConstants.ConnectTokenType)
            {
                outOfBandTokenResolver = null;
                return new ConnectTokenAuthenticator();
            }
            return base.CreateSecurityTokenAuthenticator(tokenRequirement, out outOfBandTokenResolver);
        }

        public override SecurityTokenSerializer CreateSecurityTokenSerializer(SecurityTokenVersion version)
        {
            return new ConnectSecurityTokenSerializer(version);
        }
    }
}
