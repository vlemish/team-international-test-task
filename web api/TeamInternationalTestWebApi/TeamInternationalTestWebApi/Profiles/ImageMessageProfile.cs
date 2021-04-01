using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using TeamInternationalTestEf.Models;
using TeamInternationalTestWebApi.DTOs.FileMessageDTOs;
using TeamInternationalTestWebApi.DTOs.ImgMessageDtos;

namespace TeamInternationalTestWebApi.Profiles
{
    public class ImageMessageProfile : Profile
    {
        public ImageMessageProfile()
        {
            //helper method for mapping file messages dtos to file messages
            Func<IFormFile, byte[]> toBinary64Converter = (file) =>
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    return ms.ToArray();
                }
            };

            CreateMap<ImageMessage, ReadImgMessageDto>();
            CreateMap<ReadImgMessageDto, ImageMessage>();

            CreateMap<CreateImgMessageDto, ImageMessage>()
                .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.Data.ContentType))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Data.FileName))
                .ForMember(dest => dest.CreationTime, opt => opt.MapFrom(src => DateTime.Now.ToLocalTime()))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => toBinary64Converter(src.Data)));

        }
    }
}
