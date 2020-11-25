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
            //check if file contains person with these 3 parameters exist
            Person person = new Person(firstName, lastName, phoneNumber, false);

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
