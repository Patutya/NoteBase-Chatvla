using Microsoft.AspNetCore.Mvc;
using NoteBase.Models;
using NoteBase.Interface;

namespace NoteBase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        private IUserService _userService;

        public NoteController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet(Name = "AddNotes")]
        public string AddNote([FromQuery] Note note) => _userService.AddNote(note);
    }
}
