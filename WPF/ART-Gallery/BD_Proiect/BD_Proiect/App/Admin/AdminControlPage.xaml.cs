using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Threading;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Common;
using System.Data.Linq.Mapping;

namespace BD_Proiect
{
    /// <summary>
    /// Interaction logic for AdminControlPage.xaml
    /// </summary>
    public partial class AdminControlPage : UserControl
    {
        public appDBDataContext db=new appDBDataContext();
        List<TabeleAbstract> Items = new List<TabeleAbstract>();
        string tabeleName;
        public AdminControlPage()
        {
            InitializeComponent();

            DataGrid.CanUserAddRows = true;
            var datamodel = new AttributeMappingSource().GetModel(typeof(appDBDataContext));
            List<string> tables = new List<string>();
            foreach (var r in datamodel.GetTables())
                tables.Add(r.TableName.Substring(4));

            TableComboBox.DataContext = tables;
        }
        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }
        private void DeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete record?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                while (DataGrid.SelectedItems.Count >= 1)
                {
                    if (tabeleName == "Autor")
                    {
                        Autor_ tab = (Autor_)DataGrid.SelectedItem;
                        Items.Remove(tab);
                        Autor_ selectie = (Autor_)DataGrid.SelectedItem;
                        var deletedItem = (from item in db.Autors
                                           where item.ID_Autor == selectie.IDAutor
                                           select item).FirstOrDefault();
                        db.Autors.DeleteOnSubmit(deletedItem);
                        db.SubmitChanges();
                        continue;
                    }
                    if (tabeleName == "Opere_De_Arta")
                    {
                        OpereDeArta tab = (OpereDeArta)DataGrid.SelectedItem;
                        Items.Remove(tab);
                        OpereDeArta selectie = (OpereDeArta)DataGrid.SelectedItem;
                        var deletedItem = (from item in db.Opere_De_Artas
                                           where item.ID_Opera == selectie.IDOpera
                                           select item).FirstOrDefault();
                        db.Opere_De_Artas.DeleteOnSubmit(deletedItem);
                        db.SubmitChanges();
                        continue;
                    }
                    if (tabeleName == "Users")
                    {
                        User_ tab = (User_)DataGrid.SelectedItem;
                        Items.Remove(tab);
                        User_ selectie = (User_)DataGrid.SelectedItem;
                        var deletedItem = (from item in db.Users
                                           where item.ID == selectie.IDUser
                                           select item).FirstOrDefault();
                        db.Users.DeleteOnSubmit(deletedItem);
                        db.SubmitChanges();
                        continue;
                    }
                    if (tabeleName == "Clienti")
                    {
                        Client tab = (Client)DataGrid.SelectedItem;
                        Items.Remove(tab);
                        Client selectie = (Client)DataGrid.SelectedItem;
                        var deletedItem = (from item in db.Clientis
                                           where item.ID_Client == selectie.IDClient
                                           select item).FirstOrDefault();
                        db.Clientis.DeleteOnSubmit(deletedItem);
                        db.SubmitChanges();
                        continue;
                    }
                    if (tabeleName == "Expozitii_Opere_De_Arta")
                    {
                        ExpozitiiOpere tab = (ExpozitiiOpere)DataGrid.SelectedItem;
                        Items.Remove(tab);
                        ExpozitiiOpere selectie = (ExpozitiiOpere)DataGrid.SelectedItem;
                        var deletedItem = (from item in db.Expozitii_Opere_De_Artas
                                           where item.ID == selectie.IDExpOpere
                                           select item).FirstOrDefault();
                        db.Expozitii_Opere_De_Artas.DeleteOnSubmit(deletedItem);
                        db.SubmitChanges();
                        continue;
                    }
                    if (tabeleName == "Comenzi_Opere_De_Arta")
                    {
                        ComenziOpere tab = (ComenziOpere)DataGrid.SelectedItem;
                        Items.Remove(tab);
                        ComenziOpere selectie = (ComenziOpere)DataGrid.SelectedItem;
                        var deletedItem = (from item in db.Comenzi_Opere_De_Artas
                                           where item.ID == selectie.IDComenziOpere
                                           select item).FirstOrDefault();
                        db.Comenzi_Opere_De_Artas.DeleteOnSubmit(deletedItem);
                        db.SubmitChanges();
                        continue;
                    }
                    if (tabeleName == "Galerii")
                    {
                        Galerie tab = (Galerie)DataGrid.SelectedItem;
                        Items.Remove(tab);
                        Galerie selectie = (Galerie)DataGrid.SelectedItem;
                        var deletedItem = (from item in db.Galeriis
                                           where item.ID_Galerie == selectie.IDGalerie
                                           select item).FirstOrDefault();
                        db.Galeriis.DeleteOnSubmit(deletedItem);
                        db.SubmitChanges();
                        continue;
                    }
                    if (tabeleName == "Expozitie")
                    {
                        Expozitie_ tab = (Expozitie_)DataGrid.SelectedItem;
                        Items.Remove(tab);
                        Expozitie_ selectie = (Expozitie_)DataGrid.SelectedItem;
                        var deletedItem = (from item in db.Expozities
                                           where item.ID_Expozitie == selectie.IDExpozitie
                                           select item).FirstOrDefault();
                        db.Expozities.DeleteOnSubmit(deletedItem);
                        db.SubmitChanges();
                        continue;
                    }
                    if (tabeleName == "Comenzi")
                    {
                        Comanda tab = (Comanda)DataGrid.SelectedItem;
                        Items.Remove(tab);
                        Comanda selectie = (Comanda)DataGrid.SelectedItem;
                        var deletedItem = (from item in db.Comenzis
                                           where item.ID_Comanda == selectie.IDComanda
                                           select item).FirstOrDefault();
                        db.Comenzis.DeleteOnSubmit(deletedItem);
                        db.SubmitChanges();
                        continue;
                    }
                }
                MessageBox.Show("Deleted Record!");
            }
        }

        private void TableComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid.ItemsSource = null;
            tabeleName = TableComboBox.SelectedItem.ToString();
            Tabele tabele = new Tabele(tabeleName);
            List<TabeleAbstract> items = tabele.getTables();
            DataGrid.ItemsSource = items;
            if (tabeleName == "Autor")
                coloaneAutor();
            if (tabeleName == "Opere_De_Arta")
                coloaneOpereDeArta();
            if (tabeleName == "Users")
                coloaneUser();
            if (tabeleName == "Clienti")
                coloaneClient();
            if (tabeleName == "Expozitii_Opere_De_Arta")
                coloaneExpozitiiOpere();
            if (tabeleName == "Comenzi_Opere_De_Arta")
                coloaneComenziOpere();
            if (tabeleName == "Galerii")
                coloaneGalerie();
            if (tabeleName == "Expozitie")
                coloaneExpozitie();
            if (tabeleName == "Comenzi")
                coloaneComanda();
        }

        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            Application.Current.Dispatcher.InvokeAsync(new Action(() =>
            {
            }), DispatcherPriority.ContextIdle);
        }

        private void coloaneAutor()
        {
            DataGrid.Columns.Clear();
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = "IDAutor";
            textColumn.Binding = new Binding("IDAutor");
            DataGridTextColumn textColumn1 = new DataGridTextColumn();
            textColumn1.Header = "Nume";
            textColumn1.Binding = new Binding("Nume");
            DataGridTextColumn textColumn2 = new DataGridTextColumn();
            textColumn2.Header = "Prenume";
            textColumn2.Binding = new Binding("Prenume");
            DataGridTextColumn textColumn3 = new DataGridTextColumn();
            textColumn3.Header = "DataNastere";
            textColumn3.Binding = new Binding("DataNastere");
            DataGrid.Columns.Add(textColumn);
            DataGrid.Columns.Add(textColumn1);
            DataGrid.Columns.Add(textColumn2);
            DataGrid.Columns.Add(textColumn3);
        }
        private void coloaneOpereDeArta()
        {
            DataGrid.Columns.Clear();
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = "IDOpera";
            textColumn.Binding = new Binding("IDOpera");
            DataGridTextColumn textColumn1 = new DataGridTextColumn();
            textColumn1.Header = "IDAutor";
            textColumn1.Binding = new Binding("IDAutor");
            DataGridTextColumn textColumn2 = new DataGridTextColumn();
            textColumn2.Header = "Nume";
            textColumn2.Binding = new Binding("Nume");
            DataGridTextColumn textColumn3 = new DataGridTextColumn();
            textColumn3.Header = "An";
            textColumn3.Binding = new Binding("An");
            DataGridTextColumn textColumn4 = new DataGridTextColumn();
            textColumn4.Header = "Pret";
            textColumn4.Binding = new Binding("Pret");
            DataGridTextColumn textColumn5 = new DataGridTextColumn();
            textColumn5.Header = "Detalii";
            textColumn5.Binding = new Binding("Detalii");
            DataGridTextColumn textColumn6 = new DataGridTextColumn();
            textColumn6.Header = "URL";
            textColumn6.Binding = new Binding("URL");
            DataGrid.Columns.Add(textColumn);
            DataGrid.Columns.Add(textColumn1);
            DataGrid.Columns.Add(textColumn2);
            DataGrid.Columns.Add(textColumn3);
            DataGrid.Columns.Add(textColumn4);
            DataGrid.Columns.Add(textColumn5);
            DataGrid.Columns.Add(textColumn6);
        }
        private void coloaneUser()
        {
            DataGrid.Columns.Clear();
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = "IDUser";
            textColumn.Binding = new Binding("IDUser");
            DataGridTextColumn textColumn1 = new DataGridTextColumn();
            textColumn1.Header = "Username";
            textColumn1.Binding = new Binding("Username");
            DataGridTextColumn textColumn2 = new DataGridTextColumn();
            textColumn2.Header = "Password";
            textColumn2.Binding = new Binding("Password");
            DataGridTextColumn textColumn3 = new DataGridTextColumn();
            textColumn3.Header = "UserType";
            textColumn3.Binding = new Binding("UserType");
            DataGridTextColumn textColumn4 = new DataGridTextColumn();
            textColumn4.Header = "CNP";
            textColumn4.Binding = new Binding("CNP");
            DataGrid.Columns.Add(textColumn);
            DataGrid.Columns.Add(textColumn1);
            DataGrid.Columns.Add(textColumn2);
            DataGrid.Columns.Add(textColumn3);
            DataGrid.Columns.Add(textColumn4);
        }
        private void coloaneGalerie()
        {
            DataGrid.Columns.Clear();
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = "IDGalerie";
            textColumn.Binding = new Binding("IDGalerie");
            DataGridTextColumn textColumn1 = new DataGridTextColumn();
            textColumn1.Header = "Nume";
            textColumn1.Binding = new Binding("Nume");
            DataGridTextColumn textColumn2 = new DataGridTextColumn();
            textColumn2.Header = "Adresa";
            textColumn2.Binding = new Binding("Adresa");
            DataGridTextColumn textColumn3 = new DataGridTextColumn();
            textColumn3.Header = "Localitate";
            textColumn3.Binding = new Binding("Localitate");
            DataGridTextColumn textColumn4 = new DataGridTextColumn();
            textColumn4.Header = "CodPostal";
            textColumn4.Binding = new Binding("CodPostal");
            DataGridTextColumn textColumn5 = new DataGridTextColumn();
            textColumn5.Header = "URL";
            textColumn5.Binding = new Binding("URL");
            DataGrid.Columns.Add(textColumn);
            DataGrid.Columns.Add(textColumn1);
            DataGrid.Columns.Add(textColumn2);
            DataGrid.Columns.Add(textColumn3);
            DataGrid.Columns.Add(textColumn4);
            DataGrid.Columns.Add(textColumn5);
        }
        private void coloaneExpozitiiOpere()
        {
            DataGrid.Columns.Clear();
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = "IDExpOpere";
            textColumn.Binding = new Binding("IDExpOpere");
            DataGridTextColumn textColumn1 = new DataGridTextColumn();
            textColumn1.Header = "IDExpozitie";
            textColumn1.Binding = new Binding("IDExpozitie");
            DataGridTextColumn textColumn2 = new DataGridTextColumn();
            textColumn2.Header = "IDOpera";
            textColumn2.Binding = new Binding("IDOpera");
            DataGrid.Columns.Add(textColumn);
            DataGrid.Columns.Add(textColumn1);
            DataGrid.Columns.Add(textColumn2);
        }
        private void coloaneExpozitie()
        {
            DataGrid.Columns.Clear();
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = "IDExpozitie";
            textColumn.Binding = new Binding("IDExpozitie");
            DataGridTextColumn textColumn1 = new DataGridTextColumn();
            textColumn1.Header = "IDGalerie";
            textColumn1.Binding = new Binding("IDGalerie");
            DataGridTextColumn textColumn2 = new DataGridTextColumn();
            textColumn2.Header = "Nume";
            textColumn2.Binding = new Binding("Nume");
            DataGridTextColumn textColumn3 = new DataGridTextColumn();
            textColumn3.Header = "DataInceput";
            textColumn3.Binding = new Binding("DataInceput");
            DataGridTextColumn textColumn4 = new DataGridTextColumn();
            textColumn4.Header = "DataSfarsit";
            textColumn4.Binding = new Binding("DataSfarsit");
            DataGrid.Columns.Add(textColumn);
            DataGrid.Columns.Add(textColumn1);
            DataGrid.Columns.Add(textColumn2);
            DataGrid.Columns.Add(textColumn3);
            DataGrid.Columns.Add(textColumn4);
        }
        private void coloaneComenziOpere()
        {
            DataGrid.Columns.Clear();
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = "IDComenziOpere";
            textColumn.Binding = new Binding("IDComenziOpere");
            DataGridTextColumn textColumn1 = new DataGridTextColumn();
            textColumn1.Header = "IDOpera";
            textColumn1.Binding = new Binding("IDOpera");
            DataGridTextColumn textColumn2 = new DataGridTextColumn();
            textColumn2.Header = "IDComenzi";
            textColumn2.Binding = new Binding("IDComenzi");
            DataGrid.Columns.Add(textColumn);
            DataGrid.Columns.Add(textColumn1);
            DataGrid.Columns.Add(textColumn2);
        }
        private void coloaneComanda()
        {
            DataGrid.Columns.Clear();
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = "IDComanda";
            textColumn.Binding = new Binding("IDComanda");
            DataGridTextColumn textColumn1 = new DataGridTextColumn();
            textColumn1.Header = "IDClient";
            textColumn1.Binding = new Binding("IDClient");
            DataGridTextColumn textColumn2 = new DataGridTextColumn();
            textColumn2.Header = "IDUser";
            textColumn2.Binding = new Binding("IDUser");
            DataGridTextColumn textColumn3 = new DataGridTextColumn();
            textColumn3.Header = "DataPlasare";
            textColumn3.Binding = new Binding("DataPlasare");
            DataGridTextColumn textColumn4 = new DataGridTextColumn();
            textColumn4.Header = "DataLivrare";
            textColumn4.Binding = new Binding("DataLivrare");
            DataGrid.Columns.Add(textColumn);
            DataGrid.Columns.Add(textColumn1);
            DataGrid.Columns.Add(textColumn2);
            DataGrid.Columns.Add(textColumn3);
            DataGrid.Columns.Add(textColumn4);
        }
        private void coloaneClient()
        {
            DataGrid.Columns.Clear();
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = "IDClient";
            textColumn.Binding = new Binding("IDClient");
            DataGridTextColumn textColumn1 = new DataGridTextColumn();
            textColumn1.Header = "Nume";
            textColumn1.Binding = new Binding("Nume");
            DataGridTextColumn textColumn2 = new DataGridTextColumn();
            textColumn2.Header = "Prenume";
            textColumn2.Binding = new Binding("Prenume");
            DataGridTextColumn textColumn3 = new DataGridTextColumn();
            textColumn3.Header = "NumarTelefon";
            textColumn3.Binding = new Binding("NumarTelefon");
            DataGridTextColumn textColumn4 = new DataGridTextColumn();
            textColumn4.Header = "Adresa";
            textColumn4.Binding = new Binding("Adresa");
            DataGridTextColumn textColumn5 = new DataGridTextColumn();
            textColumn5.Header = "Localitate";
            textColumn5.Binding = new Binding("Localitate");
            DataGrid.Columns.Add(textColumn);
            DataGrid.Columns.Add(textColumn1);
            DataGrid.Columns.Add(textColumn2);
            DataGrid.Columns.Add(textColumn3);
            DataGrid.Columns.Add(textColumn4);
            DataGrid.Columns.Add(textColumn5);
        }
    }
}
