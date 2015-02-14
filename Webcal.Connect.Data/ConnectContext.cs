namespace Webcal.Connect.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Shared;
    using Shared.Models;

    public class ConnectContext : IdentityDbContext<ConnectUser, ConnectRole, int, ConnectUserLogin, ConnectUserRole, ConnectUserClaim>
    {
        public ConnectContext() : base("ConnectContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<TachographDocument> TachographDocuments { get; set; }

        public DbSet<UndownloadabilityDocument> UndownloadabilityDocuments { get; set; }

        public DbSet<LetterForDecommissioningDocument> LetterForDecommissioningDocuments { get; set; }

        public DbSet<UserPendingAuthorization> UnauthorizedUsers { get; set; }

        public static ConnectContext Create()
        {
            return new ConnectContext();
        }
    }
}