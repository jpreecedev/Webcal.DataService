using Connect.Shared.Models;

namespace Connect.Shared
{
    using System;

    [Flags, Serializable]
    public enum DocumentType
    {
        [FullDocumentType(typeof(TachographDocument))]
        Tachograph = 1,
        [FullDocumentType(typeof(UndownloadabilityDocument))]
        Undownloadability = 2,
        [FullDocumentType(typeof(LetterForDecommissioningDocument))]
        LetterForDecommissioning = 4,
        [FullDocumentType(typeof(QCReport))]
        QCReport = 8,
        [FullDocumentType(typeof(QCReport6Month))]
        QCReport6Month = 16
    }
}