using BlazorAppEmpty.Data;
using BlazorAppEmpty.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BlazorAppEmpty.Services
{
	public class KanbanColumnService
	{
		public List<KCardModelDB> Cards { get; set; }

		public async Task AddCard(KCardModelDB KanbanCard)
		{
			using (var context = new DatabaseContext())
			{
				await context.cards.AddAsync(KanbanCard);
				await context.SaveChangesAsync();
			}
		}

		public async Task RemoveCard(KCardModelDB KanbanCard)
		{
			using (var context = new DatabaseContext())
			{
				context.cards.Remove(KanbanCard);
				await context.SaveChangesAsync();
			}
		}

		public async Task<List<KCardModelDB>> GetCards()
		{
			using (var context = new DatabaseContext())
			{
				return await context.cards.ToListAsync();
			}
		}

		public async Task AddColumn(KColumnModelDB KanbanColumn)
		{
			using (var context = new DatabaseContext())
			{
				await context.columns.AddAsync(KanbanColumn);
				await context.SaveChangesAsync();
			}
		}
	}
}
