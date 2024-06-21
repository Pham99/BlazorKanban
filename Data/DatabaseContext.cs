using BlazorAppEmpty.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppEmpty.Data
{
    public class DatabaseContext: DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite(@"Data Source=DataBase\KanbanDB.db");

		public DbSet<User> users { get; set; }
		public DbSet<KColumnModelDB> columns { get; set; }
		public DbSet<KCardModelDB> cards { get; set; }
	}
}
