using DomainModule.Models;
using Repositories.Database.Entities;

namespace Repositories.Extensions;

public static class CategoryEntityExtension
{
    public static CategoryModel ToModel(this CategoryEntity entity)
    {
        return new CategoryModel
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }
}