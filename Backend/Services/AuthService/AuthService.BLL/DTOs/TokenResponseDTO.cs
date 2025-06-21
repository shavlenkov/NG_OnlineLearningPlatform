namespace AuthService.BLL.DTOs;

public class TokenResponseDTO
{
    public string TokenType { get; set; } = "Bearer";
    public string AccessToken { get; set; } = string.Empty;
}