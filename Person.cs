using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Entities
{
    class Person
    {
        private String firstName;
        private String lastName;
        private String uniqueID; // generate unique id
        
        private String phoneNumber; // how many chars? 10

        public Person(String firstName, String lastName, String phoneNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
        }
        
        public String FirstName { get; }
        public String LastName { get; }

        public String UniqueID { get; }
        public String PhoneNumber { get; }

    }
}
