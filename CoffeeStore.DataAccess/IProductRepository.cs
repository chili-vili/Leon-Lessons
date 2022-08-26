using CoffeeStore.DataAccess.Models;


namespace CoffeeStore.DataAccess
{
    internal interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
    }
}
