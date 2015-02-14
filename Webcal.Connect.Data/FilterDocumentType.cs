namespace Webcal.Connect.Data
{
    using System.ComponentModel.DataAnnotations;

    public enum FilterDocumentType
    {
        Any,
        Tachograph,
        Undownloadability,

        [Display(Name = "Letter For Decommissioning")] LetterForDecommissioning
    }
}