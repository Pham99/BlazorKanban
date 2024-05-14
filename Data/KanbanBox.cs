using System.Drawing;

namespace BlazorAppEmpty
{
	public class KanbanBox
	{
		private static int IdCount = 0;
		public int Id { get; set; }
		public string? Title { get; set; }
		public string? BoxColor { get; set; }
		public List<KanbanItem> kanbanItems { get; set; } = new List<KanbanItem>();

		public KanbanBox(string title, string color) 
		{
			this.Id = IdCount++;
			Title = title;
			BoxColor = color;
		}
		public void AddItem(string text)
		{
			kanbanItems.Add(new KanbanItem() { Description = text });
		}
	}
}
