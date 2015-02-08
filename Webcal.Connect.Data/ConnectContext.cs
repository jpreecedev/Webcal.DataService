namespace Webcal.Connect.Data
{
    using System.Data.Entity;
    using Shared.Models;

    public class ConnectContext : DbContext
    {
        public ConnectContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<ConnectUser> ConnectUsers { get; set; }

        public DbSet<TachographDocument> TachographDocuments { get; set; }

        public DbSet<UndownloadabilityDocument> UndownloadabilityDocuments { get; set; }

        public DbSet<LetterForDecommissioningDocument> LetterForDecommissioningDocuments { get; set; }

        public DbSet<UserPendingAuthorization> UnauthorizedUsers { get; set; }
    }
}