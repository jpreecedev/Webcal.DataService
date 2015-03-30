namespace Connect.Shared
{
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ConnectRole : IdentityRole<int, ConnectUserRole>
    {
        public ConnectRole()
        {
        }

        public ConnectRole(string name)
        {
            Name = name;
        }
    }
}