using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using TeamInternationalTestEf.Models;
using TeamInternationalTestWebApi.DTOs.FileMessageDTOs;
using TeamInternationalTestWebApi.DTOs.TextMessageDTOs;

namespace TeamInternationalTestWebApi.Profiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
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

            //file messages -> file messages dtos
            CreateMap<FileMessageManifest, ReadFileMessageDto>();
            //CreateMap<FileMessage, ReadFileMessageDto>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    //.ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
            //    .ForMember(dest => dest.CreationTime, opt => opt.MapFrom(src => src.CreationTime));
            CreateMap<CreateFileMessageDto, FileMessage>()
                .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.Data.ContentType))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Data.FileName))
                .ForMember(dest => dest.CreationTime, opt => opt.MapFrom(src => DateTime.Now.ToLocalTime()))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => toBinary64Converter(src.Data)));

            //text messages -> text messages dtos
            CreateMap<TextMessage, ReadTextMessageDto>();
            CreateMap<TextMessage, ReadTextMessageDto>().ReverseMap();
            CreateMap<TextMessage, CreateUpdateServerMessageDto>();
            CreateMap<TextMessage, CreateUpdateServerMessageDto>().ReverseMap()
                 //.ForMember(dest => dest.TimeCreated, opt => opt.AddTransform((dt) => DateTime.Now));
                 .ForMember(dest => dest.CreationTime, opt => opt.MapFrom(src => DateTime.Now.ToLocalTime()));

            //file messages -> img messages dtos
            CreateMap<ReadImgMessageDto, FileMessage>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.CreationTime, opt => opt.MapFrom(src => src.CreationTime))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<ReadImgMessageDto, FileMessage>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.CreationTime, opt => opt.MapFrom(src => src.CreationTime))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
