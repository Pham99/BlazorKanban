using BlazorAppEmpty.Data;
using BlazorAppEmpty.Models;

namespace BlazorAppEmpty.Services
{
	public class UserService
	{
		public async Task AddNewUser(User user)
		{
			using(var context = new DatabaseContext())
			{
				await context.users.AddAsync(user);
				await context.SaveChangesAsync();
			}
		}
	}
}
