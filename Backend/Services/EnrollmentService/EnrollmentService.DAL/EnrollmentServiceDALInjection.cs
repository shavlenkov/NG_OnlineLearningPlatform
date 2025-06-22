using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using EnrollmentService.DAL.DatabaseContext;
using EnrollmentService.DAL.Repositories.Interfaces;
using EnrollmentService.DAL.Repositories.Classes;

namespace EnrollmentService.DAL;

public static class EnrollmentServiceDALInjection
{
    public static void AddEnrollmentServiceDAL(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EnrollmentServiceDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DbConnectionString"));
        });
        
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
    }
}