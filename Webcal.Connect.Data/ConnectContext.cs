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
    }

    public class Company
    {
        public int Id { get; set; }

        public string Key { get; set; }
    }
}