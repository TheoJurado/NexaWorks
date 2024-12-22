using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexaWorks.Models
{
    public class Ticket
    {

        [Key]
        public int Id { get; set; }
        public DateOnly DateCreat { get; set; }
        public string Description { get; set; }
        public bool IsResolved { get; set; } = false;
        public DateOnly? DateResolve { get; set; }
        public string? ResolveDescription { get; set; }


        public int AssociatedVersionOSId { get; set; }
        [ForeignKey("AssociatedVersionOSId")]
        public Version_OS AssociatedVersionOSKey { get; set; }
    }
}
