using Microsoft.AspNetCore.Mvc;
using NoteBase.Models;
using NoteBase.Interface;

namespace NoteBase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserLoginController : ControllerBase
    {
        private IUserService _userService;
        public UserLoginController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet(Name = "LoginUser")]
        public string UserLogin([FromQuery] User user) => _userService.UserLogin(user);
    }
}
