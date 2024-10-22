﻿using System;
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
        public static string USERS_HEADER_TEXT = "User ID,First Name,Last Name,Phone Number";
        public static string LOCATIONS_HEADER_TEXT = "Location ID,Location Name,Address,Location Type";
        public static string USER_EVENTS_HEADER_TEXT = "Person 1,Person 2,Location ID,Date";//not confirmed

        public static string ID_PERSISTANCE_FILE = @"C:\TrackAndTraceData\id_count.csv";
        public static string USER_EVENTS_FILE = @"C:\TrackAndTraceData\userevents.csv";
        public static string USERS_FILE = @"C:\TrackAndTraceData\users.csv";
        public static string LOCATIONS_FILE = @"C:\TrackAndTraceData\locations.csv";

        public Dictionary<String, Person> Users { get; }

        public Dictionary<String, Location> Locations { get; }

        public  List<UserEvent> UserEvents{ get; }

        public DataWriter writer { get; }

        private static DataStorage instance;

        private DataStorage()
        {
            Users = new Dictionary<String, Person>();
            Locations = new Dictionary<String, Location>();
            UserEvents = new List<UserEvent>();
            writer = DataWriter.Instance;
            writer.createFiles();
            
            //loader.loadAllData();
            //if files do not exist create them then load the data
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
