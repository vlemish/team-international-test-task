using System;

namespace TeamInternationalTestWebApi.DTOs.TextMessageDTOs
{
    public class ReadTextMessageDto
    {
        public int Id { get; set; }

        public DateTime CreationTime { get; set; }

        public string Content { get; set; }

        public int UserId { get; set; }
    }
}
