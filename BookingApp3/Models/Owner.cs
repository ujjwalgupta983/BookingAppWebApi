using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BookingApp3.Models
{
    public partial class Owner 
    {
        public Owner() 
        {
            Assets = new HashSet<Assets>();
        }

        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } 
        public string Passcode { get; set; }
       

        public ICollection<Assets> Assets { get; set; }
    }
}
