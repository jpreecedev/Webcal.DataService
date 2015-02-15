namespace Webcal.Connect.Shared
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Models;

    public static class Extensions
    {
        public static IEnumerable<Document> GetAllDocuments(this ConnectContext context, ConnectUser connectUser)
        {
            var tachographDocuments = context.TachographDocuments.Where(c => c.Deleted == null && c.UserId == connectUser.Id).ToList();
            var undownloadabilityDocuments = context.UndownloadabilityDocuments.Where(c => c.Deleted == null && c.UserId == connectUser.Id).ToList();
            var letterForDecommissioningDocuments = context.LetterForDecommissioningDocuments.Where(c => c.Deleted == null && c.UserId == connectUser.Id).ToList();

            return tachographDocuments.Concat<Document>(undownloadabilityDocuments).Concat<Document>(letterForDecommissioningDocuments);
        }
    }
}