namespace Connect.Service
{
    using System.Data.Entity;
    using Migrations;

    public class Initializer : MigrateDatabaseToLatestVersion<ConnectContext, Configuration>
    {
    }
}