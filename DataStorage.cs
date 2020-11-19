using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.IO;
using BusinessObjects.Entities;
using BusinessObjects.TrackAndTrace;

namespace DataLayer.Storage
{
    public class DataStorage
    {
        public static string DATA_FOLDER_PATH = @"C:\TrackAndTraceData";
        public static string USER_EVENTS_FILE = @"C:\TrackAndTraceData\userevents.csv";
        public Dictionary<String, Person> Users { get; }

        public Dictionary<String, Location> Locations { get; }

        public  List<UserEvent> UserEvents{ get; }

        private static DataStorage instance;

        private DataStorage()
        {
            Users = new Dictionary<String, Person>();
            Locations = new Dictionary<String, Location>();
            UserEvents = new List<UserEvent>();


            //DataLoader loader = DataLoader.Instance.loadUserDataFromCSV();
            //TODO on every start load all the data even if there is no data 

            //TODO on every entry from the user write data and at the same time load to the collections
        }

        public static DataStorage Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new DataStorage();
                }
                return instance;
            }
        }


        //might be useless
        

    }
}
