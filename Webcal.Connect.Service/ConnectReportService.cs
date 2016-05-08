namespace Connect.Service
{
    using System;
    using System.Linq;
    using Shared;
    using Shared.Models;

    public partial class ConnectService
    {
        private static readonly DateTime _sqlDefaultDateTime = DateTime.Parse("01/01/1900");

        public void AutoUploadQCReport(QCReport report)
        {
            AutoUploadReport(report);
        }

        public void AutoUploadQCReport6Month(QCReport6Month report)
        {
            AutoUploadReport(report);
        }

        public void UploadQCReport(QCReport report)
        {
            UploadReport(report);
        }

        public void UploadQCReport6Month(QCReport6Month report)
        {
            UploadReport(report);
        }

        public void UploadTechnician(Technician technician)
        {
            using (var context = new ConnectContext())
            {
                technician.Id = 0;
                technician.UserId = GetUserId();
                technician.Uploaded = DateTime.Now;

                context.Set<Technician>().Add(technician);

                context.SaveChanges();
            }
        }

        public void UploadWorkshopSettings(WorkshopSettings workshopSettings)
        {
            using (var context = new ConnectContext())
            {
                workshopSettings.Id = 0;
                workshopSettings.UserId = GetUserId();
                workshopSettings.Uploaded = DateTime.Now;

                if (workshopSettings.Created == default(DateTime) || workshopSettings.Created == _sqlDefaultDateTime)
                {
                    workshopSettings.Created = DateTime.Now;
                }

                context.Set<WorkshopSettings>().Add(workshopSettings);
                context.SaveChanges();
            }
        }

        private void UploadReport<T>(T report) where T : BaseReport
        {
            using (var context = new ConnectContext())
            {
                report.Id = 0;
                report.User = null;
                report.ConnectUserId = GetUserId();
                context.Set<T>().Add(report);

                context.SaveChanges();
            }
        }

        private void AutoUploadReport<T>(T report) where T : BaseReport
        {
            using (var context = new ConnectContext())
            {
                var existingDocument = FindReports<T>(context, report.CentreName);

                bool hasExisting = existingDocument.Any();
                foreach (var item in existingDocument)
                {
                    if (item.Equals(report))
                    {
                        hasExisting = true;
                        break;
                    }
                }

                if (!hasExisting)
                {
                    report.Id = 0;
                    report.User = null;
                    report.ConnectUserId = GetUserId();
                    context.Set<T>().Add(report);

                    context.SaveChanges();
                }
            }
        }

        private static IQueryable<T> FindReports<T>(ConnectContext context, string tachoCentreName) where T : BaseReport
        {
            return context.Set<T>()
                .Where(doc => doc.CentreName == tachoCentreName)
                .OrderByDescending(doc => doc.Created)
                .Join(context.UserNodes, rep => rep.ConnectUserId, user => user.ConnectUser.Id, (doc, user) => new
                {
                    user.CompanyKey,
                    Report = doc
                })
                .Select(a => a.Report);
        }
    }
}