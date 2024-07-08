using KanbanApp.Components.Pages;
using System.ComponentModel.DataAnnotations;

namespace KanbanApp.Models
{
	public class KanbanColumnModel
	{
		[Key]
		public int Id { get; set; }
		
		[Required]
		public string Name { get; set; }
		
		public List<KanbanCardModel> Cards { get; set; } = new();
	}
}
