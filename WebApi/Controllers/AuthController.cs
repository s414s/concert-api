using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthServices _authServices;

    public AuthController(IAuthServices authServices)
    {
        _authServices = authServices;
    }

    [HttpPost(Name = "Login")] 
    public async Task<IActionResult> Login([FromBody] LoginDTO login)
    {
        try
        {
            var groupId = await _authServices.Login(login.Name, login.Password);
            var response = new { id = groupId };
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
