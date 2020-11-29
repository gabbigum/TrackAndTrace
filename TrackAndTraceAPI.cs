using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Entities;

namespace BusinessObjects.TrackAndTrace
{
    interface TrackAndTraceAPI
    {

        bool addNewIndividual(String firstName, String lastName, String phoneNumber);
        bool addNewLocation(String locationName, String address, String locationType);

        bool recordContact(Person person1, Person person2, Location location);

        bool recordVisit(Person person, Location location);

        HashSet<String> generatePhonesBetweenDate(Person person, DateTime timeStart, DateTime timeEnd);
        HashSet<String> generateLocationContactsBetweenDate(Location location, DateTime timeStart, DateTime timeEnd);
    }
}
