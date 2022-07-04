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
using System.Data.SqlClient;
using System.Data.Common;

namespace BD_Proiect.Gallery
{
    /// <summary>
    /// Interaction logic for PaintingsPage.xaml
    /// </summary>
    public partial class PaintingsPage : UserControl
    {
        appDBDataContext db=new appDBDataContext();

        public Action<int> backToExpositions;
        public Action<int> newOrderPage;
        public Action backToGallery;

        static string connectionString = "Server=.;Database=BD_Proiect;Trusted_Connection=true";
        SqlConnection connection = new SqlConnection(connectionString);
        DataSet DS = new DataSet();
        SqlDataAdapter DA = new SqlDataAdapter();

        public PaintingsPage()
        {
            InitializeComponent();
        }

        public void table(int expositionID)
        {
            var opere=(from opera in db.Opere_De_Artas
                       join operaExpozitii in db.Expozitii_Opere_De_Artas
                       on opera.ID_Opera equals operaExpozitii.ID_Opera
                       where operaExpozitii.ID_Expozitie==expositionID
                       select opera).ToList();

            List<OperaArta> opereArta=new List<OperaArta>();
            foreach (var item in opere)
            {
                OperaArta operaArta = new OperaArta();
                operaArta.ID_Opera = item.ID_Opera;
                operaArta.Nume = item.Nume;
                operaArta.Detalii=item.Detalii;
                operaArta.An=item.An;
                opereArta.Add(operaArta);
            }
            PaintingsDataGrid.ItemsSource = opereArta;
        }

        private void ExpositionsButton_Click(object sender, RoutedEventArgs e)
        {
            backToExpositions(-1);
        }

        private void GallerysButton_Click(object sender, RoutedEventArgs e)
        {
            backToGallery();
        }

        private void PaintingsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OperaArta opera = (OperaArta)PaintingsDataGrid.SelectedItem;
            newOrderPage(opera.ID_Opera);
        }
    }
    class OperaArta
    {
        public int ID_Opera { get; set; }
        public string Nume { get; set; }
        public string An { get; set; }
        public string Detalii { get; set; }
    }
}
