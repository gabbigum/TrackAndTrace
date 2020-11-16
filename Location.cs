using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Enums;


namespace BusinessObjects.Entities
{
    class Location
    {
        private String locationName;
        private String address;
        private String locationID;
        private LocationType locationType;

        public Location(String locationName, String address, LocationType locationType)
        {
            this.locationName = locationName;
            this.address = address;
            this.locationType = locationType;
        }

        public String LocationName { get; }
        public String Address { get; }
        public String LocationID { get; }
        public LocationType LocationType { get; }
    }
}

