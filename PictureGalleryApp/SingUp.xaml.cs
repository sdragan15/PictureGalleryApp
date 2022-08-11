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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PictureGalleryApp
{
    /// <summary>
    /// Interaction logic for SingUp.xaml
    /// </summary>
    public partial class SingUp : Page
    {
        public SingUp()
        {
            InitializeComponent();
        }


        private void logInBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Content = new Login();
            }
        }
    }
}
