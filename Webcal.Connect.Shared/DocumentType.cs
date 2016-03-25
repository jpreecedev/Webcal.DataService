namespace Connect.Shared
{
    using System;

    [Flags, Serializable]
    public enum DocumentType
    {
        Tachograph = 1,
        Undownloadability = 2,
        LetterForDecommissioning = 4,
        QCReport = 8,
        QCReport6Month = 16
    }
}