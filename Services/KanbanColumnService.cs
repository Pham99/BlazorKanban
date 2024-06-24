using BlazorAppEmpty.Data;
using BlazorAppEmpty.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BlazorAppEmpty.Services
{

    
    public class KanbanColumnService
    {
        List<KCardModelDB> cardsList = new List<KCardModelDB>();

        //public async Task AddCard(KCardModelDB kanbanCard)
        //{
        //    using (var context = new DatabaseContext())
        //    {
        //        // Načíst sloupec z databáze a přidat kartu
        //        var column = await context.columns.Include(c => c.Cards).FirstOrDefaultAsync(c => c.Id == kanbanCard.IdColumn);
        //        if (column != null)
        //        {
        //            column.Cards.Add(kanbanCard);
        //        }
        //        context.cards.AddAsync(kanbanCard);
        //        await context.SaveChangesAsync();
        //    }
        //}

        //bez erroru, ale nevkládá do db
        public async Task AddCard(KCardModelDB kanbanCard)
        {
            using (var context = new DatabaseContext())
            {
                // Načíst sloupec z databáze
                var column = await context.columns.FirstOrDefaultAsync(c => c.Id == kanbanCard.IdColumn);

                if (column != null)
                {
                    // Zajistit inicializaci seznamu karet, pokud je null
                    if (column.Cards == null)
                    {
                        column.Cards = new List<KCardModelDB>();
                    }

                    // Přidat kartu do seznamu sloupce
                    column.Cards.Add(kanbanCard);

                    // Explicitně přidat kartu do kontextu, pokud není trackována
                    if (!context.Entry(kanbanCard).IsKeySet)
                    {
                        await context.cards.AddAsync(kanbanCard);
                    }

                    // Uložit změny do databáze
                    await context.SaveChangesAsync();
                }
            }
        }

        public void AddCardToList(KCardModelDB kanbanCard)
        {
            cardsList.Add(kanbanCard);
        }

        public List<KCardModelDB> GetCardsList()
        {
            return cardsList;
        }

        public async Task RemoveCard(KCardModelDB kanbanCard)
        {
            using (var context = new DatabaseContext())
            {
                context.cards.Remove(kanbanCard);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<KCardModelDB>> GetCardsForColumn(int columnId)
        {
            using (var context = new DatabaseContext())
            {
                return await context.cards.Where(c => c.IdColumn == columnId).ToListAsync();
            }
        }

        public async Task AddColumn(KColumnModelDB kanbanColumn)
        {
            using (var context = new DatabaseContext())
            {
                await context.columns.AddAsync(kanbanColumn);
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

        public async Task<KColumnModelDB?> GetColumn(int id)
        {
            using (var context = new DatabaseContext())
            {
                return await context.columns.Include(c => c.Cards).SingleOrDefaultAsync(c => c.Id == id);
            }
        }
        public List<KColumnModelDB> GetColumnsSynch()
        {
            using (var context = new DatabaseContext())
            {
                return context.columns.ToList();
            }
        }

        public async Task RemoveColumn(int id)
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
