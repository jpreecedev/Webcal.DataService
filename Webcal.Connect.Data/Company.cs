namespace Webcal.Connect.Data
{
    using Shared.Models;

    public class Company : BaseModel
    {
        public string Key { get; set; }

        public bool IsAuthorized { get; set; }
    }
}