using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace normari.Models;

public partial class Timpi
{
    public int Timpid { get; set; }

    public TimeOnly? Timp1 { get; set; }

    public TimeOnly? Timp2 { get; set; }

    public TimeOnly? Timp3 { get; set; }

    public TimeOnly? Timp4 { get; set; }

    public TimeOnly? Timp5 { get; set; }

    public TimeOnly? Timp6 { get; set; }

    public TimeOnly? Timp7 { get; set; }

    public TimeOnly? Timp8 { get; set; }

    public TimeOnly? Timp9 { get; set; }

    public TimeOnly? Timp10 { get; set; }

    public TimeOnly? Timp11 { get; set; }

    public TimeOnly? Timp12 { get; set; }

    public TimeOnly? Timp13 { get; set; }

    public TimeOnly? Timp14 { get; set; }

    public TimeOnly? Timp15 { get; set; }

    public TimeOnly? Timptotal { get; set; }

    public DateTime? Starttime { get; set; }

    public DateTime? Endtime { get; set; }
    [Required]
    public int? Normaid { get; set; }
}
