using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Entities;
using DataLayer.Storage;
using BusinessObjects.TrackAndTrace;
using BusinessObjects.Utilities;

namespace DataLayer.IO
{
    public class DataLoader
    {    
        private static DataLoader instance;

        private DataLoader()
        {
            //UIDGenerator.Instance.UniqueID = 400;
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
            if (!File.Exists(fileName))
            {
                return false;
            }

            DataStorage dataStorage = DataStorage.Instance;

            using (StreamReader reader = new StreamReader(File.OpenRead(fileName)))
            { 
                String header = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    String line = reader.ReadLine();
                    string[] values = line.Split(',');

                    if (!dataStorage.Users.ContainsKey(values[0]))
                    {
                        dataStorage.Users.Add(
                            values[0],
                            new Person(
                                values[1],
                                values[2],
                                values[3]));
                    }

                }
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

            using (StreamReader reader = new StreamReader(File.OpenRead(fileName)))
            { 
                String header = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    String line = reader.ReadLine();
                    string[] values = line.Split(',');


                    if (!dataStorage.Locations.ContainsKey(values[0]))
                    {
                        dataStorage.Locations.Add(
                            values[0],
                            new Location(
                                values[1],
                                values[2],
                                values[3]));
                    }

                }
            }
            return true;
        }

        public bool loadUserEventsFromCSV(string fileName)
        {
            //create fileexist method
            if (!File.Exists(fileName))
            {
                return false;
            }
            //start reading form file
            //for every line check if there's person 2
            //if there is load the data for the person 2 in the storage as well
            DataStorage dataStorage = DataStorage.Instance;

            using (StreamReader reader = new StreamReader(File.OpenRead(fileName)))
            {

                string header = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    if (values[1].Equals("empty"))
                    {
                        dataStorage.UserEvents.Add(new UserEvent(loadPersonByID(values[0]), values[2]));
                        //verify format
                    }
                    else
                    {
                        dataStorage.UserEvents.Add(new UserEvent(loadPersonByID(values[0]), loadPersonByID(values[1]), values[2]));
                    }
                }
            }
            return true;
        }

        public void loadIDPersistanceFile()
        { 
            String data = "";
            using (StreamReader reader = new StreamReader(File.OpenRead(DataStorage.ID_PERSISTANCE_FILE)))
            {
                data = reader.ReadLine();
            }


            string[] tokens = data.Split(',');
            UIDGenerator.Instance.UniqueUserID = Int32.Parse(tokens[0]);
            UIDGenerator.Instance.UniqueLocationID = Int32.Parse(tokens[1]);
        }

        public void loadAllData()
        {
            if (File.Exists(DataStorage.USERS_FILE))
            {
                try
                {
                    loadUserDataFromCSV(DataStorage.USERS_FILE);
                } catch (IOException ex)
                {
                    ex.ToString();
                }

            }

            if (File.Exists(DataStorage.LOCATIONS_FILE))
            {
                try
                {
                   loadLocationsFromCSV(DataStorage.LOCATIONS_FILE);
                } catch (IOException ex)
                {
                    ex.ToString();
                }

            }

            if (File.Exists(DataStorage.USER_EVENTS_FILE))
            {
                try
                {
                    loadUserEventsFromCSV(DataStorage.USER_EVENTS_FILE);
                } catch (IOException ex)
                {
                    ex.ToString();
                }

            }

            if (File.Exists(DataStorage.ID_PERSISTANCE_FILE))
            {
                try
                {
                    loadIDPersistanceFile();
                } catch (IOException ex)
                {
                    ex.ToString();
                }
            }
        } 

        public Person loadPersonByID(string userID)
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

        


        private Location loadLocationByID(string locationID)
        {
            DataStorage storage = DataStorage.Instance;

            StreamReader reader = new StreamReader(File.OpenRead(DataStorage.LOCATIONS_FILE));

            string header = reader.ReadLine();

            while(!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');

                if (values[0].Equals(locationID))
                {
                    return new Location(values[1], values[2], values[3]);
                }
            }
            throw new ArgumentException();
        }



    }
}
