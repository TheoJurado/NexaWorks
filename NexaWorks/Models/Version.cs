using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexaWorks.Models
{
    internal class Version
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int ProduitKeyId { get; set; }
        [ForeignKey("ProduitKeyId")]
        public Produit ProduitKey { get; set; }

        public ICollection<OS> OSs { get; set; }
    }
}
