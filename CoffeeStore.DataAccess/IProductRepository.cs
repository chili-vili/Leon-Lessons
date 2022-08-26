using CoffeeStore.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.DataAccess
{
    internal interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
    }
}
