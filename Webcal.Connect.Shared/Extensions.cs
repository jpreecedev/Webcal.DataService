namespace Webcal.Connect.Shared
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Models;

    public static class Extensions
    {
        public static IEnumerable<Document> GetAllDocuments(this ConnectContext context, ConnectUser connectUser)
        {
            var tachographDocuments = context.TachographDocuments.Where(c => c.Deleted == null && c.UserId == connectUser.Id).ToList();
            var undownloadabilityDocuments = context.UndownloadabilityDocuments.Where(c => c.Deleted == null && c.UserId == connectUser.Id).ToList();
            var letterForDecommissioningDocuments = context.LetterForDecommissioningDocuments.Where(c => c.Deleted == null && c.UserId == connectUser.Id).ToList();

            return tachographDocuments.Concat<Document>(undownloadabilityDocuments).Concat<Document>(letterForDecommissioningDocuments).OrderByDescending(c => c.InspectionDate.GetValueOrDefault());
        }

        public static async Task<Document> GetDocumentAsync(this ConnectContext context, ConnectUser connectUser, DocumentType documentType, int id)
        {
            IQueryable<Document> set = null;

            switch (documentType)
            {
                case DocumentType.Tachograph:
                    set = context.Set<TachographDocument>();
                    break;
                case DocumentType.Undownloadability:
                    set = context.Set<UndownloadabilityDocument>();
                    break;
                case DocumentType.LetterForDecommissioning:
                    set = context.Set<LetterForDecommissioningDocument>();
                    break;
            }

            if (set != null)
            {
                return await set.FirstOrDefaultAsync(document => document.UserId == connectUser.Id && document.Id == id);
            }

            return null;
        }
    }
}