namespace Connect.Shared.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseReport : BaseModel
    {
        [Required]
        [MinLength(3)]
        public string CentreName { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Uploaded { get; set; }

        public ReportType MobileDocumentType { get; set; }

        public MobileApplicationUser User { get; set; }

        public int? ConnectUserId { get; set; }
        
        [MaxLength]
        public byte[] SerializedData { get; set; }
    }
}