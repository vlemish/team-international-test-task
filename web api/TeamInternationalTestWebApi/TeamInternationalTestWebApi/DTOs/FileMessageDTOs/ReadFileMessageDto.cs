using System;

namespace TeamInternationalTestWebApi.DTOs.FileMessageDTOs
{
    public class ReadFileMessageDto
    {
        public int Id { get; set; }

        public DateTime CreationTime { get; set; }

        public string Name { get; set; }

        public string ContentType { get; set; }

    }
}
