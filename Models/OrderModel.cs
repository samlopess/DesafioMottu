using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesafioMottu.Models
{
    public class OrderModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public int Value { get; set; }
        [Required]
        public string Situation { get; set; }
        [ForeignKey("DeliveryManId")]
        [Required]
        public int DeliveryManId { get; set; }
    }
}
