using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Entities;
using DataLayer.Storage;

namespace BusinessObjects.TrackAndTrace
{
    class TrackAndTraceService : TrackAndTraceAPI
    {

        private DataStorage dataStorage;

        public bool addNewIndividual(string firstName, string lastName, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public bool addNewLocation(string locationName, string address, string locationType)
        {
            throw new NotImplementedException();
        }

        public bool generateContactsBetweenDate()
        {
            throw new NotImplementedException();
        }

        public bool generateLocationContactsBetweenDate()
        {
            throw new NotImplementedException();
        }

        public bool recordContact(Person person1, Person person2, Location location)
        {
            throw new NotImplementedException();
            //need to implement getLocationByID
        }

        public bool recordVisit(Person person, Location location)
        {
            throw new NotImplementedException();
        }
    }
}
