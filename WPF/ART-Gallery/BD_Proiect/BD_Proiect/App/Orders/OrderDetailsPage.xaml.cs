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
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
//
namespace BD_Proiect.Orders
{
    public partial class OrderDetailsPage : UserControl
    {
        public appDBDataContext db = new appDBDataContext();

        public Action acceptOrder;
        public Action<int> declineOrder;
        public OrderDetailsPage(int userID,int operaID)
        {
            InitializeComponent();

            var opera=(from item in db.Opere_De_Artas
                       where item.ID_Opera==operaID
                       select item).FirstOrDefault();

            numeOLabel.Content = opera.Nume;
            pretLabel.Content = opera.Pret_RON_;

            BitmapImage bitmap=new BitmapImage();

            bitmap.BeginInit();
            bitmap.UriSource=new Uri(opera.ImageURL,UriKind.Absolute);
            bitmap.EndInit();

            ImageGrid.Source = bitmap;

            var newClient = new Clienti
            {
                ID_Client = userID,
                Nume = numeTextBox.Text,
                Prenume = prenumeTextBox.Text,
                Numar_Telefon = telefonTextBox.Text,
                Adresa = addressTextBox.Text,
                Localitate = locTextBox.Text
            };

            db.Clientis.InsertOnSubmit(newClient);
            db.SubmitChanges();
        }

        private void declineButton_Click(object sender, RoutedEventArgs e)
        {
            declineOrder(-1);
        }
    }
}
