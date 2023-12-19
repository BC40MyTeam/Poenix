using System;
using System.Collections.Generic;

namespace Phoenix.DataAccess.Models;

public partial class RoomInventory
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Quantity { get; set; }
}
