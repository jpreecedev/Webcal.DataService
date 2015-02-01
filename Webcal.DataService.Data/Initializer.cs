namespace Webcal.DataService.Data
{
    using System.Data.Entity;

    public class Initializer : MigrateDatabaseToLatestVersion<ConnectContext, Configuration>
    {
    }
}