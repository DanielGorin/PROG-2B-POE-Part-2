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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            //Navigates to the non-functional Registration GUI
            //----------------------------------------------------------------------------------------------------------------------------------------------
            RegistrationWindow objViewWindow = new RegistrationWindow();
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
            LecturerViewWindow objViewWindow = new LecturerViewWindow();
            this.Hide();
            objViewWindow.Show();
            //------------------------------------------------------------------------------------------------------------------------------------------------
        }

        private void TempManagerButton_Click(object sender, RoutedEventArgs e)
        {
            //Navigates to the ManagerViewWindow
            //This button is temporary used to naviagte tot he lecturer window before login and registration functinality has been added
            //------------------------------------------------------------------------------------------------------------------------------------------------
            ManagerViewWindow objViewWindow = new ManagerViewWindow();
            this.Hide();
            objViewWindow.Show();
            //------------------------------------------------------------------------------------------------------------------------------------------------
        }
    }
}