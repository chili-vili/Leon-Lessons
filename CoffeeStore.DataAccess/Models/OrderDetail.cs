using System;
using System.Collections.Generic;

namespace CoffeeStore.DataAccess.Models
{
    public partial class OrderDetail
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
        public decimal Sum { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
