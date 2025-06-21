using AuthService.BLL.DTOs;

namespace AuthService.BLL.Services.Interfaces;

public interface IAuthService
{
    Task<TokenResponseDTO> RegisterUser(UserRegistrationRequestDTO requestDto);
    Task<TokenResponseDTO> LoginUser(UserLoginRequestDTO requestDto);
}