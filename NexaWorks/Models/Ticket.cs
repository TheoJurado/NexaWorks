using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexaWorks.Models
{
    internal class Ticket
    {

        [Key]
        public int Id { get; set; }
        public DateOnly DateCreat { get; set; }
        public string Description { get; set; }
        public bool IsResolved { get; set; } = false;
        public DateOnly? DateResolve { get; set; }
        public string Resolve { get; set; }

        public int VersionKeyId { get; set; }
        [ForeignKey("VersionKeyId")]
        public Version VersionKey { get; set; }

        public int OSUsedId { get; set; }
        [ForeignKey("OSUsedId")]
        public OS OSUsed { get; set; }

    }
}
