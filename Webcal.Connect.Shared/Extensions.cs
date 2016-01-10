namespace Connect.Shared
{
    using System.Data.Entity;
    using System.Linq;
    using System.Security;

    public static class Extensions
    {
        public static int GetUserId(this ConnectContext context, string companyKey, string machineKey)
        {
            var connectUser = context.UserNodes.Include(x => x.ConnectUser).Select(c => new
            {
                c.ConnectUser.Id,
                c.CompanyKey,
                c.MachineKey,
                c.DepotName
            })
                .FirstOrDefault(c => c.CompanyKey == companyKey && c.MachineKey == machineKey);

            if (connectUser != null)
            {
                return connectUser.Id;
            }

            return -1;
        }

        public static int GetUserId(this IConnectKeys connectKeys)
        {
            using (var context = new ConnectContext())
            {
                return GetUserId(context, connectKeys.CompanyKey, connectKeys.MachineKey);
            }
        }

        public static SecureString ToSecureString(this string str)
        {
            var result = new SecureString();

            foreach (var c in System.Text.Encoding.Default.GetBytes(str))
            {
                result.AppendChar((char)c);
            }

            result.MakeReadOnly();
            return result;
        }
    }
}