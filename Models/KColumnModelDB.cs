using BlazorAppEmpty.Components.Pages;
using System.ComponentModel.DataAnnotations;

namespace BlazorAppEmpty.Models
{
	public class KColumnModelDB
	{
		[Key]
		public int Id { get; set; }
		public int Name { get; set; }
		List<KCardModelDB> Cards { get; set; }
	}
}
