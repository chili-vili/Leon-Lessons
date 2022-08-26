using CoffeeStore.DataAccess.Models;

namespace CoffeeStore.DataAccess
{
    internal class ProductsRepository:IProductRepository
    {
        public Task<IEnumerable<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

    }
}
