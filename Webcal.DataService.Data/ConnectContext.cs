namespace Webcal.DataService.Data
{
    using System.Data.Entity;
    using Shared;

    public class ConnectContext : DbContext
    {
        public ConnectContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Company> Companies { get; set; }
    }
}