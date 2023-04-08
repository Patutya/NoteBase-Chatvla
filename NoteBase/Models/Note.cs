namespace NoteBase.Models
{
    public class Note
    {
        public int Id = 0;
        public int UserID = 0;
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
