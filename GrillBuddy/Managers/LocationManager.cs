using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrillBuddy.DTO;

namespace GrillBuddy.Managers
{
    public class LocationManager
    {
        public IEnumerable<LocationDTO> GetAllLocations()
        {
            return new List<LocationDTO>();
        }
        public LocationDTO GetSingle(int id)
        {
            LocationDTO location = new LocationDTO();
            location.LocationId = 1;
            if (location.LocationId == id)
            {
                return location;
            }
            return null;
            
            //return Table.SingleOrDefault(c => c.LocationId == id);
        }
        //public bool EditLocation
    }
}
