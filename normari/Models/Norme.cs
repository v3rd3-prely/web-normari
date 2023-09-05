using System;
using System.Collections.Generic;

namespace normari.Models;

public partial class Norme
{
    public int Normaid { get; set; }

    public bool? Operatiesimpla { get; set; }

    public bool? Operatiemultipla { get; set; }

    public int Operatietip { get; set; }

    public int Operatiestandard { get; set; }

    public int Postlucru { get; set; }

    public int Sectie { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? NrOperatii { get; set; }

    public virtual Operatiestandard OperatiestandardNavigation { get; set; } = null!;

    public virtual Operatietip OperatietipNavigation { get; set; } = null!;

    public virtual Postlucru PostlucruNavigation { get; set; } = null!;

    public virtual Sectii SectieNavigation { get; set; } = null!;
}
