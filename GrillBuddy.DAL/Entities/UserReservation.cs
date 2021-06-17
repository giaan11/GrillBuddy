using System;
using System.Collections.Generic;

#nullable disable

namespace GrillBuddy.DAL.Entities
{
    public partial class UserReservation
    {
        public decimal UserId { get; set; }
        public decimal? ReservationId { get; set; }
        public string Owner { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Reservation Reservation { get; set; }
        public virtual User User { get; set; }
    }
}
