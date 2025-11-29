using System;
using System.Collections.Generic;

namespace Ototeks.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public string OrderNumber { get; set; } = null!;

    public int? CustomerId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? DueDate { get; set; }

    public string? OrderStatus { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
