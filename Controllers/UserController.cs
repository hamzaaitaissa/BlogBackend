using blogfolio.Dto.User;
using blogfolio.Entities;
using blogfolio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blogfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserByIdAsync(int id)
        {
            return await _userService.GetUserByIdAsync(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserByIdAsync(int id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok("User has been deleted");
        }

        [HttpPut]
        public async Task<ActionResult<User>> UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            await _userService.UpdateUserAsync(updateUserDto);
            return Ok("User has been updated.");
        }

        [HttpGet] 
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);   
        }
    }
}
