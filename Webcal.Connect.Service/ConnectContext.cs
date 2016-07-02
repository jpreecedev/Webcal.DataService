namespace Connect.Service
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Shared;
    using Shared.Models;
    using System.Data.Entity;
    using Shared.Models.License;

    public class ConnectContext : IdentityDbContext<ConnectUser, ConnectRole, int, ConnectUserLogin, ConnectUserRole, ConnectUserClaim>, IConnectContext
    {
        public ConnectContext() 
            : base(ConnectCredentials.ConnectionString)
        {

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

        public DbSet<Client> Clients { get; set; }

        public DbSet<License> Licenses { get; set; }

        public DbSet<MobileApplicationUser> MobileApplicationUsers { get; set; }

        public DbSet<QCReport> QCReports { get; set; }

        public DbSet<QCReport6Month> QCReports6Month { get; set; }

        public DbSet<Technician> Technicians { get; set; }

        public DbSet<WorkshopSettings> WorkshopSettings { get; set; }

        public DbSet<DetailedException> DetailedExceptions { get; set; }

        public DbSet<DirectUploadDocument> DirectUploadDocuments { get; set; }

        public DbSet<StatusReportMap> StatusReportMaps { get; set; }
    }
}