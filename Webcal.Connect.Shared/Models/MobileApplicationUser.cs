namespace Connect.Shared.Models
{
    public class MobileApplicationUser
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Thumbprint { get; set; }

        public bool IsAuthorized { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Username) &&
                   !string.IsNullOrEmpty(Thumbprint) &&
                   IsAuthorized;
        }
    }
}