namespace Connect.Shared.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Drawing;
    using System.Xml.Serialization;
    using Properties;

    [Serializable]
    public class Technician : BaseModel, IUserSignatureCapture
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public bool IsDefault { get; set; }
        public DateTime? DateOfLastCheck { get; set; }
        public DateTime? DateOfLast3YearCheck { get; set; }

        public bool HasSignature
        {
            get { return Image != null; }
        }

        [MaxLength]
        public byte[] RawImage { get; set; }

        [XmlIgnore, NotMapped]
        public Image Image
        {
            get
            {
                if (RawImage == null)
                {
                    return null;
                }

                return RawImage.ToImage();
            }
            set
            {
                if (value == null)
                {
                    RawImage = null;
                    return;
                }

                RawImage = value.ToByteArray();
            }
        }

        [XmlIgnore]
        public int UserId { get; set; }

        public DateTime? Uploaded { get; set; }

        public override string ToString()
        {
            if (IsDefault)
            {
                return string.Format(Resources.TXT_TECHNICIAN_DEFAULT, Name);
            }

            return Name;
        }
    }
}