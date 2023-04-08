using NoteBase.Interface;
using NoteBase.Models;
using System.Net.Mail;

namespace NoteBase.Services
{
    public class UserService : IUserService
    {

        public static User[] UserData = new User[10];
        public static Note[] NoteData = new Note[10];

        public static User NowUser;
        public static bool LogIn;
        public static int counter = 0, counter1 = 0;

        public string UserAdd(User user)
        {
            UserData[counter] = new User();
            UserData[counter].ID = counter;
            UserData[counter].Username = user.Username;
            UserData[counter].Email = user.Email;
            UserData[counter].Password = user.Password;
            counter++;
            return "Register succsesful";
        }

        public string UserLogin(User user)
        {
            foreach (User v in UserData)
            {
                if (v.Email == user.Email)
                {
                    if (v.Password == user.Password)
                    {
                        NowUser = new User();
                        NowUser.ID = user.ID;
                        NowUser.Username = user.Username;
                        NowUser.Email = user.Email;
                        NowUser.Password = user.Password;
                        LogIn = true;
                        return "Logged in succesfully";
                    }
                    else
                    {
                        if(v.FailedLoginAttempts == 2)
                        {
                            v.FailedLoginAttempts++;
                            using (MailMessage mail = new MailMessage())
                            {
                                Random ran = new Random();
                                mail.From = new MailAddress("sabaliluashvili@mziuri.ge");
                                mail.To.Add(user.Email);
                                mail.Subject = "are you trying to log in your account";
                                mail.Body = "someone is trying to log into your account. Is this you?";
                                mail.IsBodyHtml = true;
                                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                                {
                                    smtp.Credentials = new System.Net.NetworkCredential("sabaliluashvili@mziuri.ge", "MZIURI2015");
                                    smtp.EnableSsl = true;
                                    smtp.Send(mail);
                                    return "sheamowmet meili";
                                }
                                return "eseti meili ar arsebobs";
                            }
                        }
                        v.FailedLoginAttempts++;
                        return "wrong password";
                    }
                }
                else
                {
                    return "wrong email";
                }
            }
            return "No Users in base";
        }

        public string AddNote(Note note)
        {
            if(LogIn == true)
            {
                NoteData[counter1] = new Note();
                NoteData[counter1].Id = counter1;
                NoteData[counter1].Content = note.Content;
                NoteData[counter1].Title = note.Title;
                NoteData[counter1].UserID = NowUser.ID;

                return "Note Added succsesfully";
            }
            else if( LogIn == false)
            {
                return "you are not logged in";
            }
            else
            {
                return "error";
            }
        }
    }
}

