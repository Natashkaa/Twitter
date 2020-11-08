using System;
using System.Linq;
using System.Threading.Tasks;
using Twitter.Domain.Communication;
using Microsoft.Extensions.Options;
using Twitter.Domain.Models;
using Twitter.Domain.Repositories;
using Twitter.Domain.Services;
using Twitter.Extensions;

namespace Twitter.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository userRepository;
        private readonly AppSettings appSettings;
        public AuthenticationService(IOptions<AppSettings> settings, IUserRepository repo)
        {
            this.appSettings = settings.Value;
            this.userRepository = repo;
        }
        public async Task<UserResponse> AuthenticateAsync(string login, string password)
        {
            User user = (await userRepository.GetAllUsersAsync())
                                             .SingleOrDefault(u => u.User_login == login);
            if(user == null)
            {
                return new UserResponse("Incorrect email.");
            }
            else{
                if(user.User_password != password)
                {
                    return new UserResponse("Incorrect password.");
                }
                try
                {
                    user.GenerateTokenString(appSettings.Secret, appSettings.TokenExpires);
                    user.User_password = null;
                    return new UserResponse(user);
                }
                catch(Exception ex)
                {
                    return new UserResponse($"Something happen on server side: {ex.Message}");
                }
            }
            
        }
    }
}