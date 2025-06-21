using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using AuthService.DAL.DatabaseContext;
using AuthService.DAL.Repositories.Interfaces;
using AuthService.DAL.Repositories.Classes;

namespace AuthService.DAL;

public static class AuthServiceDALInjection
{
    public static void AddAuthServiceDAL(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AuthServiceDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DbConnectionString"));
        });
        
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUserRepository, UserRepository>();
    }
}