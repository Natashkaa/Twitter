using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Twitter.Domain.Models;
using Twitter.Domain.Repositories;

namespace Twitter.RealizationAndContext.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(TwitterDbContext context) : base(context)
        {}
        public async Task AddUserAsync(User user)
        {
            await context.Users.AddAsync(user);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await context.Users.FirstOrDefaultAsync(user => user.Id == id);
        }
    }
}