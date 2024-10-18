using Microsoft.EntityFrameworkCore;
using PROG_2B_POE_Part_2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PROG_2B_POE_Part_2
{
    /// <summary>
    /// Interaction logic for LecturerCreateWindow.xaml
    /// </summary>
    public partial class LecturerCreateWindow : Window
    {
        private readonly AppDbContext _context;
        int nextnum = 0;
        List<transferrableclaim> clams = new List<transferrableclaim>();
        public LecturerCreateWindow(List<transferrableclaim> sent)
        {
            InitializeComponent();
            clams = sent;
            nextnum = clams.Count + 1;
            IDTextBox.Text = nextnum.ToString();
            DateTextBox.Text = DateOnly.FromDateTime(DateTime.Now).ToString();

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Naviagtes out of the create claim window without creating a claim back to the LecturerViewWindow
            //----------------------------------------------------------------------------------------------------------------------------------------------
            LecturerViewWindow objViewWindow = new LecturerViewWindow(clams);
            this.Hide();
            objViewWindow.Show();
            //----------------------------------------------------------------------------------------------------------------------------------------------

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Uploads a file
            //----------------------------------------------------------------------------------------------------------------------------------------------

            //----------------------------------------------------------------------------------------------------------------------------------------------

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Creates a Claim
            //----------------------------------------------------------------------------------------------------------------------------------------------
            //Checks that all the valid fields are full
            //---------------------------------------------------------
            bool valid = true;//used to determine that all the fields are filled in correctly
            if (TitleTextBox.Text == "") 
            {
                MessageBox.Show("Please add a title to your claim.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                valid = false;
            }
            if (decimal.TryParse(RateTextBox.Text,out decimal rateres))
            {

            }
            else
            {
                MessageBox.Show("Please add a valid hourly rate.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                valid=false;
            }
            if (int.TryParse(HWTextBox.Text, out int hourres))
            {

            }
            else
            {
                MessageBox.Show("Please add a valid number of hours worked", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                valid=false;
            }
            if (CommentTextBox.Text == "")
            {
                MessageBox.Show("Please add a comment to your claim.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                valid=false;
            }
            //---------------------------------------------------------
            //adds the calim to the list
            //---------------------------------------------------------
            if (valid)
            {
                int claimId = int.Parse(IDTextBox.Text.Trim());
                string claimantName = "John Doe";
                decimal hourlyRate = decimal.Parse(RateTextBox.Text.Trim());
                int hoursWorked = int.Parse(HWTextBox.Text.Trim());
                string comments = CommentTextBox.Text.Trim();
                DateOnly dateLogged = DateOnly.FromDateTime(DateTime.Now);  // Example: using the current date as logged date
                string uploadedFile = "";  // Handle file uploads separately if needed
                string status = "Pending";  // Default status as pending, can be set differently

                // Create a new transferrableclaim object and set its values
                transferrableclaim NC = new transferrableclaim();
                NC.CreateClaim(claimId, claimantName, hourlyRate, hoursWorked, comments, dateLogged, uploadedFile, status);
                clams.Add(NC);
                //Naviagtes out of the create claim window without creating a claim back to the LecturerViewWindow
                //----------------------------------------------------------------------------------------------------------------------------------------------
                LecturerViewWindow objViewWindow = new LecturerViewWindow(clams);
                this.Hide();
                objViewWindow.Show();
                //----------------------------------------------------------------------------------------------------------------------------------------------
            }
            //----------------------------------------------------------------------------------------------------------------------------------------------
        }
        string newhw = "";
        private void RateTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool good = true;//used to ensure that the hours worked and hourly rate are valid entries
            //ensures that hours qworked and hourly rate have valid entries
            //---------------------------------------------------------
            if (decimal.TryParse(RateTextBox.Text, out decimal rateresval))
            {

            }
            else
            {
                good = false;
            }
            if (int.TryParse(newhw, out int hourresval))
            {

            }
            else
            {
                good = false;
            }
            //-------------------------------------------------------------
            //updates teh total payemnt
            //------------------------------------------------------------
            if (good)
            {
                decimal pay =Math.Round((rateresval * hourresval),2);
                PayemntTextbox.Text = pay.ToString();
            }
            //------------------------------------------------------------
        }

        private void HWTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            newhw = HWTextBox.Text.Trim();
            bool good = true;//used to ensure that the hours worked and hourly rate are valid entries
            //ensures that hours qworked and hourly rate have valid entries
            //---------------------------------------------------------
            if (decimal.TryParse(RateTextBox.Text, out decimal rateresval))
            {

            }
            else
            {
                good = false;
            }
            if (int.TryParse(HWTextBox.Text, out int hourresval))
            {

            }
            else
            {
                good = false;
            }
            //-------------------------------------------------------------
            //updates teh total payemnt
            //------------------------------------------------------------
            if (good)
            {
                decimal pay = Math.Round((rateresval * hourresval), 2);
                PayemntTextbox.Text = pay.ToString();
            }
            else
            {
            }
            //------------------------------------------------------------
        }
    }
}
