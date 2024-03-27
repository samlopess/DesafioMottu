using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesafioMottu.Models
{
    public class RentalModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("MotorcycleId")]
        [Required]
        public int MotorcycleId { get; set; }
        [ForeignKey("DeliveryManId")]
        [Required]
        public int DeliveryManId { get; set; }
        [Required]
        public int Plans { get; set; } // 0 corresponds to 7 days, 1 corresponds to 15 days and 2 corresponds to 40 days
        [Required]
        public DateTime InicialDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public DateTime ExpectedEndDate { get; set; }
        [Required]
        public double Value { get; set; }
    }
}
