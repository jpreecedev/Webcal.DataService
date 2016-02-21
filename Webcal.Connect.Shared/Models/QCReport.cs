namespace Connect.Shared.Models
{
    using System;

    public class QCReport : BaseReport, IEquatable<QCReport>
    {
        public string TachoCentreLine1 { get; set; }

        public string TachoCentreLine2 { get; set; }

        public string TachoCentreLine3 { get; set; }

        public string TachoCentreCity { get; set; }

        public string TachoCentrePostCode { get; set; }

        public string TachoManagerName { get; set; }

        public string QCManagerName { get; set; }

        public string TechnicianName { get; set; }

        public DateTime DateOfAudit { get; set; }

        public string TypeOfTachographCheck { get; set; }

        public string TachographMake { get; set; }

        public string TachographModel { get; set; }

        public string TachographSerialNumber { get; set; }

        public string VehicleMake { get; set; }

        public string VehicleType { get; set; }

        public string VehicleRegistrationNumber { get; set; }

        public string VehicleIdentificationNumber { get; set; }

        public bool ThreeBasicChecksCompleted { get; set; }

        public int? WFactor { get; set; }

        public int? LFactor { get; set; }

        public int? KFactor { get; set; }

        public string FortyKmTest { get; set; }

        public string SixtyKmTest { get; set; }

        public bool? ClockTestCompleted { get; set; }

        public bool? BenchTestCarriedOutAnalogue { get; set; }

        public bool? FunctionalBenchTestDigital { get; set; }

        public bool? DistanceCheckCarriedOut { get; set; }

        public bool? TestChartsCompleted { get; set; }

        public bool? SpeedForSpeedCheckCompleted { get; set; }

        public bool SystemSealedInAccordance { get; set; }

        public bool CalibrationCertificateCompleted { get; set; }

        public bool? ReferenceCableCheckCompleted { get; set; }

        public bool? TechnicalDataPrintoutsCreated { get; set; }

        public bool? EventsFaultsReadCleared { get; set; }

        public string Comments { get; set; }

        public bool Passed { get; set; }

        public bool Equals(QCReport other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return BenchTestCarriedOutAnalogue == other.BenchTestCarriedOutAnalogue && CalibrationCertificateCompleted == other.CalibrationCertificateCompleted && ClockTestCompleted == other.ClockTestCompleted && string.Equals(Comments, other.Comments) && DateOfAudit.Equals(other.DateOfAudit) && DistanceCheckCarriedOut == other.DistanceCheckCarriedOut && EventsFaultsReadCleared == other.EventsFaultsReadCleared && string.Equals(FortyKmTest, other.FortyKmTest) && FunctionalBenchTestDigital == other.FunctionalBenchTestDigital && KFactor == other.KFactor && LFactor == other.LFactor && Passed == other.Passed && string.Equals(QCManagerName, other.QCManagerName) && ReferenceCableCheckCompleted == other.ReferenceCableCheckCompleted && string.Equals(SixtyKmTest, other.SixtyKmTest) && SpeedForSpeedCheckCompleted == other.SpeedForSpeedCheckCompleted && SystemSealedInAccordance == other.SystemSealedInAccordance && string.Equals(TachoCentreCity, other.TachoCentreCity) && string.Equals(TachoCentreLine1, other.TachoCentreLine1) && string.Equals(TachoCentreLine2, other.TachoCentreLine2) && string.Equals(TachoCentreLine3, other.TachoCentreLine3) && string.Equals(TachoCentrePostCode, other.TachoCentrePostCode) && string.Equals(TachographMake, other.TachographMake) && string.Equals(TachographModel, other.TachographModel) && string.Equals(TachographSerialNumber, other.TachographSerialNumber) && string.Equals(TachoManagerName, other.TachoManagerName) && TechnicalDataPrintoutsCreated == other.TechnicalDataPrintoutsCreated && string.Equals(TechnicianName, other.TechnicianName) && TestChartsCompleted == other.TestChartsCompleted && ThreeBasicChecksCompleted == other.ThreeBasicChecksCompleted && string.Equals(TypeOfTachographCheck, other.TypeOfTachographCheck) && string.Equals(VehicleIdentificationNumber, other.VehicleIdentificationNumber) && string.Equals(VehicleMake, other.VehicleMake) && string.Equals(VehicleRegistrationNumber, other.VehicleRegistrationNumber) && string.Equals(VehicleType, other.VehicleType) && WFactor == other.WFactor;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((QCReport)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = BenchTestCarriedOutAnalogue.GetHashCode();
                hashCode = (hashCode * 397) ^ CalibrationCertificateCompleted.GetHashCode();
                hashCode = (hashCode * 397) ^ ClockTestCompleted.GetHashCode();
                hashCode = (hashCode * 397) ^ (Comments != null ? Comments.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ DateOfAudit.GetHashCode();
                hashCode = (hashCode * 397) ^ DistanceCheckCarriedOut.GetHashCode();
                hashCode = (hashCode * 397) ^ EventsFaultsReadCleared.GetHashCode();
                hashCode = (hashCode * 397) ^ (FortyKmTest != null ? FortyKmTest.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ FunctionalBenchTestDigital.GetHashCode();
                hashCode = (hashCode * 397) ^ KFactor.GetHashCode();
                hashCode = (hashCode * 397) ^ LFactor.GetHashCode();
                hashCode = (hashCode * 397) ^ Passed.GetHashCode();
                hashCode = (hashCode * 397) ^ (QCManagerName != null ? QCManagerName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ReferenceCableCheckCompleted.GetHashCode();
                hashCode = (hashCode * 397) ^ (SixtyKmTest != null ? SixtyKmTest.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ SpeedForSpeedCheckCompleted.GetHashCode();
                hashCode = (hashCode * 397) ^ SystemSealedInAccordance.GetHashCode();
                hashCode = (hashCode * 397) ^ (TachoCentreCity != null ? TachoCentreCity.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TachoCentreLine1 != null ? TachoCentreLine1.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TachoCentreLine2 != null ? TachoCentreLine2.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TachoCentreLine3 != null ? TachoCentreLine3.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TachoCentrePostCode != null ? TachoCentrePostCode.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TachographMake != null ? TachographMake.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TachographModel != null ? TachographModel.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TachographSerialNumber != null ? TachographSerialNumber.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TachoManagerName != null ? TachoManagerName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ TechnicalDataPrintoutsCreated.GetHashCode();
                hashCode = (hashCode * 397) ^ (TechnicianName != null ? TechnicianName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ TestChartsCompleted.GetHashCode();
                hashCode = (hashCode * 397) ^ ThreeBasicChecksCompleted.GetHashCode();
                hashCode = (hashCode * 397) ^ (TypeOfTachographCheck != null ? TypeOfTachographCheck.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (VehicleIdentificationNumber != null ? VehicleIdentificationNumber.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (VehicleMake != null ? VehicleMake.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (VehicleRegistrationNumber != null ? VehicleRegistrationNumber.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (VehicleType != null ? VehicleType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ WFactor.GetHashCode();
                return hashCode;
            }
        }
    }
}