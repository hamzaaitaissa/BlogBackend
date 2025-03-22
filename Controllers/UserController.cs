using blogfolio.Dto.User;
using blogfolio.Entities;
using blogfolio.ENUMS;
using blogfolio.Services;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<IEnumerable<UserWithBlogsDto>>> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);   
        }

        //only admins can change a user's role
        [Authorize(Roles = "Admin")]
        [HttpPut("update-role/{userId}")]
        public async Task<IActionResult> UpdateUserRole(int userId, [FromBody] UserRole newRole)
        {
            await _userService.UpdateUserRoleAsync(userId, newRole);
            return Ok("User role updated successfully.");
        }
    }
}
