using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace KanbanApp.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Musí tam být jméno!")]
        [StringLength(50)]
        public string Name { get; set; }
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        public List<KanbanCardModel> Cards { get; set; } = new List<KanbanCardModel>();
    }
}
