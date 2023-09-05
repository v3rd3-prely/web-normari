using System;
using System.Collections.Generic;

namespace normari.Models;

public partial class Postlucru
{
    public int Postid { get; set; }

    public string? Postdelucru { get; set; }

    public virtual ICollection<Norme> Normes { get; set; } = new List<Norme>();
}
