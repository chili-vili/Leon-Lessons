using System;
using System.Collections.Generic;

namespace CoffeeStore.DataAccess.Models
{
    public partial class PropertyEnum
    {
        public PropertyEnum()
        {
            PropertyEnumValues = new HashSet<PropertyEnumValue>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public short ValueType { get; set; }

        public virtual ICollection<PropertyEnumValue> PropertyEnumValues { get; set; }
    }
}
