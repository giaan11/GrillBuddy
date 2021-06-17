using System;
using System.Collections.Generic;

#nullable disable

namespace GrillBuddy.DAL.Entities
{
    public partial class Reservation
    {
        public decimal ReservationId { get; set; }
        public decimal LocationId { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Location Location { get; set; }
    }
}
