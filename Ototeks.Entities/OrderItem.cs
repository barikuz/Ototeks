using System;
using System.Collections.Generic;

namespace Ototeks.Entities;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int? OrderId { get; set; }

    public int? FabricId { get; set; }

    public int? TypeId { get; set; }

    public int Quantity { get; set; }

    public string? CurrentStage { get; set; }

    public int? ProcessedByUserId { get; set; }

    public virtual Fabric? Fabric { get; set; }

    public virtual Order? Order { get; set; }

    public virtual User? ProcessedByUser { get; set; }

    public virtual ICollection<QualityLog> QualityLogs { get; set; } = new List<QualityLog>();

    public virtual ProductType? Type { get; set; }
}
