using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using PROG_2B_POE_Part_2.Data;
using PROG_2B_POE_Part_2.Models;
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
    /// Interaction logic for ManagerViewWindow.xaml
    /// </summary>
    public partial class ManagerViewWindow : Window
    {
        private readonly AppDbContext _context;
        public ManagerViewWindow(List<transferrableclaim> sent)
        {
            InitializeComponent();
            List<transferrableclaim> clams = new List<transferrableclaim>();
            clams = sent;
            //foreach (var transferrableclaim in clams)
            //{
            //    ClaimsListBox.Items.Add(transferrableclaim.DisplayClaim());
            //}
            var firstClaim = clams.FirstOrDefault();
            MessageBox.Show($"The Claimant Name of the first entry is: {firstClaim.ClaimantName}", "First Claimant Name", MessageBoxButton.OK, MessageBoxImage.Information);//test to see that the database is being accessed correctly
            //LoadClaims();
        }

        private void LoadClaims()
        {
        var claimslist = _context.Claims.ToList();

            // Set the ListBox's ItemsSource to the ClaimantNames or another property
            ClaimsListBox.ItemsSource = claimslist;//.Select(c => c.ClaimantName).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
