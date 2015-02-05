namespace Webcal.Connect.Data
{
    using System.Data.Entity;

    public class ConnectContext : DbContext
    {
        public ConnectContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Node> Nodes { get; set; }
    }
}