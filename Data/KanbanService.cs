namespace BlazorAppEmpty.Data
{
    public class KanbanService
    {
        public List<KanbanColumnModel> kanbanColumns = new List<KanbanColumnModel>();
        public Task<List<KanbanColumnModel>> GetKanbanAsync()
        {
			return Task.FromResult(kanbanColumns);
        }
    }
}
