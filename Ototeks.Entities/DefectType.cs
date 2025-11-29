using System;
using System.Collections.Generic;

namespace Ototeks.Entities;

public partial class DefectType
{
    public int DefectId { get; set; }

    public string DefectName { get; set; } = null!;

    public virtual ICollection<QualityLog> QualityLogs { get; set; } = new List<QualityLog>();
}
