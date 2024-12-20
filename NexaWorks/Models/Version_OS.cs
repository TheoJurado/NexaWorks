using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexaWorks.Models
{
    public class Version_OS
    {
        [Key]
        public int Id { get; set; }



        public int VersionKeyId { get; set; }
        [ForeignKey("VersionKeyId")]
        public NexaWorks.Models.Version VersionKey { get; set; }

        public int OSKeyId { get; set; }
        [ForeignKey("OSKeyId")]
        public OS OSKey { get; set; }


        public ICollection<Ticket> Tickets { get; set; }
    }
}
