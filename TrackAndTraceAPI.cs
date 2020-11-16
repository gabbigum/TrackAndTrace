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

        bool recordContact(Person person1, Person person2);

        bool recordVisit(Person person, Location location);

        bool generateContactsBetweenDate();
        bool generateLocationContactsBetweenDate();
    }
}
