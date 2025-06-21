using Microsoft.AspNetCore.Mvc;
using AuthService.BLL.DTOs;
using AuthService.BLL.Exceptions;
using AuthService.BLL.Services.Interfaces;

namespace AuthService.WebAPI.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(UserRegistrationRequestDTO userRegistrationRequestDto)
    {
        try
        {
            return Ok(await _authService.RegisterUser(userRegistrationRequestDto));
        }
        catch (UserAlreadyExistsException exception)
        {
            return Conflict(new { ErrorMessage = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> LoginUser(UserLoginRequestDTO userLoginRequestDto)
    {
        try
        {
            return Ok(await _authService.LoginUser(userLoginRequestDto));
        }
        catch (InvalidCredentialsException exception)
        {
            return Unauthorized(new { ErrorMessage = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
}