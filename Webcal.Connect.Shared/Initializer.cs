namespace Webcal.Connect.Shared
{
    using System.Data.Entity;
    using Migrations;

    public class Initializer : MigrateDatabaseToLatestVersion<ConnectContext, Configuration>
    {
    }
}