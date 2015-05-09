namespace Connect.Shared.Models.License
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Clients", Schema = "License")]
    public class Client : BaseModel
    {
        public Guid AccessId { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; }

        public virtual List<License> Licenses { get; set; }
    }
}