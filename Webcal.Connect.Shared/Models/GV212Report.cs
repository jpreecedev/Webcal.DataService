namespace Connect.Shared.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class GV212Report : BaseModel, IEquatable<GV212Report>
    {
        public DateTime Created { get; set; }

        [MaxLength]
        public byte[] SerializedData { get; set; }

        public bool Equals(GV212Report other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Created.Equals(other.Created) && Equals(SerializedData, other.SerializedData);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((GV212Report) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Created.GetHashCode()*397) ^ (SerializedData != null ? SerializedData.GetHashCode() : 0);
            }
        }
    }
}