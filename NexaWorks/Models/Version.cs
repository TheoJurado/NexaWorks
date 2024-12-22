using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexaWorks.Models
{
    public class Version
    {
        [Key]
        public int Id { get; set; }
        public string NumVersion { get; set; }


        public int ProductKeyId { get; set; }
        [ForeignKey("ProductKeyId")]
        public Product ProductKey { get; set; }


        public ICollection<Version_OS> AssociatedVersionOS { get; set; }
    }
}
