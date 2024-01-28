using dotnet_7_crud_api.Models.Users;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

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


          // getting all  the users form the database 
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        // getting the user by id

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetById(id);
            return Ok(user);
        }

        // creating the user

        [HttpPost]
        public async Task<IActionResult> Create(CreateRequest model)
        {
            await _userService.Create(model);
            return Ok(new { message = "User created" });
        }

        // updating the user

        [HttpPut("{id:int}")]

        public async Task<IActionResult> Update(int id, UpdateRequest model)
        {
            await _userService.Update(id, model);
            return Ok(new { message = "User updated" });
        }

        // deleting the user

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok(new { message = "User deleted" });
        }
    }
}
