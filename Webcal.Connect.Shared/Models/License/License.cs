namespace Connect.Shared.Models.License
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Licenses", Schema = "License")]
    public class License : BaseModel
    {
        public string Key { get; set; }

        public DateTime Expiration { get; set; }

        public DateTime Created { get; set; }

        public Guid AccessId { get; set; }
    }
}