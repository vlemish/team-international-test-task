using System.Collections.Generic;

namespace TeamInternationalTestEf.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public virtual ICollection<FileMessage> FileMessages { get; set; }

        public virtual ICollection<TextMessage> TextMessages { get; set; }


        public User()
        {

        }

        public User(string firstName, string lastName, string username, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
        }
    }
}