namespace Connect.Shared.Models
{
    public abstract class MobileApplicationReport
    {
        public int Id { get; set; }

        public MobileDocumentType MobileDocumentType { get; set; }

        public MobileApplicationUser User { get; set; }
    }
}