using GrillBuddy.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrillBuddy.Managers
{
    public static class ReservationManager
    {
        public static ReservationDTO GetSingle(int id)
        {
            var found = GetAll().FirstOrDefault(R => R.ID == id);
            if (found != null)
            {
                return found;
            }
            throw new Exception("Not Found");
        }
        public static List<ReservationDTO> GetAll()
        {
            return new List<ReservationDTO>();
        }
        /*public static void TotalFood()
        {
            return true;
        }*/
        public static bool Create(ReservationDTO reservation)
        {
            if(GetAll().FirstOrDefault(R => R.ID == reservation.ID) == null)
            {
                return true;
            }return false;
        }
        public static bool Edit(int id, ReservationDTO reservation)
        {
            return true;
        }
        public static bool Delete(int id)
        {
            return true;
        }
    }
}
