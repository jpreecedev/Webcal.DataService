namespace Connect.Shared
{
    using System.Data.Entity;
    using Models;
    using Models.License;

    public interface IConnectContext
    {
        DbSet<TachographDocument> TachographDocuments { get; set; }

        DbSet<UndownloadabilityDocument> UndownloadabilityDocuments { get; set; }

        DbSet<LetterForDecommissioningDocument> LetterForDecommissioningDocuments { get; set; }

        DbSet<UserPendingAuthorization> UnauthorizedUsers { get; set; }

        DbSet<ConnectUserNode> UserNodes { get; set; }

        DbSet<Settings> Settings { get; set; }

        DbSet<TachoFleetEmail> Emails { get; set; }

        DbSet<TachoCentreOperator> TachoCentreOperators { get; set; }

        DbSet<CustomerContact> CustomerContacts { get; set; }

        DbSet<LinkedVehicle> LinkedVehicles { get; set; }

        DbSet<Client> Clients { get; set; }

        DbSet<License> Licenses { get; set; }

        DbSet<MobileApplicationUser> MobileApplicationUsers { get; set; }

        DbSet<QCReport> QCReports { get; set; }

        DbSet<QCReport6Month> QCReports6Month { get; set; }
    }
}
