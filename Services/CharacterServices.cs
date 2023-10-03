using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotenet7web_api_pratice.Dtos.Character;
using dotenet7web_api_pratice.models;

namespace dotenet7web_api_pratice.Services
{
    public class CharacterServices : ICharacterService
    {

// Compare this snippet from Controllers/CharacterController.cs:
        private static List<Character> characters = new List<Character> {
            new Character(),
            new Character {Id = 1, Name = "Sam"}
        };      
        
        
        // Adding of this field is the only difference between this file and the CharacterController.cs file
          private readonly IMapper _mapper;

        public CharacterServices( IMapper mapper)
        {
            _mapper = mapper;
        }

      
      // Add 
        public async Task  <ServicesResponses  <List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var ServicesResponses = new ServicesResponses<List<GetCharacterDto>>();
             var character = _mapper.Map<Character>(newCharacter);
             character.Id = characters.Max(c => c.Id) + 1;
             characters.Add(character);
            ServicesResponses.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return ServicesResponses;
        }

        //  Delete charecter

        public async Task<ServicesResponses<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
         
         //  Get A sing character
            var ServicesResponses = new ServicesResponses<List<GetCharacterDto>>();
            var character = characters.First(c => c.Id == id);
            characters.Remove(character);
            ServicesResponses.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return ServicesResponses;
        }

        // Get all characters
        public  async Task<ServicesResponses<List<GetCharacterDto>>> GetAllCharacters()
        {
           var ServicesResponses = new ServicesResponses<List<GetCharacterDto>>();
              ServicesResponses.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
                return ServicesResponses;
        }

// Get by id
        public async Task<ServicesResponses<GetCharacterDto>> GetCharacterById(int id)
        {
            var ServicesResponses = new ServicesResponses<GetCharacterDto>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            ServicesResponses.Data =  _mapper.Map<GetCharacterDto>(character);
            return ServicesResponses;
           
        }

      
      // Update  character  
      // Todo : Will be adding sucres message 
        public async Task<ServicesResponses<List<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {

            var ServicesResponses = new ServicesResponses<List<GetCharacterDto>>();
            try
            {
               
                var character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

                 if(character == null)
                     throw new Exception($"Character with id {updatedCharacter.Id} was not found");

                character.Name = updatedCharacter.Name;
                character.Class = updatedCharacter.Class;
                character.Defense = updatedCharacter.Defense;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Strength = updatedCharacter.Strength;
                ServicesResponses.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

               
            }
            catch (Exception e)
            {
                ServicesResponses.Success = false;
                ServicesResponses.Message = e.Message;
            }
            return ServicesResponses;

        }
    } 
}