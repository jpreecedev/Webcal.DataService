namespace Connect.Shared
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
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

        public static string AsDisplayString(this FilterDocumentType documentType)
        {
            var result = documentType.GetAttributeOfType<DisplayAttribute>();
            if (result != null && !string.IsNullOrEmpty(result.Name))
            {
                return result.Name;
            }
            return documentType.ToString();
        }
    }
}