using Core.Security;
using Core.Services;
using Data.Dtos.Users;
using Data.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Board.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly ILogger<userController> _logger;
        private readonly IUserService _userService;
        public userController(ILogger<userController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [Authorize]
        [HttpGet("users")]
        public async Task<IActionResult> getAllUsers()
        {
            try
            {
                return Ok(await _userService.GetAllAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> createUsuario(AddUserRequest req)
        {
            try
            {
                await _userService.RegisterAsync(req, req.Password);

                var (user, token) = await _userService.AuthenticateAsync(req.Email, req.Password);

                return Ok(new { token, user });
            }
            catch (ValidationException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
