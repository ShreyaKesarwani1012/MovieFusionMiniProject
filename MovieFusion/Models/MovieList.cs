using System;
using System.Collections.Generic;

namespace MovieFusion.Models;

public partial class MovieList
{
    public int MId { get; set; }

    public string Mname { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public int Duration { get; set; }

    public byte[] Mpic { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
