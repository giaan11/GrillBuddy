using System;
using System.Collections.Generic;

#nullable disable

namespace GrillBuddy.DAL.Entities
{
    public partial class Food
    {
        public Food()
        {
            Users = new HashSet<User>();
        }

        public decimal FoodId { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
