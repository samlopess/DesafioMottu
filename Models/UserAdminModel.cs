using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesafioMottu.Models
{
    public class UserAdminModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public int Password { get; set; }
        [Required]
        public int Name { get; set; }
    }
}
