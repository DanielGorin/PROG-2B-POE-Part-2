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
        public LecturerViewWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Naviagtes to the LecturerCreateWindow
            //----------------------------------------------------------------------------------------------------------------------------------------------
            LecturerCreateWindow objViewWindow = new LecturerCreateWindow();
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
    }
}
