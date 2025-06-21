using Microsoft.EntityFrameworkCore;
using AuthService.DAL.Entities;
using AuthService.DAL.Repositories.Interfaces;
using AuthService.DAL.DatabaseContext;

namespace AuthService.DAL.Repositories.Classes;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly AuthServiceDbContext _context;
    
    public UserRepository(AuthServiceDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}