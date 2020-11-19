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
        private Person Person1 { get; }
        private Person Person2 { get; }
        private String Location { get; }
        private DateTime DateTime { get; }

        private String ToString;


        public UserEvent(Person person, String location)
        {
            this.Person1 = person;
            this.Location = location;
            DateTime = DateTime.Now;
            ToString = Person1.UserID + "," + Location + "," + DateTime.ToString();
        }
        public UserEvent(Person person1, Person person2, String location)
        {
            this.Person1 = person1;
            this.Person2 = person2;
            this.Location = location;
            this.DateTime = DateTime.Now;
            ToString = Person1.UserID + ","+ Person2.UserID + "," + Location + "," + DateTime.ToString();
        }

        public string toString()
        {
            return ToString;
        }

        public bool recordEvent()
        {
            //send message to datawriter
            return false;
        }

    }
}
