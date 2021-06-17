using System;
using System.Collections.Generic;

#nullable disable

namespace GrillBuddy.DAL.Entities
{
    public partial class User
    {
        public User()
        {
            UserAllergies = new HashSet<UserAllergy>();
        }

        public decimal UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal? FoodId { get; set; }
        public decimal? DrinkId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Drink Drink { get; set; }
        public virtual Food Food { get; set; }
        public virtual ICollection<UserAllergy> UserAllergies { get; set; }
    }
}
