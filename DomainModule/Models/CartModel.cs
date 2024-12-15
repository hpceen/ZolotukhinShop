namespace DomainModule.Models;

[Serializable]
public class CartModel
{
    public List<CartItem> Items { get; set; } = [];
    public double TotalPrice => Items.Sum(item => item.TotalPrice);
    public int Count => Items.Sum(item => item.Quantity);

    public void Add(ProductModel item)
    {
        ArgumentNullException.ThrowIfNull(item);
        var cartItem = Items.Find(cartItem => cartItem.Product.Id == item.Id);
        if (cartItem == null)
            Items.Add(new CartItem { Product = item });
        else
            ++cartItem.Quantity;
    }

    public void Remove(ProductModel item)
    {
        ArgumentNullException.ThrowIfNull(item);
        Remove(item.Id);
    }

    public void Remove(int productId)
    {
        var cartItem = Items.Find(cartItem => cartItem.Product.Id == productId);
        if (cartItem == null) return;
        if (cartItem.Quantity == 1)
        {
            Items.Remove(cartItem);
        }
        else
        {
            --cartItem.Quantity;
        }
    }

    public void Clear() => Items.Clear();

    public ProductModel? GetProduct(int productId) => Items.Find(cartItem => cartItem.Product.Id == productId)?.Product;

    public List<ProductModel> GetProducts() => Items.Select(cartItem => cartItem.Product).ToList();
}