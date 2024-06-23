using BlazorAppEmpty.Data;
using BlazorAppEmpty.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppEmpty.Services
{
    public class UserService
    {
        public User? currentUser { get; set; }

        public async Task AddNewUser(User user)
        {
            using (var context = new DatabaseContext())
            {
                await context.users.AddAsync(user);
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> UserExists(User user)
        {
            using (var context = new DatabaseContext())
            {
                bool exists = await context.users.AnyAsync(u => u.Name == user.Name && u.Password == user.Password);
                return exists;
            }
        }

        public User GetUser()
        {
            return currentUser;
        }
    }
}
