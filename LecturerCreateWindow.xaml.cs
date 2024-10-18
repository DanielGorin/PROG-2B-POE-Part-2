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
            if (TitleTextBox.Text == "") 
            {
                MessageBox.Show("Please add a title to your claim.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (decimal.TryParse(RateTextBox.Text,out decimal rateres))
            {

            }
            else
            {
                MessageBox.Show("Please add a valid hourly rate.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (int.TryParse(HoursWorkedTextBox.Text, out int hourres))
            {

            }
            else
            {
                MessageBox.Show("Please add a valid number of hours worked", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (CommentTextBox.Text == "")
            {
                MessageBox.Show("Please add a comment to your claim.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            //---------------------------------------------------------
            //----------------------------------------------------------------------------------------------------------------------------------------------
        }
    }
}
