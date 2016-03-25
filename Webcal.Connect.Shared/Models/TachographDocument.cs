namespace Connect.Shared.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Xml.Serialization;
    using Properties;

    [Serializable]
    public class TachographDocument : Document, IEquatable<TachographDocument>
    {
        [XmlIgnore, NotMapped]
        public override bool IsNew
        {
            get
            {
                return string.IsNullOrEmpty(RegistrationNumber) &&
                       string.IsNullOrEmpty(VIN) &&
                       string.IsNullOrEmpty(VehicleMake) &&
                       string.IsNullOrEmpty(VehicleModel) &&
                       string.IsNullOrEmpty(TyreSize) &&
                       string.IsNullOrEmpty(WFactor) &&
                       string.IsNullOrEmpty(KFactor) &&
                       string.IsNullOrEmpty(LFactor);
            }
        }

        public string VIN { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string TyreSize { get; set; }
        public string VehicleType { get; set; }
        public string WFactor { get; set; }
        public string KFactor { get; set; }
        public string LFactor { get; set; }
        public string OdometerReading { get; set; }
        public bool Tampered { get; set; }
        public string InvoiceNumber { get; set; }
        public string InspectionInfo { get; set; }
        public bool TachographHasAdapter { get; set; }
        public string TachographAdapterSerialNumber { get; set; }
        public string TachographAdapterLocation { get; set; }
        public string TachographCableColor { get; set; }
        public string MinorWorkDetails { get; set; }
        public string TachographType { get; set; }
        public string CardSerialNumber { get; set; }
        public DateTime? CalibrationTime { get; set; }
        public bool IsDigital { get; set; }
        public bool NewBattery { get; set; }
        public bool IsQCCheck { get; set; }

        [NotMapped, XmlIgnore]
        public string NewInspectionInfo { get; set; }


        public void Convert(CalibrationRecord calibrationRecord)
        {
            if (calibrationRecord == null)
            {
                return;
            }

            VIN = calibrationRecord.VehicleIdentificationNumber;
            KFactor = calibrationRecord.KFactor;
            WFactor = calibrationRecord.WFactor;
            RegistrationNumber = calibrationRecord.VehicleRegistrationNumber;
            OdometerReading = calibrationRecord.OdometerValue;
            TyreSize = calibrationRecord.TyreSize;
            LFactor = calibrationRecord.TyreCircumference;
            TachographMake = calibrationRecord.TachographManufacturer;
            SerialNumber = calibrationRecord.VuSerialNumber;
            CardSerialNumber = calibrationRecord.CardSerialNumber;
            CalibrationTime = calibrationRecord.CalibrationTime;
        }

        protected override void OnDocumentTypeChanged(string newValue)
        {
            if (IsNew && IsDigital && string.Equals(DocumentType, Resources.TXT_MINOR_WORK_DETAILS) && string.IsNullOrEmpty(MinorWorkDetails))
            {
                MinorWorkDetails = Resources.TXT_ACTIVITY_MODE_CHANGE;
            }
        }

        public bool Equals(TachographDocument other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && string.Equals(VIN, other.VIN) && string.Equals(VehicleMake, other.VehicleMake) && string.Equals(VehicleModel, other.VehicleModel) && string.Equals(TyreSize, other.TyreSize) && string.Equals(VehicleType, other.VehicleType) && string.Equals(WFactor, other.WFactor) && string.Equals(KFactor, other.KFactor) && string.Equals(LFactor, other.LFactor) && string.Equals(OdometerReading, other.OdometerReading) && Tampered == other.Tampered && string.Equals(InvoiceNumber, other.InvoiceNumber) && string.Equals(InspectionInfo, other.InspectionInfo) && TachographHasAdapter == other.TachographHasAdapter && string.Equals(TachographAdapterSerialNumber, other.TachographAdapterSerialNumber) && string.Equals(TachographAdapterLocation, other.TachographAdapterLocation) && string.Equals(TachographCableColor, other.TachographCableColor) && string.Equals(MinorWorkDetails, other.MinorWorkDetails) && string.Equals(TachographType, other.TachographType) && string.Equals(CardSerialNumber, other.CardSerialNumber) && CalibrationTime.Equals(other.CalibrationTime) && IsDigital == other.IsDigital && NewBattery == other.NewBattery && string.Equals(NewInspectionInfo, other.NewInspectionInfo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TachographDocument)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (VIN != null ? VIN.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (VehicleMake != null ? VehicleMake.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (VehicleModel != null ? VehicleModel.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TyreSize != null ? TyreSize.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (VehicleType != null ? VehicleType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (WFactor != null ? WFactor.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (KFactor != null ? KFactor.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LFactor != null ? LFactor.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OdometerReading != null ? OdometerReading.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Tampered.GetHashCode();
                hashCode = (hashCode * 397) ^ (InvoiceNumber != null ? InvoiceNumber.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (InspectionInfo != null ? InspectionInfo.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ TachographHasAdapter.GetHashCode();
                hashCode = (hashCode * 397) ^ (TachographAdapterSerialNumber != null ? TachographAdapterSerialNumber.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TachographAdapterLocation != null ? TachographAdapterLocation.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TachographCableColor != null ? TachographCableColor.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (MinorWorkDetails != null ? MinorWorkDetails.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TachographType != null ? TachographType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CardSerialNumber != null ? CardSerialNumber.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CalibrationTime.GetHashCode();
                hashCode = (hashCode * 397) ^ IsDigital.GetHashCode();
                hashCode = (hashCode * 397) ^ NewBattery.GetHashCode();
                hashCode = (hashCode * 397) ^ (NewInspectionInfo != null ? NewInspectionInfo.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}