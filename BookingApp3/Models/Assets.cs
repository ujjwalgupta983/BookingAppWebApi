using System;
using System.Collections.Generic;

namespace BookingApp3.Models
{
    public partial class Assets
    {
        public Assets()
        {
            Room = new HashSet<Room>();
        }

        public int AId { get; set; }
        public string AName { get; set; }
        public string AAdd1 { get; set; }
        public string AAdd2 { get; set; }
        public string Type { get; set; }
        public int? OId { get; set; }

        public Owner O { get; set; }
        public ICollection<Room> Room { get; set; }
    }
}
