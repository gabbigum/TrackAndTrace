using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Entities;

namespace BusinessObjects.TrackAndTrace
{
    public class UserEvent
    {
        public Person Person1 { get; }
        public Person Person2 { get; }
        public String LocationID { get; }
        public DateTime DateTime { get; }

        private String ToString;


        public UserEvent(Person person, String locationID)
        {
            this.Person1 = person;
            this.LocationID = locationID;
            DateTime = DateTime.Now;
            ToString = Person1.UserID + "," + "empty," + LocationID + "," + DateTime.ToString();
        }
        public UserEvent(Person person1, Person person2, String locationID)
        {
            this.Person1 = person1;
            this.Person2 = person2;
            this.LocationID = locationID;
            this.DateTime = DateTime.Now;
            ToString = Person1.UserID + "," + Person2.UserID + "," + LocationID + "," + DateTime.ToString();
        }

        public string toString()
        {
            return ToString;
        }

    }
}
