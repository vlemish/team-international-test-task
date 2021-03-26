using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TeamInternationalTestEf.Models
{
    [NotMapped]
    public abstract class UserMessage
    {
        public int Id { get; set; }

        public DateTime TimeCreated { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
