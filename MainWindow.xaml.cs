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


namespace TrackAndTrace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TrackAndTraceService trackAndTrace;


        public MainWindow()
        {
            InitializeComponent();
            trackAndTrace = new TrackAndTraceService();

        }

        private void btnAddIndividual_Click(object sender, RoutedEventArgs e)
        {
            //what would the callstack look like
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

        }


    }
}
