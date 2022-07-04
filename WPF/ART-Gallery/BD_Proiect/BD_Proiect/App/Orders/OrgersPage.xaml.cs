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

namespace BD_Proiect.Orders
{
    public partial class OrgersPage : UserControl
    {
        appDBDataContext db=new appDBDataContext();
        static string connectionString = "Server=.;Database=BD_Proiect;Trusted_Connection=true";
        SqlConnection connection = new SqlConnection(connectionString);
        DataSet DS = new DataSet();
        SqlDataAdapter DA = new SqlDataAdapter();

        public OrgersPage(int userID)
        {
            InitializeComponent();

            var comenziUser=(from comenzi in db.Comenzis
                         join useri in db.Users on comenzi.ID_User equals useri.ID
                         join comenziOpere in db.Comenzi_Opere_De_Artas on comenzi.ID_Comanda equals comenziOpere.ID_Comenzi
                         join opere in db.Opere_De_Artas on comenziOpere.ID_Opera equals opere.ID_Opera
                         join clienti in db.Clientis on comenzi.ID_Client equals clienti.ID_Client
                         where useri.ID==userID
                         select new
                         {
                             numeOpera=opere.Nume,
                             idOpera=opere.ID_Opera,
                             anOpera=opere.An,
                             pretOpera=opere.Pret_RON_,
                             detaliiOpera=opere.Detalii,
                             dLivrare=comenzi.Data_Livrare,
                             dPlasare=comenzi.Data_Plasare,
                             numeClient=clienti.Nume+clienti.Prenume,
                             numarClient=clienti.Numar_Telefon,
                             adresaClient=clienti.Adresa
                         }).ToList();

            List<Orders> orderList = new List<Orders>();
            foreach (var comenzi in comenziUser)
            {
                orderList.Add(new Orders()
                {
                    NameOpera = comenzi.numeOpera,
                    DeliveryDate = Convert.ToDateTime(comenzi.dLivrare),
                    PlacementDate = Convert.ToDateTime(comenzi.dPlasare),
                    Year = comenzi.anOpera,
                    Price = comenzi.pretOpera.ToString(),
                    Details = comenzi.detaliiOpera,
                    FullName = comenzi.numeClient,
                    Phone_Number = comenzi.numarClient,
                    Address = comenzi.adresaClient
                });
            }

            OrdersDataGrid.ItemsSource = orderList;
        }
    }

    public class Orders
    {
        public string NameOpera { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime PlacementDate { get; set; }
        public string Year { get; set; }
        public string Price { get; set; }
        public string Details { get; set; }
        public string FullName { get; set; }
        public string Phone_Number { get; set; }
        public string Address { get; set; }
    }
}
