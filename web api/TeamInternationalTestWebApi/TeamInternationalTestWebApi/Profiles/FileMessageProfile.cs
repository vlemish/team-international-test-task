using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using TeamInternationalTestEf.Models;
using TeamInternationalTestWebApi.DTOs.FileMessageDTOs;

namespace TeamInternationalTestWebApi.Profiles
{
    public class FileMessageProfile : Profile
    {
        public FileMessageProfile()
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


            CreateMap<ReadFileMessageDto, FileMessage>();
            CreateMap<ReadFileMessageDto, FileMessage>().ReverseMap();

            CreateMap<FileMessage, FileMessageManifest>();
            CreateMap<FileMessage, FileMessageManifest>().ReverseMap();

            CreateMap<ReadFileMessageDto, FileMessageManifest>();
            CreateMap<ReadFileMessageDto, FileMessageManifest>().ReverseMap();

            CreateMap<CreateFileMessageDto, FileMessage>()
                .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.Data.ContentType))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Data.FileName))
                .ForMember(dest => dest.CreationTime, opt => opt.MapFrom(src => DateTime.Now.ToLocalTime()))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => toBinary64Converter(src.Data)));
        }
    }
}
