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
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private readonly AppDbContext _context;
        public RegistrationWindow(AppDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void CreateAcountButton_Click(object sender, RoutedEventArgs e)
        {
            //Brings up a popup explainng the future login and registration functionality
            //------------------------------------------------------------------------------------------------------------------------------------------------

            //------------------------------------------------------------------------------------------------------------------------------------------------
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Navigates back to the LogIn Window
            //----------------------------------------------------------------------------------------------------------------------------------------------
            MainWindow objViewWindow = new MainWindow(_context);
            this.Hide();
            objViewWindow.Show();
            //----------------------------------------------------------------------------------------------------------------------------------------------
        }
    }
}
