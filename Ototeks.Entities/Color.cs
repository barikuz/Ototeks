using System;
using System.Collections.Generic;

namespace Ototeks.Entities;

public partial class Color
{
    public int ColorId { get; set; }

    public string ColorName { get; set; } = null!;

    public virtual ICollection<Fabric> Fabrics { get; set; } = new List<Fabric>();
}
