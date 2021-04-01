using System;

namespace TeamInternationalTestWebApi.DTOs.FileMessageDTOs
{
    public class ReadImgMessageDto
    {
        public int Id { get; set; }

        public byte[] Data { get; set; }

        public DateTime CreationTime { get; set; }

        public string ContentType { get; set; }

        public string Name { get; set; }


        public ReadImgMessageDto()
        {

        }
    }
}
