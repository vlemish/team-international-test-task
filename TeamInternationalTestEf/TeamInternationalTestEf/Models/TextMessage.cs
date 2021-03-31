using System;

namespace TeamInternationalTestEf.Models
{
    public class TextMessage : UserMessage
    {
        public string Content { get; set; }


        public TextMessage()
        {

        }

        public TextMessage(DateTime creationTime, int userId, string content)
            : base(creationTime, userId)
        {
            Content = content;
        }
    }
}
