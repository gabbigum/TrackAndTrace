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


        public Person(String firstName, String lastName, String phoneNumber, bool hasID = true)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            //don't create new id everytime a person is created
            if (!hasID)
            {
                UserID = UIDGenerator.Instance.nextUniqueID();
            }
        }

        public string toString()
        {
            return UserID + "," + FirstName + "," + LastName + "," + PhoneNumber;
        }

        public override bool Equals(object obj)
        {
            Person p = obj as Person;

            return 
                this.FirstName == p.FirstName
                && this.LastName == p.LastName
                && this.PhoneNumber == p.PhoneNumber;
        }
    }
}
