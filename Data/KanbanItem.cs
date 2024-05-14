namespace BlazorAppEmpty
{
	public class KanbanItem
	{
		public string? Title { get; set; }
		public string? Description { get; set; }
		public DateOnly? DateCreated { get; set; }
		public DateOnly? Deadline { get; set; }
	}
}
