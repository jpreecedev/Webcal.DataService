using System.ComponentModel.DataAnnotations.Schema;

namespace Connect.Shared.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [KnownType(typeof(TachographDocument))]
    [KnownType(typeof(UndownloadabilityDocument))]
    [KnownType(typeof(LetterForDecommissioningDocument))]
    public abstract class Document : BaseModel, IEquatable<Document>
    {
        private string _documentType;
        public DateTime Created { get; set; }

        public string DocumentType
        {
            get { return _documentType; }
            set
            {
                _documentType = value;
                OnDocumentTypeChanged(value);
            }
        }

        public string Office { get; set; }
        public string RegistrationNumber { get; set; }
        public string TachographMake { get; set; }
        public string TachographModel { get; set; }
        public string SerialNumber { get; set; }
        public DateTime? InspectionDate { get; set; }
        public string Technician { get; set; }
        public string CustomerContact { get; set; }
        public string DepotName { get; set; }

        [XmlIgnore]
        public string CompanyName { get; set; }

        [NotMapped]
        public byte[] SerializedData { get; set; }

        [XmlIgnore]
        public int UserId { get; set; }

        [XmlIgnore]
        public abstract bool IsNew { get; }

        public DateTime? Uploaded { get; set; }

        protected virtual void OnDocumentTypeChanged(string newValue)
        {
        }

        public bool Equals(Document other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Created.Equals(other.Created) && string.Equals(Office, other.Office) && string.Equals(RegistrationNumber, other.RegistrationNumber) && string.Equals(TachographMake, other.TachographMake) && string.Equals(TachographModel, other.TachographModel) && string.Equals(SerialNumber, other.SerialNumber) && InspectionDate.Equals(other.InspectionDate) && string.Equals(Technician, other.Technician) && string.Equals(CustomerContact, other.CustomerContact) && string.Equals(DepotName, other.DepotName) && string.Equals(CompanyName, other.CompanyName) && UserId == other.UserId && Uploaded.Equals(other.Uploaded);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Document)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Created.GetHashCode();
                hashCode = (hashCode * 397) ^ (Office != null ? Office.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (RegistrationNumber != null ? RegistrationNumber.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TachographMake != null ? TachographMake.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TachographModel != null ? TachographModel.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SerialNumber != null ? SerialNumber.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ InspectionDate.GetHashCode();
                hashCode = (hashCode * 397) ^ (Technician != null ? Technician.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CustomerContact != null ? CustomerContact.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (DepotName != null ? DepotName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CompanyName != null ? CompanyName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ UserId;
                hashCode = (hashCode * 397) ^ Uploaded.GetHashCode();
                return hashCode;
            }
        }
    }
}