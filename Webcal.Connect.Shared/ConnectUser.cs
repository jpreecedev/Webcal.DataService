namespace Webcal.Connect.Shared
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Data;

    public class ConnectUser
    {
        private readonly IConnectKeys _connectKeys;
        private Company _company;

        public ConnectUser(IConnectKeys connectKeys)
        {
            _connectKeys = connectKeys;
        }

        public Company Company
        {
            get { return _company ?? (_company = Fetch<Company>(c => c.Key == _connectKeys.CompanyKey)); }
        }

        private static TResult Fetch<TResult>(Expression<Func<TResult, bool>> expression) where TResult : class
        {
            using (var context = new ConnectContext())
            {
                return context.Set<TResult>().FirstOrDefault(expression);
            }
        }
    }
}