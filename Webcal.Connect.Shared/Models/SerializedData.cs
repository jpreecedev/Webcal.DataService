using System.ComponentModel.DataAnnotations;

namespace Connect.Shared.Models
{
    public class SerializedData
    {
        public int Id { get; set; }

        public int DocumentId { get; set; }

        public string DocumentType { get; set; }

        [MaxLength]
        public byte[] Data { get; set; }
    }
}
