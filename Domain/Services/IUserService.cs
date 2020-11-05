using System.Threading.Tasks;
using Twitter.Domain.Communication;
using Twitter.Domain.Models;

namespace Twitter.Domain.Services
{
    public interface IUserService
    {
         Task<UserResponse> GetUserAsync(int id);
         Task<UserResponse> AddUserAsync(User user);
    }
}