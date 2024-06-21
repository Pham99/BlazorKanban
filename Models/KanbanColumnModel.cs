
namespace BlazorAppEmpty.Models
{
    public class KanbanColumnModel
    {
        private static int IdCount = 1;
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? BoxColor { get; set; }
        public List<KanbanCardModel> Cards { get; set; } = new List<KanbanCardModel>();

        public KanbanColumnModel(string title, string color)
        {
            Id = IdCount++;
            Title = title;
            BoxColor = color;
        }
    }
}
