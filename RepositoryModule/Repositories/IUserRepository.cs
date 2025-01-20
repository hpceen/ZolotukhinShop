using Repositories.Database;
using Repositories.Database.Entities;
using Repositories.Interfaces;

namespace Repositories.Repositories;

public class UserRepository(DatabaseContext context) : IUserRepository
{
    public async Task<UserEntity?> GetUserByPhone(string phone)
    {
        return await context.Users.FindAsync(phone);
    }

    public async Task<int> AddUser(UserEntity user)
    {
        await context.Users.AddAsync(user);
        return await context.SaveChangesAsync();
    }
}