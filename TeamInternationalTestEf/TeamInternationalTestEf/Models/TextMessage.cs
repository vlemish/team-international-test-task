using System;

namespace TeamInternationalTestEf.Models
{
    public class TextMessage : UserMessage
    {
        public string Content { get; set; }


        public TextMessage()
        {

        }

        public TextMessage(DateTime timeCreated, bool isSavedMessage, int userId, string content)
            :base(timeCreated, isSavedMessage, userId)
        {
            Content = content;
        }
    }
}
