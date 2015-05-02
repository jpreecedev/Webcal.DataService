namespace Connect.Shared.Models
{
    using System;

    public class TachoFleetEmail : BaseModel, IConnectEmail
    {
        public string EmailType { get; set; }

        public ConnectUser User { get; set; }
        
        public string Subject { get; set; }

        public string Body { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }
    }
}