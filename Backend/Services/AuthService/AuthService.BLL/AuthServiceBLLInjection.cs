using Microsoft.Extensions.DependencyInjection;
using AuthService.BLL.Profiles;
using AuthService.BLL.Services.Interfaces;
using AuthService.BLL.Services.Classes;

namespace AuthService.BLL;

public static class AuthServiceBLLInjection
{
    public static void AddAuthServiceBLL(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserProfile));
        
        services.AddScoped<IAuthService, AuthService.BLL.Services.Classes.AuthService>();
        services.AddScoped<IJWTService, JWTService>();
        services.AddScoped<IPasswordService, PasswordService>();
    }
}