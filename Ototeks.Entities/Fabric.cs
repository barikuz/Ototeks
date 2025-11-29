using System;
using System.Collections.Generic;

namespace Ototeks.Entities;

public partial class Fabric
{
    public int FabricId { get; set; }

    public string FabricCode { get; set; } = null!;

    public string? FabricName { get; set; }

    public int? ColorId { get; set; }

    public decimal? StockQuantity { get; set; }

    public virtual Color? Color { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
