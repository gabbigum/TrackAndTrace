using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessObjects.TrackAndTrace;
using BusinessObjects.Entities;
using BusinessObjects.Utilities;
using DataLayer.IO;
using System.ComponentModel;

namespace TrackAndTrace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TrackAndTraceService trackAndTrace;
        private DataLoader loader;
        private const int NAME_LENGTH = 30;
        private const int PHONE_LENGTH = 10;


        public MainWindow()
        {
            InitializeComponent();
            trackAndTrace = new TrackAndTraceService();
            loader = DataLoader.Instance;
            loader.loadAllData();

            //populate comboboxes method below maybe???
            populateComboBoxes();

        }

        private void btnAddIndividual_Click(object sender, RoutedEventArgs e)
        {
            //what the callstack looks like
            //user enters data - validations happen here
            //method from track and trace invokes - addNewIndividual()
            //writes data to the file
            //loads object to storage -- should that be coupled into addNewIndividual()???
            
            if (txtInsertFirstName.Text.Equals("")||
                txtInsertLastName.Text.Equals("") ||
                txtInsertPhoneNumber.Text.Equals(""))
            {
                MessageBox.Show("You must fill in all the fields. Please try again.");
                return;
            }

            if(txtInsertFirstName.Text.Length > NAME_LENGTH ||
                txtInsertLastName.Text.Length > NAME_LENGTH)
            {
                MessageBox.Show("Invalid name. Too many characters.");
                return;
            }

            if (txtInsertPhoneNumber.Text.Length != PHONE_LENGTH)
            {
                MessageBox.Show("Invalid phone number. You need to enter 10 digits number.");
                return;
            }

            if (Regex.IsMatch(txtInsertFirstName.Text, @"\d") ||
                Regex.IsMatch(txtInsertLastName.Text, @"\d"))
            {
                MessageBox.Show("You have entered invalid name. Please try again.");
                return;
            }

            if(!Regex.IsMatch(txtInsertPhoneNumber.Text, @"^\d+$"))
            {
                MessageBox.Show("You have entered invalid phone number. Please try again.");
                return;
            }

            bool isAdded = trackAndTrace.addNewIndividual(
                txtInsertFirstName.Text.Trim(),
                txtInsertLastName.Text.Trim(),
                txtInsertPhoneNumber.Text.Trim()
                );

            if (!isAdded)
            {
                MessageBox.Show("Could not add individual to the system. Individual already exists.");
                return;
            }


            MessageBox.Show("Individual added successfully");
        }

        private void btnAddNewLocation_Click(object sender, RoutedEventArgs e)
        {
            //what the callstack looks like
            //user enters data - validations happen here
            //method from track and trace invokes - addNewLocation()
            //writes data to the file
            //loads object to storage -- should that be coupled into addNewLocation()???
            if (txtInsertLocationName.Text.Equals("") ||
                txtInsertAddress.Text.Equals("") ||
                txtInsertLocationType.Text.Equals(""))
            {
                MessageBox.Show("You must fill in all the fields. Please try again.");
                return;
            }
            if (txtInsertFirstName.Text.Length > NAME_LENGTH ||
    txtInsertLastName.Text.Length > NAME_LENGTH)
            {
                MessageBox.Show("Invalid name. Too many characters.");
                return;
            }
            if (txtInsertLocationName.Text.Length > 50 ||
                txtInsertLocationType.Text.Length > 15 ||
                txtInsertAddress.Text.Length > 100)
            {
                MessageBox.Show("Invalid entry. You cannot have input that long.");
                return;
            }

            if (Regex.IsMatch(txtInsertLocationType.Text, @"\d"))
            {
                MessageBox.Show("Invalid location type. Cannot have digits.");
                return;
            }

            bool addLocation = trackAndTrace.addNewLocation(
                    txtInsertLocationName.Text.Trim(),
                    txtInsertAddress.Text.Trim(),
                    txtInsertLocationType.Text.Trim()
                );

            if(!addLocation)
            {
                MessageBox.Show("Could not add location to the system. Location already exists.");
                return;
            }

            MessageBox.Show("Location added successfully.");
        }

        private void btnRecordContact_Click(object sender, RoutedEventArgs e)
        {
            //user enters data - validations happen here
            //method from track and trace invokes - recordContact()
            //writes data to the file
            //loads object to storage -- should that be coupled into addNewLocation()???

            //needs to check if the contacts and location exist


            if(cboSelectContactPersonOne.SelectedItem == null ||
                cboSelectContactPersonTwo.SelectedItem == null||
                cboSelectContactLocation.SelectedItem == null)
            {
                MessageBox.Show("You cannot have empty fields. Please try again.");
                return;
            }

            String personOneID = cboSelectContactPersonOne.SelectedItem.ToString().Split(' ')[0];
            String personTwoID = cboSelectContactPersonTwo.SelectedItem.ToString().Split(' ')[0];
            String locationID = cboSelectContactLocation.SelectedItem.ToString().Split(' ')[0];

            bool recordContact = trackAndTrace.recordContact(
                loader.loadPersonByID(personOneID),
                loader.loadPersonByID(personTwoID),
                loader.loadLocationByID(locationID));

            if(!recordContact)
            {
                MessageBox.Show("Could not execute record contact. Please try again.");
                return;
            }


            MessageBox.Show("Contact added successfully.");
        }

        private void btnRecordVisit_Click(object sender, RoutedEventArgs e)
        {
            if(cboSelectVisitPerson.SelectedItem == null ||
                cboSelectVisitLocation.SelectedItem == null)
            {
                MessageBox.Show("You cannot have empty fields. Please try again.");
                return;
            }

            String personID = cboSelectVisitPerson.SelectedItem.ToString().Split(' ')[0];
            String locationID = cboSelectVisitLocation.SelectedItem.ToString().Split(' ')[0];

            bool recordVisit = trackAndTrace.recordVisit(
                loader.loadPersonByID(personID),
                loader.loadLocationByID(locationID));

            if (!recordVisit)
            {
                MessageBox.Show("Could not execute record visit. Please try again.");
                return;
            }


            MessageBox.Show("Visit added successfully.");
        }

        

        private void btnGeneratePhonesBetweenDate_Click(object sender, RoutedEventArgs e)
        {
            //Generate a list of all the telephone numbers of all individuals who have been
            //contacts of a specified individual after a specified date and time

            //have select individual window - check
            //have date time windows - check
            //get first date time -> 
            //start comparing and generating objects for person.phoneNumber ->
            //as comparing for the second date time
            //telephone numbers are stored in users- we can access the user by user id directly from data storage
            //datastorage userevents will have every event with that person check every event if it contains that user and get the other user phone
            //
            bool isValidOperation = true;
            try
            {
                DateTime dtStart = dtStartDate.SelectedDate.Value;
                DateTime dtEnd = dtEndDate.SelectedDate.Value;

                if (cboSelectGenerateContactsPerson.SelectedItem == null ||
                    dtStart == null ||
                    dtEnd == null)
                {
                    MessageBox.Show("You cannot have empty fields. Please try again ");
                    return;
                }

                String personID = cboSelectGenerateContactsPerson.SelectedItem.ToString().Split(' ')[0];

                Console.WriteLine(dtStart);
                Console.WriteLine(dtEnd);

                HashSet<String> phonesQuery = trackAndTrace.generatePhonesBetweenDate(
                    loader.loadPersonByID(personID),
                    dtStart,
                    dtEnd
                    );
                populateLstBoxQueries(phonesQuery);
            } catch(InvalidOperationException ex)
            {
                isValidOperation = false;
                Console.WriteLine(ex.Message);
            }

            if (!isValidOperation)
            {
                MessageBox.Show("You must specify date.");
                return;
            }

            MessageBox.Show("Phones generated successfully.");
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            trackAndTrace.
                dataStorage.
                writer.
                updateIDPersistanceFile(
                UIDGenerator.Instance.UniqueUserID.ToString(),
                UIDGenerator.Instance.UniqueLocationID.ToString()
                );
        }

        private void populateLstBoxQueries(HashSet<String> set)
        {
            lstBoxQueries.Items.Clear();
            foreach(var item in set)
            {
                lstBoxQueries.Items.Add(item);
            }
        }
        private void populateComboBoxes()
        {
            foreach (KeyValuePair<String, Person> entry in trackAndTrace.dataStorage.Users)
            {
                cboSelectContactPersonOne.Items.Add(entry.Key + " " + entry.Value.FirstName + " " + entry.Value.LastName);
                cboSelectContactPersonTwo.Items.Add(entry.Key + " " + entry.Value.FirstName + " " + entry.Value.LastName);
                cboSelectVisitPerson.Items.Add(entry.Key + " " + entry.Value.FirstName + " " + entry.Value.LastName);
                cboSelectGenerateContactsPerson.Items.Add(entry.Key + " " + entry.Value.FirstName + " " + entry.Value.LastName);
            }

            foreach (KeyValuePair<String, Location> entry in trackAndTrace.dataStorage.Locations)
            {
                cboSelectContactLocation.Items.Add(entry.Key + " " + entry.Value.LocationName);
                cboSelectVisitLocation.Items.Add(entry.Key + " " + entry.Value.LocationName);
                cboSelectGenerateLocations.Items.Add(entry.Key + " " + entry.Value.LocationName);
            }
        }

        private void btnGenerateLocationContactsBetweenDate_Click(object sender, RoutedEventArgs e)
        {
            bool isValidOperation = true;
            try
            {
                DateTime dtStart = dtLocationStartDate.SelectedDate.Value;
                DateTime dtEnd = dtLocationEndDate.SelectedDate.Value;

                if (cboSelectGenerateLocations.SelectedItem == null ||
                    dtStart == null ||
                    dtEnd == null)
                {
                    MessageBox.Show("You cannot have empty fields. Please try again ");
                    return;
                }

                String locationID = cboSelectGenerateLocations.SelectedItem.ToString().Split(' ')[0];

                Console.WriteLine(dtStart);
                Console.WriteLine(dtEnd);

                HashSet<String> locationsQuery = trackAndTrace.generateLocationContactsBetweenDate(
                    loader.loadLocationByID(locationID),
                    dtStart,
                    dtEnd
                    );
                populateLstBoxQueries(locationsQuery);
            }
            catch (InvalidOperationException ex)
            {
                isValidOperation = false;
                Console.WriteLine(ex.Message);
            }

            if (!isValidOperation)
            {
                MessageBox.Show("You must specify date.");
                return;
            }

            MessageBox.Show("Phones generated successfully.");
        }
    }
}
