namespace Connect.Shared
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class ConnectContext : IdentityDbContext<ConnectUser, ConnectRole, int, ConnectUserLogin, ConnectUserRole, ConnectUserClaim>
    {
        public ConnectContext()
            : base(ConnectConstants.ConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<TachographDocument> TachographDocuments { get; set; }

        public DbSet<UndownloadabilityDocument> UndownloadabilityDocuments { get; set; }

        public DbSet<LetterForDecommissioningDocument> LetterForDecommissioningDocuments { get; set; }

        public DbSet<UserPendingAuthorization> UnauthorizedUsers { get; set; }

        public DbSet<ConnectUserNode> UserNodes { get; set; }

        public DbSet<Settings> Settings { get; set; }

        public DbSet<TachoFleetEmail> Emails { get; set; }

        public DbSet<TachoCentreOperator> TachoCentreOperators { get; set; }

        public DbSet<CustomerContact> CustomerContacts { get; set; }

        public DbSet<LinkedVehicle> LinkedVehicles { get; set; }

        public static ConnectContext Create()
        {
            return new ConnectContext();
        }
    }
}