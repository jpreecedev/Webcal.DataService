namespace Webcal.Connect.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

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

            if (!context.Nodes.Any())
            {
                context.Nodes.Add(new Node
                {
                    Company = context.Companies.First(),
                    IsAuthorized = true,
                    MachineKey = "BF98"
                });
            }

            context.SaveChanges();
        }
    }
}