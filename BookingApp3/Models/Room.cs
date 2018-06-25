using System;
using System.Collections.Generic;

namespace BookingApp3.Models
{
    public partial class Room
    {
        public int RId { get; set; }
        public int RNo { get; set; }
        public int RRate { get; set; }
        public string RCategory { get; set; }
        public int RStatus { get; set; }
        public int AId { get; set; }

        public Assets A { get; set; }
    }
}
