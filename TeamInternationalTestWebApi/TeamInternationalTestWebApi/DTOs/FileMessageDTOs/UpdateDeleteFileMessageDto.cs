using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamInternationalTestWebApi.DTOs.FileMessageDTOs
{
    public class UpdateDeleteFileMessageDto
    {
        public byte[] Data { get; set; }

        public int UserId { get; set; }
    }
}
