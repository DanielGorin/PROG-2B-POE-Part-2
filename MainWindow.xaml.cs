using PROG_2B_POE_Part_2.Data;
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
    public partial class MainWindow : Window
    {
        private readonly AppDbContext _context;
        // Default constructor
        public MainWindow()
        {
            InitializeComponent();
        }

        // Parameterized constructor
        public MainWindow(AppDbContext context) : this() // Calls the default constructor
        {
            _context = context; // Store the DbContext
            if (_context == null)
            {
                MessageBox.Show("Database context is null!", "Null Context", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {

                //int x = _context.Claims.Count();
                //MessageBox.Show(x.ToString()+" Database context is initialized.", "Context Initialized", MessageBoxButton.OK, MessageBoxImage.Information);
                MessageBox.Show(" Database context is initialized.", "Context Initialized", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            // Check if there are any claims in the database
            var firstClaim = _context.Claims.FirstOrDefault();

            // If there is no claim in the database, show a message saying it's empty
            if (firstClaim == null)
            {
                MessageBox.Show("No claims found in the database.", "Database Empty", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                // Show the claimant name of the first entry
                MessageBox.Show($"The Claimant Name of the first entry is: {firstClaim.ClaimantName}", "First Claimant Name", MessageBoxButton.OK, MessageBoxImage.Information);
            }
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
            LecturerViewWindow objViewWindow = new LecturerViewWindow(_context);
            this.Hide();
            objViewWindow.Show();
            //------------------------------------------------------------------------------------------------------------------------------------------------
        }

        private void TempManagerButton_Click(object sender, RoutedEventArgs e)
        {
            //Navigates to the ManagerViewWindow
            //This button is temporary used to naviagte tot he lecturer window before login and registration functinality has been added
            //------------------------------------------------------------------------------------------------------------------------------------------------
            ManagerViewWindow objViewWindow = new ManagerViewWindow(_context);
            this.Hide();
            objViewWindow.Show();
            //------------------------------------------------------------------------------------------------------------------------------------------------
        }
    }
}