using BlazorAppEmpty.Components.Pages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BlazorAppEmpty.Models
{
	public class KCardModelDB
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }

		[ForeignKey("IdColumn")]
		public int IdColumn { get; set; }
		KColumnModelDB KbColumn { get; set; }

		[ForeignKey("IdUser")]
		public int IdUser { get; set; }
	}
}

