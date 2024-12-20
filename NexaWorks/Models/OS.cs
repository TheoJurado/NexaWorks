using System.ComponentModel.DataAnnotations;

namespace NexaWorks.Models
{
    public class OS
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<Version_OS> AssociatedVersionOS { get; set; }
    }
}
