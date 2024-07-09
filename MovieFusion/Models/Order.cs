using System;
using System.Collections.Generic;

namespace MovieFusion.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int UId { get; set; }

    public int MId { get; set; }

    public virtual MovieList MIdNavigation { get; set; } = null!;

    public virtual User UIdNavigation { get; set; } = null!;
}
