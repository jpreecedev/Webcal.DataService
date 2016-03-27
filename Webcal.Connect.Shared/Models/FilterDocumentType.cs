namespace Connect.Shared.Models
{
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FilterDocumentType
    {
        Any,

        [Display(Name = "Analogue Tacho")] AnalogueTachograph,

        [Display(Name = "Digital Tacho")] Tachograph,

        Undownloadability,

        [Display(Name = "Letter For Decomm")] LetterForDecommissioning
    }
}