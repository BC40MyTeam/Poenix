using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.DataAccess.Models.Enums
{
    public static class EnumExtension
    {
        private static readonly Dictionary<Enum, string> _enumMap = new Dictionary<Enum, string>
        {
            { RoomType.STD, "Standard" },
            { RoomType.DLX, "Deluxe" },
            { RoomType.LUX, "Luxury" },
            { RoomStatus.AVL, "Available" },
            { RoomStatus.NAVL, "Non Available" },
        };

        public static string GetLabel(this Enum @enum)
        {
            return _enumMap[@enum];
        }

        

    }
}
