using Microsoft.AspNetCore.Mvc;
using NoteBase.Models;
using NoteBase.Interface;

namespace NoteBase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet(Name ="RegisterUser")]
        public string UserAdd([FromQuery] User user) => _userService.UserAdd(user);
     }
}
