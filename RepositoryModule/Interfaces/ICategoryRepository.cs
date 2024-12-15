using DomainModule.Models;
namespace Repositories.Interfaces;

public interface ICategoryRepository
{
    public Task<List<CategoryModel>> GetAll();
}