namespace Webcal.Connect.Data
{
    using System.ComponentModel.DataAnnotations;

    public enum FilterDocumentType
    {
        Any,

        [Display(Name = "Analogue Tachograph")] AnalogueTachograph,

        Tachograph,
        Undownloadability,

        [Display(Name = "Letter For Decommissioning")] LetterForDecommissioning
    }
}