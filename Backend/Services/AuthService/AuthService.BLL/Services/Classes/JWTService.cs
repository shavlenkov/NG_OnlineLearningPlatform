using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using AuthService.DAL.Entities;
using AuthService.BLL.Services.Interfaces;

namespace AuthService.BLL.Services.Classes;

public class JWTService : IJWTService
{
    private readonly IConfiguration _config;
    
    public JWTService(IConfiguration config)
    {
        _config = config;
    }
    
    public string GenerateJWT(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_config["JWT:Key"]!);
        
        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            }),
            Expires = DateTime.Now.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            Issuer = _config["JWT:Issuer"],
            Audience = _config["JWT:Audience"]
        });
        
        return tokenHandler.WriteToken(token);
    }
}