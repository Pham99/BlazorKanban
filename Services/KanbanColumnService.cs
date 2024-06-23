using BlazorAppEmpty.Data;
using BlazorAppEmpty.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BlazorAppEmpty.Services
{
	public class KanbanColumnService
	{
		public List<KCardModelDB> Cards { get; set; }

		public async Task AddCardToColumnAsync(KCardModelDB card)
		{
			using ( var _context = new DatabaseContext() )
			{
					_context.cards.Add(card);
					await _context.SaveChangesAsync();
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
		public async Task<List<KColumnModelDB>> GetColumns()
		{
			using (var context = new DatabaseContext())
			{
				return await context.columns.ToListAsync();
			}
		}
		public KColumnModelDB GetColumn(int id) 
		{
			using (var context = new DatabaseContext())
			{
				return context.columns.SingleOrDefault(c => c.Id == id)!;
			}
		}
		public void RemoveColumn(int id)
		{
			using (var context = new DatabaseContext())
			{
				KColumnModelDB item = context.columns.FirstOrDefault(c => c.Id == id)!;

				if (item != null)
				{
					context.Remove(item);
					context.SaveChanges();
				}
			}
		}
	}
}
