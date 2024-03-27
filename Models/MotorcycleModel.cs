using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesafioMottu.Models
{
    public class MotorcycleModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string LicencePlate { get; set; }
        [Required]
        public int MotorcycleAvailable { get; set; } // 0 Motorcycle available, 1 Motorcycle not available
    }
}
