using DomainModule.Models;

namespace ZolotukhinShop.ViewModels;

public class IndexViewModel
{
    public List<ProductModel> Products { get; set; } = [];
    public List<CategoryModel> Categories { get; set; } = [];

    public Filter Filter { get; set; } = new();
}