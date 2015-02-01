namespace Webcal.DataService.WCFService
{
    using System.IdentityModel.Selectors;
    using System.ServiceModel.Description;

    public class ConnectServiceCredentials : ServiceCredentials
    {
        public override SecurityTokenManager CreateSecurityTokenManager()
        {
            return new ConnectServiceCredentialsSecurityTokenManager(this);
        }

        protected override ServiceCredentials CloneCore()
        {
            return new ConnectServiceCredentials();
        }
    }
}