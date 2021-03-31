using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamInternationalTestEf.Models
{
    [NotMapped]
    public abstract class UserMessage
    {
        public int Id { get; set; }

        public DateTime CreationTime { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }


        public UserMessage()
        {

        }

        public UserMessage(DateTime creationTime, int userId)
        {
            CreationTime = creationTime;
            UserId = userId;
        }
    }
}
