using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Utilities;

namespace BusinessObjects.Entities
{
    public class Person
    {
        public String FirstName { get; }
        public String LastName { get; }

        public int UserID { get; }
        public String PhoneNumber { get; }


        public Person(String firstName, String lastName, String phoneNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.UserID = UIDGenerator.Instance.nextUniqueID();
        }
       
    }
}
