using EnrollmentService.DAL.DatabaseContext;

namespace EnrollmentService.DAL.Initializer;

public static class Initializer
{
    public static void InitializeDb(EnrollmentServiceDbContext context)
    {
        context.Database.EnsureCreated();
    }
}