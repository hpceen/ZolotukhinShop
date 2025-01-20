using Repositories.Database.Entities;

namespace Repositories.Interfaces;

public interface IUserRepository
{
    public Task<UserEntity?> GetUserByPhone(string phone);
    public Task<int> AddUser(UserEntity user);
}