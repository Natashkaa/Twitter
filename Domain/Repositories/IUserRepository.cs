using System.Collections.Generic;
using System.Threading.Tasks;
using Twitter.Domain.Models;

namespace Twitter.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
         Task<User> GetUserAsync(int id);
         Task AddUserAsync(User user);
    }
}