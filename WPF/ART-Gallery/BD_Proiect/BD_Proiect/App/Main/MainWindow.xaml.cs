using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
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

namespace BD_Proiect
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        appDBDataContext db=new appDBDataContext();

        public Action<MainWindow> exitButtonAction;
        public Action ordersButtonAction;
        public Action<MainWindow> signOutButtonAction;

        MasterUserControlGallery masterUserControlGallery;
        int userID;
        int userType;
        
        public MainWindow(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            setUser();
            masterUserControlGallery = new MasterUserControlGallery(mainGrid);
        }

        private void setUser()
        {
            var user=(from useri in db.Users
                      where useri.ID==userID
                      select useri).FirstOrDefault();
            UsernameLabel.Content = user.Username;
            userType = user.UserType;

            if (userType == 2)
                AdminButton.Visibility = Visibility.Visible;
            else
                AdminButton.Visibility = Visibility.Collapsed;
        }

        private void Commands_Button_Click(object sender, RoutedEventArgs e)
        {
            masterUserControlGallery.newOrders(userID);
        }

        private void Gallerys_Button_Click(object sender, RoutedEventArgs e)
        {
            masterUserControlGallery.newGallerySearch(userID);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            exitButtonAction(this);
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            exitButtonAction(this);
        }

        private void Sign_Out_Button_Click(object sender, RoutedEventArgs e)
        {
            signOutButtonAction(this);
         }

        private void Employee_Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            masterUserControlGallery.newAdminPage();
        }
    }
}
