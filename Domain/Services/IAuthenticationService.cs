using System.Threading.Tasks;
using Twitter.Domain.Communication;

namespace Twitter.Domain.Services
{
    public interface IAuthenticationService
    {
         Task<UserResponse> AuthenticateAsync(string login, string password);
    }
}