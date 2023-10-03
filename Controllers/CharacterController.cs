using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotenet7web_api_pratice.Dtos.Character;
using dotenet7web_api_pratice.models;
using dotenet7web_api_pratice.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotenet7web_api_pratice.Controllers
{

    [ApiController] 

    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {

        // this is a mock database
       
        private readonly ICharacterService _characterService;

        public  CharacterController( ICharacterService characterService )
      {

       _characterService = characterService;
        
      }    

        // this is a get request
        [HttpGet("GetAll")]
        public async Task <ActionResult <List<GetCharacterDto>>> Get()
        {
            return Ok( await _characterService.GetAllCharacters()   );
        }

        // this is a get request
        [HttpGet("{id}")]
        public async Task <ActionResult<ServicesResponses<List <GetCharacterDto>>>>GetSingle(int id)
        {
            return Ok( await _characterService.GetCharacterById(id));
        }

        // this is a post request
        [HttpPost]
        public async  Task <ActionResult<ServicesResponses<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
        {
               
            return Ok( await  _characterService.AddCharacter(newCharacter)  );
        }

        // this is a put request

        [HttpPut]

        public async Task <ActionResult<ServicesResponses<List<GetCharacterDto>>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {


            var response = await _characterService.UpdateCharacter(updatedCharacter);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


        // this is a delete request

        [HttpDelete("{id}")]
        public async Task < ActionResult <ServicesResponses <List <GetCharacterDto>>>> DeleteCharacter(int id)
        {
            var response = await _characterService.DeleteCharacter(id);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        
    }
}