using System;
using System.Collections.Generic;

namespace normari.Models;

public partial class Operatiestandard
{
    public int Operatiestadnardid { get; set; }

    public string? Operatiestandard1 { get; set; }

    public virtual ICollection<Norme> Normes { get; set; } = new List<Norme>();
}
