namespace Connect.Shared.Models
{
    public class LinkedVehicle : BaseModel
    {
        public string VehicleRegistrationNumber { get; set; }
        public CustomerContact CustomerContact { get; set; }
    }
}