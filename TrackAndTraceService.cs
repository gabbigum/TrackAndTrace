using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Entities;
using DataLayer.Storage;

namespace BusinessObjects.TrackAndTrace
{
    public class TrackAndTraceService : TrackAndTraceAPI
    {

        private DataStorage dataStorage;

        public TrackAndTraceService()
        {
            dataStorage = DataStorage.Instance;
        }

        public bool addNewIndividual(string firstName, string lastName, string phoneNumber)
        { 
            Person person = new Person(firstName, lastName, phoneNumber, false);

            //check if person already exist 
            foreach (KeyValuePair<String, Person> entry in dataStorage.Users)
            {
                if (entry.Value.Equals(person))
                {
                    return false;
                }
            }

            dataStorage.Users.Add(person.UserID.ToString(), person);
            dataStorage.writer.appendUserToCSV(person);
            return true;
        }

        public bool addNewLocation(string locationName, string address, string locationType)
        {
            Location location = new Location(locationName, address, locationType);

            foreach(KeyValuePair<String, Location> entry in dataStorage.Locations)
            {
                if (entry.Value.Equals(location))
                {
                    return false;
                }
            }

            dataStorage.Locations.Add(location.LocationID.ToString(), location);
            dataStorage.writer.appendLocationToCSV(location);
            return true;
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
