using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Utilities;


namespace BusinessObjects.Entities
{
    public class Location
    {
        public String LocationName { get; }
        private String Address { get; }
        public int LocationID { get; }
        private String LocationType { get; }

        public Location(String locationName, String address, String locationType, bool hasID = true)
        {
            this.LocationName = locationName;
            this.Address = address;
            this.LocationType = locationType;

            if(!hasID)
            {
                this.LocationID = UIDGenerator.Instance.nextUniqueLocationID();
            }
        }

        public string toString()
        {
            return LocationID + "," + LocationName + "," + Address + "," + LocationType;
        }

        public override bool Equals(object obj)
        {
            return obj is Location location &&
                   LocationName == location.LocationName &&
                   Address == location.Address &&
                   LocationType == location.LocationType;
        }
    }
}

