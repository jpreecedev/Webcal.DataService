namespace Webcal.Connect.Data
{
    using System.Data.Entity;
    using System.Linq;

    public class Initializer : CreateDatabaseIfNotExists<ConnectContext>
    {
        protected override void Seed(ConnectContext context)
        {
            if (!context.Companies.Any())
            {
                context.Companies.Add(new Company
                {
                    Key = "Skillray"
                });

                context.SaveChanges();
            }

        }
    }
}