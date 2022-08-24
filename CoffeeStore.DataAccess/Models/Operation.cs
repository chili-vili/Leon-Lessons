using System;
using System.Collections.Generic;

namespace CoffeeStore.DataAccess.Models
{
    public partial class Operation
    {
        public Guid Id { get; set; }
        public short OperationType { get; set; }
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }

        public virtual OperationType OperationTypeNavigation { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
