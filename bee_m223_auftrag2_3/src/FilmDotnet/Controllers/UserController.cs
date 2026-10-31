using bee_m223_auftrag2_3.Services;
using bee_m223_auftrag2_3.Models;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;


namespace bee_m223_auftrag2_3.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            var userDTOs = users.Select(u => new UserDTO
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email
            }).ToList();

            return Ok(userDTOs);
        }
    }
}