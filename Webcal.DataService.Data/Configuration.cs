namespace Webcal.DataService.Data
{
    using System.Data.Entity.Migrations;
    using Shared;

    public sealed class Configuration : DbMigrationsConfiguration<ConnectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(ConnectContext context)
        {
            context.Companies.Add(new Company
            {
                Key = "Skillray"
            });

            context.SaveChanges();
        }
    }
}