using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Entities;
using DataLayer.Storage;
using BusinessObjects.TrackAndTrace;

namespace DataLayer.IO
{
    public class DataLoader
    {

        private static DataLoader instance;

        private DataLoader()
        {

        }

        public static DataLoader Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new DataLoader();
                }
                return instance;
            }
        }

        public bool loadUserDataFromCSV(String fileName)
        {
            if(!File.Exists(fileName))
            {
                return false;
            }

            DataStorage dataStorage = DataStorage.Instance;

            StreamReader reader = new StreamReader(File.OpenRead(fileName));

            String header = reader.ReadLine();

            while (!reader.EndOfStream)
            {
                String line = reader.ReadLine();
                string[] values = line.Split(',');

                dataStorage.Users.Add(
                    values[0],
                    new Person(
                        values[1],
                        values[2],
                        values[3]));
            }
            // think about implementation of that what it should return
            return true;
        }

        public bool loadLocationsFromCSV(String fileName)
        {
            if (!File.Exists(fileName))
            {
                return false;
            }

            DataStorage dataStorage = DataStorage.Instance;

            StreamReader reader = new StreamReader(File.OpenRead(fileName));

            String header = reader.ReadLine();

            while (!reader.EndOfStream)
            {
                String line = reader.ReadLine();
                string[] values = line.Split(',');

                dataStorage.Locations.Add(
                    values[0],
                    new Location(
                        values[1],
                        values[2],
                        values[3]));
            }
            return true;
        }

        public void loadUserEventsFromCSV(string fileName)
        {
            //start reading form file
            //for every line check if there's person 2
            //if there is load the data for the person 2 in the storage as well
            DataStorage storage = DataStorage.Instance;

            StreamReader reader = new StreamReader(File.OpenRead(fileName));

            string header = reader.ReadLine();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');

                if (values[1].Equals("empty"))
                {
                    storage.UserEvents.Add(new UserEvent(loadPersonByID(values[0]), values[2]));
                    //verify format
                } else
                {
                    storage.UserEvents.Add(new UserEvent(loadPersonByID(values[0]),loadPersonByID(values[1]), values[2]));
                }
            }
        }

        private Person loadPersonByID(string userID)
        {
            DataStorage storage = DataStorage.Instance;

            StreamReader reader = new StreamReader(File.OpenRead(DataStorage.USER_EVENTS_FILE));

            string header = reader.ReadLine();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');

                if (values[0].Equals(userID))
                {
                    return new Person(values[1], values[2], values[3]);
                }
            }
            throw new ArgumentException("User id not found.");
        }


    }
}
