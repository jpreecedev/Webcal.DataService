using System;

namespace Connect.Shared.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [DataContract, Serializable]
    public class DetailedException : BaseModel
    {
        [DataMember]
        [MaxLength]
        public string ExceptionDetails { get; set; }

        [DataMember]
        public string ApplicationName { get; set; }

        [DataMember]
        [MaxLength]
        public byte[] RawImage { get; set; }

        [DataMember]
        public DateTime Occurred { get; set; }
        
        [XmlIgnore]
        public int UserId { get; set; }

        [DataMember]
        public DateTime? Uploaded { get; set; }
    }
}
