using DomainModule.Models;

namespace Repositories.Interfaces;
public interface IProductRepository
{
    public Task<ProductModel?> GetById(int id);
    
    public Task<List<ProductModel>> GetByFilter(Filter filter);
}