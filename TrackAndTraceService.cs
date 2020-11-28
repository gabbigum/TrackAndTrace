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

        public DataStorage dataStorage { get; }

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
            Location location = new Location(locationName, address, locationType, false);

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

        public HashSet<String> generatePhonesBetweenDate(Person person, DateTime timeStart, DateTime timeEnd)
        {
            HashSet<String> phoneNumbers = new HashSet<String>();

            foreach(var userEvent in dataStorage.UserEvents)
            {

                if (userEvent.DateTime >= timeStart && userEvent.DateTime <= timeEnd)
                {
                    if (person.Equals(userEvent.Person1))
                    {
                        if (userEvent.Person2 != null)
                        {
                            string nameAndNumber = userEvent.Person2.FirstName + " " + userEvent.Person2.LastName + " - " + userEvent.Person2.PhoneNumber;
                            phoneNumbers.Add(nameAndNumber);
                        }
                    }
                    if (person.Equals(userEvent.Person2))
                    {
                        string nameAndNumber = userEvent.Person1.FirstName + " " + userEvent.Person1.LastName + " -" + userEvent.Person1.PhoneNumber;
                        phoneNumbers.Add(nameAndNumber);
                    }
                }
            }

            return phoneNumbers;
        }

        public bool generateLocationContactsBetweenDate()
        {
            throw new NotImplementedException();
        }

        public bool recordContact(Person person1, Person person2, Location location)
        {
            if (!dataStorage.Users.ContainsKey(person1.UserID.ToString()))
            {
                return false;
            }

            if (!dataStorage.Users.ContainsKey(person2.UserID.ToString()))
            {
                return false;
            }

            if (!dataStorage.Locations.ContainsKey(location.LocationID.ToString()))
            {
                return false;
            }
            UserEvent userEvent = new UserEvent(person1, person2, location.LocationID.ToString());
            dataStorage.UserEvents.Add(userEvent);
            dataStorage.writer.appendUserEventToCSV(userEvent);
            return true;
        }

        public bool recordVisit(Person person, Location location)
        {
            if (!dataStorage.Users.ContainsKey(person.UserID.ToString()))
            {
                return false;
            }

            if (!dataStorage.Locations.ContainsKey(location.LocationID.ToString()))
            {
                return false;
            }

            UserEvent userEvent = new UserEvent(person, location.LocationID.ToString());
            dataStorage.UserEvents.Add(userEvent);
            dataStorage.writer.appendUserEventToCSV(userEvent);
            return true;
        }
    }
}
