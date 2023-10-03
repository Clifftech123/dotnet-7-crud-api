using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotenet7web_api_pratice.Dtos.Character;
using dotenet7web_api_pratice.models;

namespace dotenet7web_api_pratice
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();

        }
    }
}