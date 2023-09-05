using System;
using System.Collections.Generic;

namespace normari.Models;

public partial class Sectii
{
    public int Sectieid { get; set; }

    public string Sectie { get; set; } = null!;

    public virtual ICollection<Norme> Normes { get; set; } = new List<Norme>();
}
