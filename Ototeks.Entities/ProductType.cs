using System;
using System.Collections.Generic;

namespace Ototeks.Entities;

public partial class ProductType
{
    public int TypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
