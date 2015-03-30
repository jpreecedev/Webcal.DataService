namespace Connect.Shared
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using Models;

    public static class Extensions
    {
        public static IEnumerable<Document> GetAllDocuments(this ConnectContext context, DateTime? from, DateTime? to)
        {
            IEnumerable<Document> result = new List<Document>();

            result = result.Concat(GetDocuments<TachographDocument>(context, from, to));
            result = result.Concat(GetDocuments<UndownloadabilityDocument>(context, from, to));
            result = result.Concat(GetDocuments<UndownloadabilityDocument>(context, from, to));

            return result.OrderByDescending(c => c.InspectionDate.GetValueOrDefault());
        }

        public static IEnumerable<Document> GetAllDocuments(this ConnectContext context, ConnectUser connectUser)
        {
            IEnumerable<Document> result = new List<Document>();

            result = result.Concat(GetDocuments<TachographDocument>(context, connectUser.Id));
            result = result.Concat(GetDocuments<UndownloadabilityDocument>(context, connectUser.Id));
            result = result.Concat(GetDocuments<UndownloadabilityDocument>(context, connectUser.Id));

            return result.OrderByDescending(c => c.InspectionDate.GetValueOrDefault());
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

        private static IEnumerable<T> GetDocuments<T>(DbContext context, int connectUserId) where T : Document
        {
            var documentCount = context.Set<T>().Count();
            if (documentCount > 0)
            {
                return context.Set<T>().Where(c => c.Deleted == null && c.UserId == connectUserId);
            }
            return new List<T>();
        }

        private static IEnumerable<T> GetDocuments<T>(DbContext context, DateTime? from, DateTime? to) where T : Document
        {
            List<T> result = new List<T>();

            var documentCount = context.Set<T>().Count();
            if (documentCount > 0)
            {
                var documents = context.Set<T>().Where(c => c.Deleted == null);
                if (from != null && to != null)
                {
                    foreach (var document in documents)
                    {
                        var inspectionDate = document.InspectionDate.GetValueOrDefault();
                        if (inspectionDate != default(DateTime))
                        {
                            var nextDueDate = inspectionDate.AddYears(2);
                            if (nextDueDate >= from.GetValueOrDefault() && nextDueDate <= to.GetValueOrDefault())
                            {
                                result.Add(document);
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}