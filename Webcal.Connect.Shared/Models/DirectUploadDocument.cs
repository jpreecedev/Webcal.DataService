namespace Connect.Shared.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [DataContract, Serializable]
    public class DirectUploadDocument : BaseModel
    {
        [DataMember]
        [MaxLength]
        public byte[] SerializedData { get; set; }

        public DateTime Uploaded { get; set; }

        [XmlIgnore]
        public int UserId { get; set; }

        public string FileName { get; set; }
    }
}