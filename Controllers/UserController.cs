using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Twitter.Domain.Communication;
using Twitter.Domain.Models;
using Twitter.Domain.Services;
using Twitter.Extensions;
using Twitter.Resources;

namespace Twitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }
        
        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await userService.GetUserAsync(id);
            var resource = mapper.Map<User, UserResource>(response.User);
            var res = response.GetResponseResult(resource);
            return Ok(res);
        }

        // POST api/user
        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody] SaveUserResource newUser)
        {
            //here need to check user email using regexp
            string regExpForemail = @"^("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+\=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@)(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17})$";
            if(!Regex.IsMatch(newUser.User_Email, regExpForemail, RegexOptions.IgnoreCase))
            {
                Console.WriteLine("user email is " + newUser.User_Email);
                var errorResponse = new UserResponse("Invalid Email");
                var mapperUser = mapper.Map<User, UserResource>(errorResponse.User);
                var res = errorResponse.GetResponseResult(mapperUser);
                return Ok(res);
            }
            //
            var user = mapper.Map<SaveUserResource, User>(newUser);
            user.Birth = Convert.ToDateTime(newUser.Birth);
            user.Registration_date = DateTime.Now;

            var response = await userService.AddUserAsync(user);
            
            var userResource = mapper.Map<User, UserResource>(response.User);
            var result = response.GetResponseResult(userResource);
            return Ok(result);
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
