using AutoMapper;
using System;
using TeamInternationalTestEf.Models;
using TeamInternationalTestWebApi.DTOs.TextMessageDTOs;

namespace TeamInternationalTestWebApi.Profiles
{
    public class TextMessageProfile : Profile
    {
        public TextMessageProfile()
        {
            CreateMap<TextMessage, ReadTextMessageDto>();
            CreateMap<TextMessage, ReadTextMessageDto>().ReverseMap();

            CreateMap<TextMessage, CreateUpdateServerMessageDto>();
            CreateMap<TextMessage, CreateUpdateServerMessageDto>().ReverseMap()
                 .ForMember(dest => dest.CreationTime, opt => opt.MapFrom(src => DateTime.Now.ToLocalTime()));
        }
    }
}
