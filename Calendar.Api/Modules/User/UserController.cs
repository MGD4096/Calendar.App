using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Application.Contracts;
using User.Application.Users;
using User.Application.Users.CreateUserCommand;
using User.Application.Users.GetUserQuery;

namespace Calendar.Api.Modules.User
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserModule _userModule;

        public UserController(IUserModule userModule)
        {
            _userModule = userModule;
        }
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Register([FromForm]AddUserRequest request)
        {
            await _userModule.ExecuteCommandAsync(new CreateUserCommand(
                request.UserName,
                request.ForName,
                request.SurName,
                request.Password
                ));
            return Ok();
        }
        [HttpPost("")]
        [ProducesResponseType(typeof(UserDto),StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromForm]LoginRequest request)
        {
            var user=await _userModule.ExecuteQueryAsync(new GetUserQuery(
                request.UserName,
                request.Password
                ));
            return Ok(user);
        }
    }
}
