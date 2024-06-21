using BlazorAppEmpty.Components.Pages;
using System.ComponentModel.DataAnnotations;
namespace BlazorAppEmpty.Models
{
	public class KCardModelDB
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int IdColumn { get; set; }
		KColumnModelDB KbColumn { get; set; }
		public int IdUser { get; set; }
		User User { get; set; }
	}
}

