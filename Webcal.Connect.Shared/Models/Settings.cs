namespace Connect.Shared.Models
{
    public class Settings : BaseModel
    {
        public string CalibrationsDueReportTemplate { get; set; }

        public string RecentCalibrationsReportTemplate { get; set; }
    }
}