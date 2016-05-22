namespace Connect.Shared
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Drawing;
    using System.Xml.Serialization;

    [Serializable]
    public class WorkshopSettings : BaseSettings, IEquatable<WorkshopSettings>
    {
        private bool _doNotSend;
        private bool _sendToCustomer;
        private bool _sendToOffice;
        public bool AutoBackup { get; set; }
        public string BackupFilePath { get; set; }
        public string Office { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
        public string WorkshopName { get; set; }
        public string PhoneNumber { get; set; }
        public bool AutoPrintLabels { get; set; }
        public string MainEmailAddress { get; set; }
        public string SecondaryEmailAddress { get; set; }

        [XmlIgnore]
        public virtual List<CustomDayOfWeek> CustomDayOfWeeks { get; set; }

        public bool SendToCustomer
        {
            get { return _sendToCustomer; }
            set
            {
                _sendToCustomer = value;
                if (_sendToCustomer)
                {
                    DoNotSend = false;
                }
            }
        }

        public bool SendToOffice
        {
            get { return _sendToOffice; }
            set
            {
                _sendToOffice = value;
                if (_sendToOffice)
                {
                    DoNotSend = false;
                }
            }
        }

        public bool DoNotSend
        {
            get { return _doNotSend; }
            set
            {
                _doNotSend = value;

                if (_doNotSend)
                {
                    SendToOffice = false;
                    SendToCustomer = false;
                }
            }
        }

        [XmlIgnore, MaxLength]
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

        public DateTime? CentreQuarterlyCheckDate { get; set; }

        public DateTime? MonthlyGV212Date { get; set; }

        public bool IsStatusReportCheckEnabled { get; set; }
        
        public bool IsGV212CheckEnabled { get; set; }

        [XmlIgnore]
        public int UserId { get; set; }

        public DateTime? Uploaded { get; set; }

        public DateTime Created { get; set; }

        public bool Equals(WorkshopSettings other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Address1, other.Address1, StringComparison.CurrentCulture) && string.Equals(Address2, other.Address2, StringComparison.CurrentCulture) && string.Equals(Address3, other.Address3, StringComparison.CurrentCulture) && AutoBackup == other.AutoBackup && AutoPrintLabels == other.AutoPrintLabels && string.Equals(BackupFilePath, other.BackupFilePath, StringComparison.CurrentCulture) && CentreQuarterlyCheckDate.Equals(other.CentreQuarterlyCheckDate) && Created.Equals(other.Created) && IsGV212CheckEnabled == other.IsGV212CheckEnabled && IsStatusReportCheckEnabled == other.IsStatusReportCheckEnabled && string.Equals(MainEmailAddress, other.MainEmailAddress, StringComparison.CurrentCulture) && MonthlyGV212Date.Equals(other.MonthlyGV212Date) && string.Equals(Office, other.Office, StringComparison.CurrentCulture) && string.Equals(PhoneNumber, other.PhoneNumber, StringComparison.CurrentCulture) && string.Equals(PostCode, other.PostCode, StringComparison.CurrentCulture) && string.Equals(SecondaryEmailAddress, other.SecondaryEmailAddress, StringComparison.CurrentCulture) && string.Equals(Town, other.Town, StringComparison.CurrentCulture) && Uploaded.Equals(other.Uploaded) && UserId == other.UserId && string.Equals(WorkshopName, other.WorkshopName, StringComparison.CurrentCulture);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((WorkshopSettings) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Address1 != null ? StringComparer.CurrentCulture.GetHashCode(Address1) : 0);
                hashCode = (hashCode*397) ^ (Address2 != null ? StringComparer.CurrentCulture.GetHashCode(Address2) : 0);
                hashCode = (hashCode*397) ^ (Address3 != null ? StringComparer.CurrentCulture.GetHashCode(Address3) : 0);
                hashCode = (hashCode*397) ^ AutoBackup.GetHashCode();
                hashCode = (hashCode*397) ^ AutoPrintLabels.GetHashCode();
                hashCode = (hashCode*397) ^ (BackupFilePath != null ? StringComparer.CurrentCulture.GetHashCode(BackupFilePath) : 0);
                hashCode = (hashCode*397) ^ CentreQuarterlyCheckDate.GetHashCode();
                hashCode = (hashCode*397) ^ Created.GetHashCode();
                hashCode = (hashCode*397) ^ IsGV212CheckEnabled.GetHashCode();
                hashCode = (hashCode*397) ^ IsStatusReportCheckEnabled.GetHashCode();
                hashCode = (hashCode*397) ^ (MainEmailAddress != null ? StringComparer.CurrentCulture.GetHashCode(MainEmailAddress) : 0);
                hashCode = (hashCode*397) ^ MonthlyGV212Date.GetHashCode();
                hashCode = (hashCode*397) ^ (Office != null ? StringComparer.CurrentCulture.GetHashCode(Office) : 0);
                hashCode = (hashCode*397) ^ (PhoneNumber != null ? StringComparer.CurrentCulture.GetHashCode(PhoneNumber) : 0);
                hashCode = (hashCode*397) ^ (PostCode != null ? StringComparer.CurrentCulture.GetHashCode(PostCode) : 0);
                hashCode = (hashCode*397) ^ (SecondaryEmailAddress != null ? StringComparer.CurrentCulture.GetHashCode(SecondaryEmailAddress) : 0);
                hashCode = (hashCode*397) ^ (Town != null ? StringComparer.CurrentCulture.GetHashCode(Town) : 0);
                hashCode = (hashCode*397) ^ Uploaded.GetHashCode();
                hashCode = (hashCode*397) ^ UserId;
                hashCode = (hashCode*397) ^ (WorkshopName != null ? StringComparer.CurrentCulture.GetHashCode(WorkshopName) : 0);
                return hashCode;
            }
        }
    }
}