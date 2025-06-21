using AuthService.DAL.DatabaseContext;

namespace AuthService.DAL.Initializer;

public static class Initializer
{
    public static void InitializeDb(AuthServiceDbContext context)
    {
        context.Database.EnsureCreated();
    }
}