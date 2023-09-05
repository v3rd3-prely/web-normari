using System;
using System.Collections.Generic;

namespace normari.Models;

public partial class Operatietip
{
    public int Operatietipid { get; set; }

    public string? Operatietip1 { get; set; }

    public virtual ICollection<Norme> Normes { get; set; } = new List<Norme>();
}
