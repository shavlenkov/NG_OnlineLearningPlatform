using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CourseService.DAL.DatabaseContext;
using CourseService.DAL.Repositories.Interfaces;
using CourseService.DAL.Repositories.Classes;

namespace CourseService.DAL;

public static class CourseServiceDALInjection
{
    public static void AddCourseServiceDAL(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CourseServiceDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DbConnectionString"));
        });
        
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<ICourseRepository, CourseRepository>();
    }
}