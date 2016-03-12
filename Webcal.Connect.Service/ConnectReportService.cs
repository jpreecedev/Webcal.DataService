namespace Connect.Service
{
    using System.Linq;
    using Shared.Models;

    public partial class ConnectService
    {
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