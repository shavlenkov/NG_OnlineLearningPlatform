using Microsoft.Extensions.DependencyInjection;
using CourseService.BLL.Profiles;
using CourseService.BLL.Services.Interfaces;

namespace CourseService.BLL;

public static class CourseServiceBLLInjection
{
    public static void AddCourseServiceBLL(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(CourseProfile));
        
        services.AddScoped<ICourseService, CourseService.BLL.Services.Classes.CourseService>();
    }
}