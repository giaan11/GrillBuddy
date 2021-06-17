using System;
using System.Collections.Generic;

#nullable disable

namespace GrillBuddy.DAL.Entities
{
    public partial class Location
    {
        public Location()
        {
            Reservations = new HashSet<Reservation>();
        }

        public decimal LocationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal People { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
