using AuthService.DAL.Entities;

namespace AuthService.BLL.Services.Interfaces;

public interface IJWTService
{
    string GenerateJWT(User user);
}