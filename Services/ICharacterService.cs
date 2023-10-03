using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotenet7web_api_pratice.Dtos.Character;
using dotenet7web_api_pratice.models;

namespace dotenet7web_api_pratice.Services
{
    public interface ICharacterService
    {

         Task <ServicesResponses <List <GetCharacterDto>>> GetAllCharacters();
        Task<ServicesResponses< GetCharacterDto>> GetCharacterById(int id);
        Task<ServicesResponses< List <GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        Task<ServicesResponses< List <GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedCharacter);
        Task<ServicesResponses<List <GetCharacterDto>>> DeleteCharacter(int id);
        
    }
}