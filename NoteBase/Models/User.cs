namespace NoteBase.Models
{
    public class User
    {
        public int ID = 0;
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int FailedLoginAttempts = 0;
    }
}
