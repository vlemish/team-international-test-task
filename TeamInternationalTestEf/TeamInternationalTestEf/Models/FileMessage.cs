using System;

namespace TeamInternationalTestEf.Models
{
    public class FileMessage : UserMessage
    {
        public string Name { get; set; }

        public string ContentType { get; set; }

        public byte[] Data { get; set; }


        public FileMessage()
        {

        }

        public FileMessage(DateTime creationTime, int userId, byte[] data)
            : base(creationTime, userId)
        {
            Data = data;
        }
    }
}
