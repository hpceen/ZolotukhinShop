using System.ComponentModel.DataAnnotations;

namespace Repositories.Database.Entities;

public class CategoryEntity
{
    [Key] public int Id { get; set; }
    [MaxLength(100)] public string? Name { get; set; }
    public virtual List<ProductEntity> Products { get; set; } = [];
}