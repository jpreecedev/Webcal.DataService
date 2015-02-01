namespace Webcal.DataService.Shared
{
    using System;
    using System.IdentityModel.Selectors;
    using System.IdentityModel.Tokens;

    public class ConnectTokenProvider : SecurityTokenProvider
    {
        private readonly ConnectKeys _connectKeys;

        public ConnectTokenProvider(ConnectKeys connectKeys)
        {
            if (connectKeys == null)
            {
                throw new ArgumentNullException("connectKeys");
            }
            _connectKeys = connectKeys;
        }

        protected override SecurityToken GetTokenCore(TimeSpan timeout)
        {
            return new ConnectToken(_connectKeys);
        }
    }
}