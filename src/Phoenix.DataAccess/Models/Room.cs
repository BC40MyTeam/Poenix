using Phoenix.DataAccess.Models.Enums;
using System;
using System.Collections.Generic;

namespace Phoenix.DataAccess.Models;

public partial class Room
{
    public string Number { get; set; } = null!;

    public int Floor { get; set; }

    public RoomType RoomType { get; set; }

    public int GuestLimit { get; set; }

    public string? Description { get; set; }

    public decimal Cost { get; set; }
}
