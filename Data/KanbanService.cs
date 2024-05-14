namespace BlazorAppEmpty.Data
{
    public class KanbanService
    {
        private readonly List<KanbanBox> kanbanBoxes = new List<KanbanBox>();
        public Task<List<KanbanBox>> GetKanbanAsync()
        {
			return Task.FromResult(kanbanBoxes);
        }

        public void AddKanbanColumn(KanbanBox kb)
        {
            kanbanBoxes.Add(kb);
        }
        public KanbanBox GetKanbanBox(int id)
        {
            return kanbanBoxes.SingleOrDefault(obj => obj.Id == id);
        }
        public void RemoveKanbanBox(KanbanBox item)
        {
            kanbanBoxes.Remove(item);
        }
    }
}
