using KanbanApp.Data;
using KanbanApp.Models;
using Microsoft.EntityFrameworkCore;

namespace KanbanApp.Services
{
    public class UserService
    {
        public UserModel? currentUser { get; set; }

        public async Task AddNewUser(UserModel user)
        {
            using (var context = new DatabaseContext())
            {
                await context.users.AddAsync(user);
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> UserExists(UserModel user)
        {
            using (var context = new DatabaseContext())
            {
                var exists = await context.users.FirstAsync(u => u.Name == user.Name && u.Password == user.Password);
                if(exists == null)
                {
                    return false;
                }
                else
                {
                    currentUser = exists;
                    return true;
                }

            }
        }

        public UserModel GetUser()
        {
            return currentUser;
        }
    }
}
