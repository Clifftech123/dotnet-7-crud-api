using dotnet_7_crud_api.Entitiles;
using dotnet_7_crud_api.Models.Users;
using dotnet_7_crud_api.Services;
using Microsoft.AspNetCore.Mvc;


namespace dotnet_7_crud_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _userService.GetAll();
                return Ok(new { message = "Successfully retrieved all users", data = users });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = "An error occurred while retrieving all users", error = ex.Message });
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var user = await _userService.GetById(id);
                if (user == null)
                {
                    return NotFound(new { message = $"User with id {id} not found" });
                }
                return Ok(new { message = $"Successfully retrieved user with id {id}", data = user });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = $"An error occurred while retrieving user with id {id}", error = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var user = new User
                {
                    Guid = model.guid,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,



                };

                await _userService.Create(model);
                return Ok(new { message = "User successfully created" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the user", error = ex.Message });
            }
        }



        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var user = await _userService.GetById(id);
                if (user == null)
                {
                    return NotFound(new { message = $"User with id {id} not found" });
                }

                await _userService.Update(id, model);
                return Ok(new { message = $"User with id {id} successfully updated" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred while updating user with id {id}", error = ex.Message });
            }
        }




        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _userService.Delete(id);
                return Ok(new { message = $"User with id {id} successfully deleted" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred while deleting user with id {id}", error = ex.Message });
            }
        }
    }
}