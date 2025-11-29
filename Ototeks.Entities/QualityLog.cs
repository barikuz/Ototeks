using System;
using System.Collections.Generic;

namespace Ototeks.Entities;

public partial class QualityLog
{
    public int LogId { get; set; }

    public int? OrderItemId { get; set; }

    public DateTime? InspectionDate { get; set; }

    public bool? IsDefective { get; set; }

    public int? DefectId { get; set; }

    public double? ConfidenceScore { get; set; }

    public string? ImagePath { get; set; }

    public string? OperatorNote { get; set; }

    public virtual DefectType? Defect { get; set; }

    public virtual OrderItem? OrderItem { get; set; }
}
