using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Connect.Shared.Models
{
    [Table("SerializedData")]
    public class SerializedData
    {
        public int Id { get; set; }

        public int DocumentId { get; set; }

        public string DocumentType { get; set; }

        [MaxLength]
        public byte[] Data { get; set; }
    }
}
