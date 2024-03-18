using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using System.Security.Claims;

namespace Cricks.Controllers
{
    [Authorize(Roles = "Owner,Admin")]
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<AdminController> _logger;

        public AdminController(UserManager<IdentityUser> userManager, ILogger<AdminController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet("debug")]
        public IActionResult Debug()
        {
            var identity = User.Identity as ClaimsIdentity;
            var roles = identity.Claims
                                .Where(c => c.Type == ClaimTypes.Role)
                                .Select(c => c.Value);
            return Ok(new { isAuthenticated = User.Identity.IsAuthenticated, userName = User.Identity.Name, roles = roles });
        }

        [HttpPost("assignRole")]
        public async Task<IActionResult> AssignRole(string username, string role)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(username);
                if (user == null)
                {
                    _logger.LogWarning("User not found with username: {username}", username);
                    return NotFound("User not found.");
                }

                var result = await _userManager.AddToRoleAsync(user, role);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Role assigned to user: {username}", username);
                    return Ok();
                }

                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while assigning role to user: {username}", username);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("activateUser")]
        public async Task<IActionResult> ActivateUser(string username)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(username);
                if (user == null)
                {
                    _logger.LogWarning("User not found with username: {username}", username);
                    return NotFound("User not found.");
                }

                user.LockoutEnd = null;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User activated: {username}", username);
                    return Ok();
                }

                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while activating user: {username}", username);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("deactivateUser")]
        public async Task<IActionResult> DeactivateUser(string username)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(username);
                if (user == null)
                {
                    _logger.LogWarning("User not found with username: {username}", username);
                    return NotFound("User not found.");
                }

                user.LockoutEnd = DateTimeOffset.MaxValue;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User deactivated: {username}", username);
                    return Ok();
                }

                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deactivating user: {username}", username);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("checkUserDetails")]
        public async Task<IActionResult> CheckUserDetails(string username)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(username);
                if (user == null)
                {
                    _logger.LogWarning("User not found with username: {username}", username);
                    return NotFound("User not found.");
                }

                var roles = await _userManager.GetRolesAsync(user);

                var userDetails = new UserDetailsDto
                {
                    Username = user.UserName,
                    Email = user.Email,
                    LockoutEnd = user.LockoutEnd,
                    ContactNo = user.PhoneNumber,
                    Roles = roles
                };

                _logger.LogInformation("User details checked for user: {username}", username);
                return Ok(userDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while checking user details for user: {username}", username);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
