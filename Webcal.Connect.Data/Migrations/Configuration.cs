namespace Webcal.Connect.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Shared;

    public sealed class Configuration : DbMigrationsConfiguration<ConnectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ConnectContext context)
        {
            if (!context.Companies.Any())
            {
                context.Companies.Add(new Company
                {
                    Key = "Skillray",
                    IsAuthorized = true
                });
            }

            context.SaveChanges();

            if (!context.ConnectUsers.Any())
            {
                context.ConnectUsers.Add(new ConnectUser(new ConnectKeys("", 0, "Skillray", "BF98"))
                {
                    IsAuthorized = true
                });
            }

            context.SaveChanges();
        }
    }
}