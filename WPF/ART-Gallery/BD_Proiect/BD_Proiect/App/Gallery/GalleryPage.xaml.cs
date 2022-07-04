using System;
using System.Collections;
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

namespace BD_Proiect.Gallery
{
    /// <summary>
    /// Interaction logic for GalleryPage.xaml
    /// </summary>
    public partial class GalleryPage : UserControl
    {
        appDBDataContext db = new appDBDataContext();

        public Action backToStatUp;
        public Action<int> getExpositions;

        public GalleryPage()
        {
            InitializeComponent();

            var galerii=(from item in db.Galeriis
                         select item).ToList();
            List<Galerie> galeryList=new List<Galerie>();

            foreach (var item in galerii)
            {
                Galerie g = new Galerie();
                g.ID = item.ID_Galerie;
                g.Name = item.Nume_Galerie;
                g.Adress = item.Adresa;
                g.Localitate = item.Localitate;
                g.Cod_Postal = item.Cod_Postal;
                g.ImageUrl = item.Image;
                galeryList.Add(g);
            }

            GalleryDataGrid.ItemsSource = galeryList;
        }

        private void Gallerys_Button_Click(object sender, RoutedEventArgs e)
        {
            backToStatUp();
        }

        private void GalleryDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Galerie gallery = (Galerie)GalleryDataGrid.SelectedItem;
            getExpositions(gallery.ID);
        }
    }
    public class Galerie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Localitate { get; set; }
        public int Cod_Postal { get; set; }
        public string ImageUrl { get; set; }
    }
}
