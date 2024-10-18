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
        public LecturerCreateWindow(AppDbContext context)
        {
            InitializeComponent();
            _context = context; // Store the DbContext
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Naviagtes out of the create claim window without creating a claim back to the LecturerViewWindow
            //----------------------------------------------------------------------------------------------------------------------------------------------
            LecturerViewWindow objViewWindow = new LecturerViewWindow(_context);
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

            //----------------------------------------------------------------------------------------------------------------------------------------------
        }
    }
}
