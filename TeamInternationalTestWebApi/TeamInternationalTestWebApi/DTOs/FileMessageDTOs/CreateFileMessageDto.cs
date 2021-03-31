using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace TeamInternationalTestWebApi.DTOs.FileMessageDTOs
{
    public class CreateFileMessageDto
    {
        public IFormFile Data { get; set; }

        [AllowNull]
        public int UserId { get; set; }
    }
}
