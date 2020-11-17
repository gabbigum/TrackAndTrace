using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Enums;
using BusinessObjects.Utilities;


namespace BusinessObjects.Entities
{
    public class Location
    {
        private String LocationName { get; }
        private String Address { get; }
        private int LocationID { get; }
        private String LocationType { get; }

        public Location(String locationName, String address, String locationType)
        {
            this.LocationName = locationName;
            this.Address = address;
            this.LocationType = locationType;
            LocationID = UIDGenerator.Instance.nextUniqueID();
        }
        
    }
}

