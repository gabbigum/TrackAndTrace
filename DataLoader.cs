using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Entities;
using DataLayer.Storage;

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


        //load data from events.csv
        //load data from users.csv
        //load data from locations.csv
    }
}
