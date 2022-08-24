﻿using System;
using System.Collections.Generic;

namespace CoffeeStore.DataAccess.Models
{
    public partial class OperationType
    {
        public OperationType()
        {
            Operations = new HashSet<Operation>();
        }

        public short Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Operation> Operations { get; set; }
    }
}
