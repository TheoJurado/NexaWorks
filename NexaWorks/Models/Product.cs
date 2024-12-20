using System.ComponentModel.DataAnnotations;

namespace NexaWorks.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Version> Versions { get; set; }
    }
}
