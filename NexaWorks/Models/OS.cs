using System.ComponentModel.DataAnnotations;

namespace NexaWorks.Models
{
    internal class OS
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
