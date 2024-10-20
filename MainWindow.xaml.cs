﻿using PROG_2B_POE_Part_2.Data;
using PROG_2B_POE_Part_2.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG_2B_POE_Part_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        List<transferrableclaim> claimdata = new List<transferrableclaim>();
        private readonly AppDbContext _context;
        // Default constructor
        public MainWindow()
        {
            InitializeComponent();
            this.Hide();
        }

        // Parameterized constructor
        public MainWindow(AppDbContext context) : this() // Calls the default constructor
        {
            InitializeComponent();
            //takes the data from teh database and puts into a list of type Claims
            List<Claims> clams = new List<Claims>();
            _context = context; // Store the DbContext
            clams = _context.Claims.ToList();    
            //creates a list of type transferableclaism
            //pupulates ther transferable claimslist
            foreach (var claim in clams)
            {
                var claimInfo = new transferrableclaim();
                claimInfo.CreateClaim(claim.ClaimId, claim.ClaimantName, claim.HourlyRate, claim.HoursWorked,
                                       claim.ClaimantComments, claim.DateLogged, claim.UploadedFiles, claim.Status);
                claimdata.Add(claimInfo);
            }
            MessageBox.Show("As login functionality does not wokr please use the temporary buttons at the bottom. Lecture will log you in as john Doe", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }


        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            //Navigates to the non-functional Registration GUI
            //----------------------------------------------------------------------------------------------------------------------------------------------
            RegistrationWindow objViewWindow = new RegistrationWindow(_context);
            this.Hide();
            objViewWindow.Show();
            //----------------------------------------------------------------------------------------------------------------------------------------------

        }

        private void LoginButtonh_Click(object sender, RoutedEventArgs e)
        {
            //Brings up a popup explainng the temprorary Lecturer and manager buttons
            //------------------------------------------------------------------------------------------------------------------------------------------------

            //------------------------------------------------------------------------------------------------------------------------------------------------
        }

        private void TempLecButton_Click(object sender, RoutedEventArgs e)
        {
            //Navigates to the lecturerViewWindow
            //This button is temporary used to naviagte tot he lecturer window before login and registration functinality has been added
            //------------------------------------------------------------------------------------------------------------------------------------------------
            LecturerViewWindow objViewWindow = new LecturerViewWindow(claimdata);
            this.Visibility=Visibility.Collapsed;
            objViewWindow.Show();
            //------------------------------------------------------------------------------------------------------------------------------------------------
        }

        private void TempManagerButton_Click(object sender, RoutedEventArgs e)
        {
            //Navigates to the ManagerViewWindow
            //This button is temporary used to naviagte tot he lecturer window before login and registration functinality has been added
            //------------------------------------------------------------------------------------------------------------------------------------------------
            ManagerViewWindow objViewWindow = new ManagerViewWindow(claimdata);
            this.Hide();
            objViewWindow.Show();
            //------------------------------------------------------------------------------------------------------------------------------------------------
        }
    }
}