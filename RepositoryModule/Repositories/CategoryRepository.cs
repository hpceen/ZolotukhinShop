using DomainModule.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Database;
using Repositories.Extensions;

namespace Repositories.Repositories;

public class CategoryRepository(DatabaseContext context) : ICategoryRepository
{
    public async Task<List<CategoryModel>> GetAll()
    {
        return await context.Categories.Select(x => x.ToModel()).ToListAsync();
    }
}