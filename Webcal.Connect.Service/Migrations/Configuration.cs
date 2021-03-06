namespace Connect.Service.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Service;
    using Shared;
    using Shared.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ConnectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
            ContextKey = "Connect.Shared.Migrations.Configuration";
        }

        protected override void Seed(ConnectContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            context.Roles.Add(new ConnectRole(ConnectRoles.Admin));
            context.Roles.Add(new ConnectRole(ConnectRoles.TachographCentre));
            context.SaveChanges();

            var userManager = new UserManager<ConnectUser, int>(new UserStore<ConnectUser, ConnectRole, int, ConnectUserLogin, ConnectUserRole, ConnectUserClaim>(context));
            var connectUser = new ConnectUser
            {
                CompanyKey = ConnectConstants.ConnectAdministratonCompany,
                Email = "admin@webcalconnect.com",
                UserName = "admin@webcalconnect.com",
                IsAuthorized = true,
                LicenseKey = 0
            };
            context.SaveChanges();

            userManager.Create(connectUser, "Tacho255");
            context.Users.AddOrUpdate(connectUser);
            context.SaveChanges();

            userManager.AddToRole(connectUser.Id, ConnectRoles.Admin);

            context.Settings.Add(new Settings
            {
                CalibrationsDueReportTemplate = "Dear {CustomerName},<br/><br/>Below is a list of calibrations that are due between {From} and {To};<br/><br/>{CalibrationData}<br/><br/>Regards, Skillray.",
                RecentCalibrationsReportTemplate = "Dear {CustomerName},<br/><br/>Below is a list of calibrations between {From} and {To};<br/><br/>{CalibrationData}<br/><br/>Regards, Skillray.",
            });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}