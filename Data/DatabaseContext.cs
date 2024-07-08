using KanbanApp.Models;
using Microsoft.EntityFrameworkCore;

namespace KanbanApp.Data
{
    public class DatabaseContext: DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite(@"Data Source=DataBase\KanbanDB.db");

		public DbSet<UserModel> users { get; set; }
		public DbSet<KanbanColumnModel> columns { get; set; }
		public DbSet<KanbanCardModel> cards { get; set; }
	}
}
