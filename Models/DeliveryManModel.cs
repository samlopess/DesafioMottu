using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesafioMottu.Models
{
    public class DeliveryManModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Cnpj { get; set; }
        [Required]
        public int LicenceNumber { get; set; }
        [Required]
        public string TypeLicence { get; set; }
        [NotMapped] 
        public string ImageLicenceBase64 { get; set; }
        [Required]
        public string ImageLicence { get; set; }
        public int ActiveRental { get; set; } // 0 - No, 1 - Yes
    }
}
