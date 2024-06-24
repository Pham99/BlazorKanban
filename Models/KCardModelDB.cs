using BlazorAppEmpty.Components.Pages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BlazorAppEmpty.Models
{
	public class KCardModelDB
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
		public KColumnModelDB KbColumn { get; set; }

		public int IdUser { get; set; }

		[ForeignKey("IdUser")]
		public User User { get; set; }
	}
}

