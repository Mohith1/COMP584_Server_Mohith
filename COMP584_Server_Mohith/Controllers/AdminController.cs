using COMP584_Server_Mohith.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorldModel;

namespace COMP584_Server_Mohith.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(UserManager<WorldModelUser> userManager) : ControllerBase
    {
        // POST: api/Login
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            // If it finds the user returns WorldModelUser object else returns null
            WorldModelUser? worldUser = await userManager.FindByNameAsync(loginRequest.Username);

            if (worldUser == null)
            {
                return Unauthorized("Invalid username.");
            }
            bool loginStatus = await userManager.CheckPasswordAsync(worldUser, loginRequest.Password);
            if (!loginStatus)
            {
                return Unauthorized("Invalid Password");
            }
            return Ok("Login Successful");

        }
    }
}
