using System;
using System.Collections.Generic;

namespace CoffeeStore.DataAccess.Models
{
    public partial class Origin
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
