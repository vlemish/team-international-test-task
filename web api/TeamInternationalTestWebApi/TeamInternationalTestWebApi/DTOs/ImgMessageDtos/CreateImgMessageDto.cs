using Microsoft.AspNetCore.Http;

namespace TeamInternationalTestWebApi.DTOs.ImgMessageDtos
{
    public class CreateImgMessageDto
    {
        public IFormFile Data { get; set; }

        public int UserId { get; set; }


        public CreateImgMessageDto(IFormFile data, int userId)
        {
            Data = data;
            UserId = userId;
        }

        public CreateImgMessageDto()
        {

        }
    }
}
