namespace Connect.Shared.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class QCReport3Month : BaseReport, IEquatable<QCReport3Month>
    {
        [Required]
        [MinLength(3)]
        public string CentreSealNumber { get; set; }

        public bool Section3Question1 { get; set; }

        public bool Section3Question2 { get; set; }

        public bool Section4Question1 { get; set; }

        public bool Section4Question2 { get; set; }

        public bool Section4Question3 { get; set; }

        public bool Section5Question1 { get; set; }

        public bool Section5Question2 { get; set; }

        public bool Section7Question1 { get; set; }

        public bool Section7Question2 { get; set; }

        public bool CalibrationSection9And10Question1 { get; set; }

        public bool CalibrationSection9And10Question2 { get; set; }

        public bool CalibrationSection9And10Question3 { get; set; }

        public bool DataManagementSection10Question1 { get; set; }

        public bool DataManagementSection10Question2 { get; set; }

        public bool DataManagementSection10Question3 { get; set; }

        public string FurtherDetails { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public bool Equals(QCReport3Month other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return CalibrationSection9And10Question1 == other.CalibrationSection9And10Question1 && CalibrationSection9And10Question2 == other.CalibrationSection9And10Question2 && CalibrationSection9And10Question3 == other.CalibrationSection9And10Question3 && string.Equals(TachoCentreName, other.TachoCentreName) && string.Equals(CentreSealNumber, other.CentreSealNumber) && DataManagementSection10Question1 == other.DataManagementSection10Question1 && DataManagementSection10Question2 == other.DataManagementSection10Question2 && DataManagementSection10Question3 == other.DataManagementSection10Question3 && Date.Equals(other.Date) && string.Equals(FurtherDetails, other.FurtherDetails) && string.Equals(Name, other.Name) && Section3Question1 == other.Section3Question1 && Section3Question2 == other.Section3Question2 && Section4Question1 == other.Section4Question1 && Section4Question2 == other.Section4Question2 && Section4Question3 == other.Section4Question3 && Section5Question1 == other.Section5Question1 && Section5Question2 == other.Section5Question2 && Section7Question1 == other.Section7Question1 && Section7Question2 == other.Section7Question2;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((QCReport3Month) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = CalibrationSection9And10Question1.GetHashCode();
                hashCode = (hashCode*397) ^ CalibrationSection9And10Question2.GetHashCode();
                hashCode = (hashCode*397) ^ CalibrationSection9And10Question3.GetHashCode();
                hashCode = (hashCode*397) ^ (TachoCentreName != null ? TachoCentreName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (CentreSealNumber != null ? CentreSealNumber.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ DataManagementSection10Question1.GetHashCode();
                hashCode = (hashCode*397) ^ DataManagementSection10Question2.GetHashCode();
                hashCode = (hashCode*397) ^ DataManagementSection10Question3.GetHashCode();
                hashCode = (hashCode*397) ^ Date.GetHashCode();
                hashCode = (hashCode*397) ^ (FurtherDetails != null ? FurtherDetails.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ Section3Question1.GetHashCode();
                hashCode = (hashCode*397) ^ Section3Question2.GetHashCode();
                hashCode = (hashCode*397) ^ Section4Question1.GetHashCode();
                hashCode = (hashCode*397) ^ Section4Question2.GetHashCode();
                hashCode = (hashCode*397) ^ Section4Question3.GetHashCode();
                hashCode = (hashCode*397) ^ Section5Question1.GetHashCode();
                hashCode = (hashCode*397) ^ Section5Question2.GetHashCode();
                hashCode = (hashCode*397) ^ Section7Question1.GetHashCode();
                hashCode = (hashCode*397) ^ Section7Question2.GetHashCode();
                return hashCode;
            }
        }
    }
}