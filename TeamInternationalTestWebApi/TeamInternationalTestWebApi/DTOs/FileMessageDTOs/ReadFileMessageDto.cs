using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamInternationalTestWebApi.DTOs.FileMessageDTOs
{
    public class ReadFileMessageDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ContentType { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
