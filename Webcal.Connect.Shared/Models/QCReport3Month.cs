namespace Connect.Shared.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class QCReport3Month : MobileApplicationReport
    {
        [Required]
        [MinLength(3)]
        public string CentreName { get; set; }

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
    }
}