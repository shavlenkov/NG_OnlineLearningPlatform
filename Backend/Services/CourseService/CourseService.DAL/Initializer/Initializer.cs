using CourseService.DAL.DatabaseContext;

namespace CourseService.DAL.Initializer;

public static class Initializer
{
    public static void InitializeDb(CourseServiceDbContext context)
    {
        context.Database.EnsureCreated();
    }
}