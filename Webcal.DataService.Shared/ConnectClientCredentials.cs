namespace Webcal.DataService.Shared
{
    using System;
    using System.IdentityModel.Selectors;
    using System.ServiceModel.Description;

    public class ConnectClientCredentials : ClientCredentials
    {
        private readonly ConnectKeys _connectKeys;

        public ConnectClientCredentials(ConnectKeys connectKeys)
        {
            if (connectKeys == null)
            {
                throw new ArgumentNullException("connectKeys");
            }
            _connectKeys = connectKeys;
        }

        public ConnectKeys ConnectKeys
        {
            get { return _connectKeys; }
        }

        protected override ClientCredentials CloneCore()
        {
            return new ConnectClientCredentials(_connectKeys);
        }

        public override SecurityTokenManager CreateSecurityTokenManager()
        {
            return new ConnectClientCredentialsSecurityTokenManager(this);
        }
    }
}