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

namespace BD_Proiect
{
    /// <summary>
    /// Interaction logic for MasterWindow.xaml
    /// </summary>
    public partial class MasterWindow : Window
    {
        public MasterWindow()
        {
            InitializeComponent();
            this.Hide();
            newLogin();

        }
        private void newLogin()
        {
            Login loginPage = new Login();
            loginPage.Show();
            loginPage.registerButtonAction += openRegisterPage;
            loginPage.loginButtonAction += openMainPage;
            loginPage.exitButtonAction += closeApp;
        }
        private void newRegister()
        {
            Register registerPage = new Register();
            registerPage.Show();
            registerPage.backToLoginButtonAction += openLoginPage;
            registerPage.registerButtonAction += openLoginPage;
            registerPage.exitButtonAction += closeApp;
        }
        private void newMain(int userID)
        {
            MainWindow mainPage = new MainWindow(userID);
            mainPage.Show();
            mainPage.exitButtonAction += closeApp;
            mainPage.signOutButtonAction += openLoginPage;
            mainPage.signOutButtonAction += closeApp;
        }

        private void openRegisterPage(Window loginPage)
        {
            newRegister();
            loginPage.Close();
        }
        private void openMainPage(Window loginPage, int userID)
        {
            newMain(userID);
            loginPage.Close();
        }

        private void openLoginPage(Window window)
        {
            newLogin();
            window.Close();
        }

        private void closeApp(Window window)
        {
            this.Close();
            window.Close();
        }

    }
}
