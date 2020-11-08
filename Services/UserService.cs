using System.Collections.Generic;
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
        private readonly IUnitOfWork unitOfWork;
        public UserService(IUserRepository userRepository, IUnitOfWork uow)
        {
            this.userRepository = userRepository;
            this.unitOfWork = uow;
        }
        public async Task<UserResponse> AddUserAsync(User user)
        {
            try
            {
                await userRepository.AddUserAsync(user);
                await unitOfWork.CompleteAsync();
                return new UserResponse(user);
            }
            catch (System.Exception ex)
            {
                return new UserResponse($"Cannot add this user: {ex.Message}");
            }
            
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await userRepository.GetAllUsersAsync();
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