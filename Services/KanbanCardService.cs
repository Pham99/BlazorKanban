using KanbanApp.Data;
using KanbanApp.Models;
using BlazorBootstrap;
using Microsoft.EntityFrameworkCore;

namespace KanbanApp.Services
{
	public class KanbanCardService
	{
        public async Task AddCardAsync(KanbanCardModel kanbanCard, int IdColumn)
        {
            using (var context = new DatabaseContext())
            {
                var column = await context.columns.FirstOrDefaultAsync(col => col.Id == IdColumn);
                if (column != null)
                {
                    column.Cards.Add(kanbanCard);
                }
                await context.SaveChangesAsync();
            }
        }
        public async Task<List<KanbanCardModel>> GetCardsListAsync()
        {
            using (var context = new DatabaseContext())
            {
                return await context.cards.ToListAsync();
            }
        }
        public async Task RemoveCard(KanbanCardModel kanbanCard)
        {
            using (var context = new DatabaseContext())
            {
                context.cards.Remove(kanbanCard);
                await context.SaveChangesAsync();
            }
        }
        public async Task<KanbanCardModel> GetCardByIdAsync(int id)
        {
            using (var context = new DatabaseContext())
            {
                var card = await context.cards.Include(c => c.User).FirstOrDefaultAsync(c => c.Id == id);
                if (card != null)
                {
                    return card;
                }
                return null;
            }
        }
        public async Task MoveCard(int OldId, int DestinationId)
		{
			using (var context = new DatabaseContext())
			{
				var card = await context.cards.FirstOrDefaultAsync(card => card.Id == OldId);
				card.IdColumn = DestinationId;
				await context.SaveChangesAsync();
			}
		}
        public async Task UpdateCard(KanbanCardModel kanbanCard)
        {
            using (var context = new DatabaseContext())
            {
                context.cards.Update(kanbanCard);
                await context.SaveChangesAsync();
            }
        }
		public async Task<List<KanbanCardModel>> GetCardsByColumn(int CardColumnId)
		{
			using (var context = new DatabaseContext())
			{
				List<KanbanCardModel> cards = new List<KanbanCardModel>();
				foreach (KanbanCardModel KanbanCard in context.cards)
				{
					if (KanbanCard.IdColumn == CardColumnId)
					{
						cards.Add(KanbanCard);
					}
				}
				return cards;
			}
		}
	}
}
