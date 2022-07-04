using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
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

namespace BD_Proiect
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public appDBDataContext db=new appDBDataContext();

        public Action<Login> registerButtonAction;
        public Action<Login, int> loginButtonAction;
        public Action<Login> exitButtonAction;
        public int ID { get; set; }

        public SecureString SecurePassword { private get; set; }
        public Login()
        {
            InitializeComponent();
        }

        private void checkbxShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            txtPassword.Text = passwordBox.Password;
            passwordBox.Visibility = System.Windows.Visibility.Collapsed;
            txtPassword.Visibility = System.Windows.Visibility.Visible;

            txtPassword.Focus();
        }

        private void checkbxShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordBox.Password = txtPassword.Text;
            passwordBox.Visibility = System.Windows.Visibility.Visible;
            txtPassword.Visibility = System.Windows.Visibility.Collapsed;

            passwordBox.Focus();
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(this.DataContext != null)
                ((dynamic)this.DataContext).SecurePassword = ((PasswordBox)sender).Password;
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            registerButtonAction(this);
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {

            if (txtUsername.Text == "" && passwordBox.Password == "")
                MessageBox.Show("Username and Password fields are empty!", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);

            var user=(from useri in db.Users
                      where useri.Username == txtUsername.Text
                      select useri).FirstOrDefault();
            
            if(user == null)
                System.Windows.MessageBox.Show("Invalid Login please check username and password");
            else
            {
                if (user.Password != passwordBox.Password)
                {
                    System.Windows.MessageBox.Show("Invalid Login please check username and password");
                    return;
                }
                System.Windows.MessageBox.Show("Login succesful!");
                loginButtonAction(this, user.ID);
            }
        }

        private void Login1_Closed(object sender, EventArgs e)
        {
            exitButtonAction(this);
        }
    }
}
