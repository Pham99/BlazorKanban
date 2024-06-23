using BlazorAppEmpty.Components.Pages;
using System.ComponentModel.DataAnnotations;

namespace BlazorAppEmpty.Models
{
	public class KColumnModelDB
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public List<KCardModelDB> Cards { get; set; } = new();

		public KColumnModelDB(string Name) 
		{
			this.Name = Name;
		}
	}
}
