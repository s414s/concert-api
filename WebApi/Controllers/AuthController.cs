using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using WebApi.API.Controllers;

namespace WebApi.Controllers;

public class AuthController : ControllerBase
{
    private readonly ILogger<EventController> _logger;
    private readonly IAuthServices _authServices;

    [HttpPost(Name = "Login")] 
    public async Task<IActionResult> LoginAsync([FromBody] LoginDTO login)
    {
        try
        {
            var isAuthCorrect = await _authServices.Login(login.Name, login.Password);
            return Ok(isAuthCorrect);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }
}
