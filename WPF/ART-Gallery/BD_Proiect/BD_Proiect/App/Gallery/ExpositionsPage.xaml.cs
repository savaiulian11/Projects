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
    /// Interaction logic for ExpositionsPage.xaml
    /// </summary>
    public partial class ExpositionsPage : UserControl
    {
        appDBDataContext db=new appDBDataContext();

        public Action backToGallery;
        public Action<int> getPaintings;
        private bool isCreated = false;

        public ExpositionsPage()
        {
            InitializeComponent();
        }

        public void table(int galleryID)
        {
            if(!isCreated)
            {
                var expozitii = (from item in db.Expozities
                                 where item.ID_Galerie == galleryID
                                 select item).ToList();
                List<Expozitie> expositionList = new List<Expozitie>();
                foreach (var item in expozitii)
                {
                    Expozitie g = new Expozitie();
                    g.ID = item.ID_Expozitie;
                    g.Name = item.Nume_Expozitie;
                    g.dataInceput = item.Data_Inceput.ToString();
                    g.dataSfarsit = item.Data_Sfarsit.ToString();
                    expositionList.Add(g);
                }

                ExpositionsDataGrid.ItemsSource = expositionList;
            }            
        }

        private void Gallerys_Button_Click(object sender, RoutedEventArgs e)
        {
            isCreated = false;
            backToGallery();
        }

        private void ExpositionsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            isCreated = true;
            Expozitie exposition = (Expozitie)ExpositionsDataGrid.SelectedItem;
            getPaintings(exposition.ID);
        }
    }
    public class Expozitie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string dataInceput { get; set; }
        public string dataSfarsit { get; set; }
    }
}
