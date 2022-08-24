using System;
using System.Collections.Generic;

namespace CoffeeStore.DataAccess.Models
{
    public partial class ProductType
    {
        public ProductType()
        {
            Products = new HashSet<Product>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
