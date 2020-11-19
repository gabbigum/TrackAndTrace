using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Entities;
using DataLayer.Storage;
using BusinessObjects.TrackAndTrace;

namespace DataLayer.IO
{
    public class DataWriter
    {
        private static DataWriter instance;

        private DataWriter()
        {

        }

        public static DataWriter Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new DataWriter();
                }
                return instance;
            }
        }

        public bool appendUserToCSV(Person person)
        {
            if (person == null)
                return false;

            if (!File.Exists(DataStorage.USERS_FILE))
            {
                using (StreamWriter streamWriter = new StreamWriter(DataStorage.USERS_FILE, true))
                    streamWriter.WriteLine(DataStorage.USERS_HEADER_TEXT);
            }


            using (StreamWriter streamWriter = new StreamWriter(DataStorage.USERS_FILE, true))
                streamWriter.WriteLine(person.toString());


             return true;
        }



        public bool appendLocationToCSV(Location location)
        {
            if (location == null)
                return false;

            if (!File.Exists(DataStorage.LOCATIONS_FILE))
            {
                using (StreamWriter streamWriter = new StreamWriter(DataStorage.LOCATIONS_FILE, true))
                    streamWriter.WriteLine(DataStorage.LOCATIONS_HEADER_TEXT);
            }

            using (StreamWriter streamWriter = new StreamWriter(DataStorage.LOCATIONS_FILE, true))
                streamWriter.WriteLine(location.toString());
            
            return true;
        }

        public bool appendUserEventToCSV(UserEvent userEvent)
        {
            if (userEvent == null)
                return false;

            if (!File.Exists(DataStorage.USER_EVENTS_FILE))
            {
                using (StreamWriter streamWriter = new StreamWriter(DataStorage.USER_EVENTS_FILE, true))
                    streamWriter.WriteLine(DataStorage.USER_EVENTS_HEADER_TEXT);
            }

            using (StreamWriter streamWriter = new StreamWriter(DataStorage.USER_EVENTS_FILE, true))
                streamWriter.WriteLine(userEvent.toString());
            return true;
        }


        public bool writeAllUsersToCSV_OnClose()
        {
            //mechanism that might not be used

            return true;
        }
     }
}
