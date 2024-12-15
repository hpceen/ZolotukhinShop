namespace DomainModule.Models;

[Serializable]
public class CartItem
{
    public required ProductModel Product { get; init; }
    public int Quantity { get; set; } = 1;
    public double TotalPrice => Product.Price * Quantity;
}