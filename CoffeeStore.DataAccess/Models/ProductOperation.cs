using System;
using System.Collections.Generic;

namespace CoffeeStore.DataAccess.Models
{
    public partial class ProductOperation
    {
        public string Name { get; set; } = null!;
        public string NomenclatureNumber { get; set; } = null!;
        public short OperationType { get; set; }
        public int? Amount { get; set; }
    }
}
