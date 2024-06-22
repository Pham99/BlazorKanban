using BlazorAppEmpty.Data;
using BlazorAppEmpty.Models;
using BlazorBootstrap;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppEmpty.Services
{
	public class KanbanCardService
	{
		public async Task MoveCard(int OldId, int DestinationId)
		{
			using (var context = new DatabaseContext())
			{
				var card = await context.cards.FirstOrDefaultAsync(card => card.Id == OldId);
				card.Id = DestinationId;
				await context.SaveChangesAsync();
			}
		}

		public async Task<List<KCardModelDB>> GetCardsByColumn(int CardColumnId)
		{
			using (var context = new DatabaseContext())
			{
				List<KCardModelDB> cards = new List<KCardModelDB>();
				foreach (KCardModelDB KanbanCard in context.cards)
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
