using NoteBase.Models;

namespace NoteBase.Interface
{
    public interface IUserService
    {
        string UserAdd(User user);
        string UserLogin(User user);
        string AddNote (Note note);
    }
}
