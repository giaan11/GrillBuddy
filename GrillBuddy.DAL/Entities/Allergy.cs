using System;
using System.Collections.Generic;

#nullable disable

namespace GrillBuddy.DAL.Entities
{
    public partial class Allergy
    {
        public Allergy()
        {
            UserAllergies = new HashSet<UserAllergy>();
        }

        public decimal AllergyId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<UserAllergy> UserAllergies { get; set; }
    }
}
