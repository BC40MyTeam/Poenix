using System;
using System.Collections.Generic;

namespace Phoenix.DataAccess.Models;

public partial class Inventory
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Stock { get; set; }
}
