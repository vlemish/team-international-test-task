using System;

namespace TeamInternationalTestEf.Models
{
    public class FileMessage : UserMessage
    {
        public byte[] Data { get; set; }


        public FileMessage()
        {

        }

        public FileMessage(DateTime timeCreated, bool isSavedMessage, int userId, byte[] data)
            : base(timeCreated, isSavedMessage, userId)
        {
            Data = data;
        }
    }
}
