using Microsoft.AspNetCore.Http;

namespace TeamInternationalTestWebApi.DTOs.FileMessageDTOs
{
    public class CreateFileMessageDto
    {
        public IFormFile Data { get; set; }

        public int UserId { get; set; }


        public CreateFileMessageDto(IFormFile data, int userId)
        {
            Data = data;
            UserId = userId;
        }
    }
}
