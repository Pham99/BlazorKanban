using KanbanApp.Components.Pages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace KanbanApp.Models
{
	public class KanbanCardModel
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Title { get; set; }
		public string Description { get; set; }
		public int? StoryPoints { get; set; }
		public DateTime? DateComplete { get; set; }
		public int IdColumn { get; set; }
		
		[ForeignKey("IdColumn")]
		public KanbanColumnModel KbColumn { get; set; }

		public int IdUser { get; set; }

		[ForeignKey("IdUser")]
		public UserModel User { get; set; }
	}
}

