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
    /// Interaction logic for ManagerViewWindow.xaml
    /// </summary>
    public partial class ManagerViewWindow : Window
    {
        private readonly AppDbContext _context;
        public ManagerViewWindow(AppDbContext context)
        {
            InitializeComponent();
            _context = context; //Store the DbContext
            if (context == null)
            {
                MessageBox.Show("Database context is null!", "Null Context", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show("Database context is initialized.", "Context Initialized", MessageBoxButton.OK, MessageBoxImage.Information);
            }
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
