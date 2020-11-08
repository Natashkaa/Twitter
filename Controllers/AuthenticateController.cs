using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Twitter.Domain.Models;
using Twitter.Domain.Services;
using Twitter.Extensions;
using Twitter.Resources;

namespace Twitter.Controllers
{
    [Route("/api/[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAuthenticationService authService;
        public AuthenticateController(IMapper mapper, IAuthenticationService authService)
        {
            this.mapper = mapper;
            this.authService = authService;
        }

        [HttpPost("auth")]
        public async Task<IActionResult> Authenticate([FromBody] User user)
        {
            var response = await authService.AuthenticateAsync(user.User_login, user.User_password);
            var resource = mapper.Map<User, UserResource>(response.User);
            var res = response.GetResponseResult(resource);
            return Ok(res);
        }
    }
}