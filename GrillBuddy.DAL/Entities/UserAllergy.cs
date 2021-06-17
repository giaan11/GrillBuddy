using System;
using System.Collections.Generic;

#nullable disable

namespace GrillBuddy.DAL.Entities
{
    public partial class UserAllergy
    {
        public decimal AllergyId { get; set; }
        public decimal UserId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Allergy Allergy { get; set; }
        public virtual User User { get; set; }
    }
}
