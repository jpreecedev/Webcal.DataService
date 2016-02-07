namespace Connect.Shared.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class QCReport : MobileApplicationReport
    {
        [Required]
        [MinLength(3)]
        public string TachoCentreName { get; set; }

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
    }
}