using System;
using System.Collections.Generic;

#nullable disable

namespace GrillBuddy.DAL.Entities
{
    public partial class Drink
    {
        public Drink()
        {
            Users = new HashSet<User>();
        }

        public decimal DrinkId { get; set; }
        public string Name { get; set; }
        public bool Alcol { get; set; }
        public decimal? Quantita { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
