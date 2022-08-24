﻿using System;
using System.Collections.Generic;

namespace CoffeeStore.DataAccess.Models
{
    public partial class Product
    {
        public Product()
        {
            Operations = new HashSet<Operation>();
            OrderDetails = new HashSet<OrderDetail>();
            Prices = new HashSet<Price>();
            ProductProperties = new HashSet<ProductProperty>();
            ProductPropertyValues = new HashSet<ProductPropertyValue>();
        }

        public Guid Id { get; set; }
        public string NomenclatureNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public Guid ProductTypeId { get; set; }
        public string? Description { get; set; }

        public virtual ProductType ProductType { get; set; } = null!;
        public virtual ICollection<Operation> Operations { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
        public virtual ICollection<ProductProperty> ProductProperties { get; set; }
        public virtual ICollection<ProductPropertyValue> ProductPropertyValues { get; set; }
    }
}
