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

        public UserEvent(Person person, String location)
        {
            this.Person1 = person;
            this.Location = location;
            DateTime = DateTime.Now;
        }
        public UserEvent(Person person1, Person person2, String location)
        {
            this.Person1 = person1;
            this.Person2 = person2;
            this.Location = location;
            this.DateTime = DateTime.Now;
        }


        public bool recordEvent()
        {
            return false;
        }

    }
}
