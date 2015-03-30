namespace Connect.Shared
{
    using Models;

    public static class DocumentTypeHelper
    {
        public static FilterDocumentType Parse(Document document)
        {
            var tachographDocument = document as TachographDocument;
            if (tachographDocument != null)
            {
                if (tachographDocument.IsDigital)
                {
                    return FilterDocumentType.Tachograph;
                }
                return FilterDocumentType.AnalogueTachograph;
            }

            var undownloadabilityDocument = document as UndownloadabilityDocument;
            if (undownloadabilityDocument != null)
            {
                return FilterDocumentType.Undownloadability;
            }

            var letterForDecommissioningDocument = document as LetterForDecommissioningDocument;
            if (letterForDecommissioningDocument != null)
            {
                return FilterDocumentType.LetterForDecommissioning;
            }

            return FilterDocumentType.Any;
        }
    }
}