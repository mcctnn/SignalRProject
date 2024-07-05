﻿using AutoMapper;
using SignalR.EntityLayer.Entities;
using SignalRDto.AboutDto;

namespace SignalRAPI.Mapping
{
    public class AboutMapping:Profile
    {
        public AboutMapping()
        {
            CreateMap<About,ResultAboutDto>().ReverseMap();
            CreateMap<About,CreateAboutDto>().ReverseMap();
            CreateMap<About,UpdateAboutDto>().ReverseMap();
            CreateMap<About,GetAboutDto>().ReverseMap();
        }
    }
}
