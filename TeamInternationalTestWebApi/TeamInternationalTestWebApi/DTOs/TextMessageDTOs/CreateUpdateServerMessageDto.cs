using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamInternationalTestWebApi.DTOs.TextMessageDTOs
{
    public class CreateUpdateServerMessageDto
    {
        public string Content { get; set; }

        public int UserId { get; set; }
    }
}
