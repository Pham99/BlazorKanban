using System.Drawing;

namespace BlazorAppEmpty
{
	public class KanbanBox
	{
		public string? Title { get; set; }
		public string? BoxColor { get; set; }
		public List<KanbanItem> kanbanItems { get; set; } = new List<KanbanItem>();

		public void AddItem(string text)
		{
			kanbanItems.Add(new KanbanItem() { Description = text });
		}
	}
}
