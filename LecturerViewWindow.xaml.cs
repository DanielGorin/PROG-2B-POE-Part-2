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
    /// Interaction logic for LecturerViewWindow.xaml
    /// </summary>
    public partial class LecturerViewWindow : Window
    {
        //List ofr holding the claims databsse
        List<transferrableclaim> clams = new List<transferrableclaim>();
        //Startup of the Lecturer View WIndow
        //--------------------------------------------------------------------------
        public LecturerViewWindow(List<transferrableclaim> sent)
        {
            InitializeComponent();
            clams = sent;
            foreach (var j in clams)
            ddLoadList();
            downlloadbutton.Visibility = Visibility.Collapsed;
            JustificationTextBox.Visibility = Visibility.Collapsed;
            JustificationTitle.Visibility = Visibility.Collapsed;

        }
        //--------------------------------------------------------------------------
        int keynum = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Naviagtes to the LecturerCreateWindow
            //----------------------------------------------------------------------------------------------------------------------------------------------
            LecturerCreateWindow objViewWindow = new LecturerCreateWindow(clams);
            this.Hide();
            objViewWindow.Show();
            //----------------------------------------------------------------------------------------------------------------------------------------------
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Downloads the File
            //----------------------------------------------------------------------------------------------------------------------------------------------

            //----------------------------------------------------------------------------------------------------------------------------------------------
        }

        private void ClaimsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            downlloadbutton.Visibility = Visibility.Collapsed;
            JustificationTextBox.Visibility = Visibility.Collapsed;
            JustificationTitle.Visibility = Visibility.Collapsed;
            string sel = "";
            string subsel = "";
            int com = 0;
            int keynum = 0;
            if (ClaimsListBox.SelectedItem != null)
            {
                sel = ClaimsListBox.SelectedItem.ToString();
                com = sel.IndexOf(",");
                subsel = sel.Substring(0, com);
                keynum = int.Parse(subsel);
            }
            Populate(clams[keynum - 1]);
            if (clams[keynum - 1].Status == "Denied")
            {
                JustificationTextBox.Visibility = Visibility.Visible;
                JustificationTitle.Visibility = Visibility.Visible;
            }
            downlloadbutton.Visibility = Visibility.Visible;
        }
        public void Populate(transferrableclaim claim)
        {
            ClaimIDTextBox.Text = claim.ClaimId.ToString();
            HourlyRateTextBox.Text = claim.HourlyRate.ToString("F2"); // Format to 2 decimal places
            HoursWorkedTextBox.Text = claim.HoursWorked.ToString();
            DateTextBox.Text = claim.DateLogged.ToString("yyyy-MM-dd"); // Format the date
            CommentTextBox.Text = claim.ClaimantComments;
            StatusTextBox.Text = claim.Status;
            PayemntTextBox.Text = claim.amountOwed().ToString("F2"); // Amount owed, formatted to 2 decimal places
        }
        public void LoadList(string tus)
        {
            ClaimsListBox.Items.Add("");
            ClaimsListBox.Items.Clear();
            foreach (var j in clams)
            {
                if (j.Status == tus)
                {
                    ClaimsListBox.Items.Add(j.DisplayClaim());
                }
            }
        }
        public void ddLoadList()
        {
            ClaimsListBox.Items.Add("");
            ClaimsListBox.Items.Clear();
            foreach (var j in clams)
            {
                if (j.Status == ListCatagoryDropDown.Text)
                {
                    ClaimsListBox.Items.Add(j.DisplayClaim());
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ddLoadList();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //Navigates back to the LogIn Window
            //----------------------------------------------------------------------------------------------------------------------------------------------
            MainWindow objViewWindow = new MainWindow();
            this.Hide();
            objViewWindow.Visibility=Visibility.Visible;
            //-----------------------
        }
    }
}
