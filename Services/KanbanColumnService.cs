using KanbanApp.Data;
using KanbanApp.Models;
using Microsoft.EntityFrameworkCore;

namespace KanbanApp.Services
{
    public class KanbanColumnService
    {
        public async Task<List<KanbanCardModel>> GetCardsByColumnIdAsync(int columnId)
        {
            using (var context = new DatabaseContext())
            {
                return await context.cards.Include(c => c.User).Where(c => c.IdColumn == columnId).ToListAsync();
            }
        }

        public async Task AddColumnAsync(KanbanColumnModel kanbanColumn)
        {
            using (var context = new DatabaseContext())
            {
                await context.columns.AddAsync(kanbanColumn);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<KanbanColumnModel>> GetColumnsAsync()
        {
            using (var context = new DatabaseContext())
            {
                return await context.columns.Include(c => c.Cards).ThenInclude(c => c.User).ToListAsync();
            }
        }

        public async Task<KanbanColumnModel?> GetColumnAsync(int id)
        {
            using (var context = new DatabaseContext())
            {
                return await context.columns.Include(c => c.Cards).SingleOrDefaultAsync(c => c.Id == id);
            }
        }

        public async Task RemoveColumnAsync(int id)
        {
            using (var context = new DatabaseContext())
            {
                var item = await context.columns.FirstOrDefaultAsync(c => c.Id == id);
                if (item != null)
                {
                    context.Remove(item);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
