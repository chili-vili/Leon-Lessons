using System;
using System.Collections.Generic;

namespace CoffeeStore.DataAccess.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public short OrderStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual OrderStatus OrderStatusNavigation { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
