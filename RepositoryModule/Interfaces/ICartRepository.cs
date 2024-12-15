namespace Repositories.Interfaces;

public interface ICartRepository
{
    public void AddProduct(int productId);

    public void RemoveProduct(int productId);
}