using System.Collections.Generic;
using System.Threading.Tasks;
using Twitter.Domain.Communication;
using Twitter.Domain.Models;

namespace Twitter.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
         Task<UserResponse> GetUserAsync(int id);
         Task<UserResponse> AddUserAsync(User user);
    }
}