using Microsoft.Extensions.DependencyInjection;
using EnrollmentService.BLL.Profiles;
using EnrollmentService.BLL.Services.Interfaces;

namespace EnrollmentService.BLL;

public static class EnrollmentServiceBLLInjection
{
    public static void AddEnrollmentServiceBLL(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(EnrollmentProfile));
        
        services.AddScoped<IEnrollmentService, EnrollmentService.BLL.Services.Classes.EnrollmentService>();
    }
}