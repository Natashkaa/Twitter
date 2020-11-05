using System.Threading.Tasks;
using Twitter.Domain.Communication;
using Twitter.Domain.Models;
using Twitter.Domain.Repositories;
using Twitter.Domain.Services;

namespace Twitter.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public Task<UserResponse> AddUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserResponse> GetUserAsync(int id)
        {
            var user = await userRepository.GetUserAsync(id);
            if(user == null){
                return new UserResponse($"Cannot find user with id {id}");
            }
            return new UserResponse(user);
        }
    }
}