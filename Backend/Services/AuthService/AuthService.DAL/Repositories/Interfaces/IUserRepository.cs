using AuthService.DAL.Entities;

namespace AuthService.DAL.Repositories.Interfaces;

public interface IUserRepository: IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}