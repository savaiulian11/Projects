using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_Proiect
{
    internal class Tabele
    {
        public appDBDataContext db = new appDBDataContext();

        private string tabeleName;
        public Tabele(string _tableName)
        {
            tabeleName = _tableName;
        }
        public List<TabeleAbstract> getTables()
        {
            if (tabeleName == "Autor")
            {
                var returnValues = (from items in db.Autors
                                       select items).ToList();
                List<Autor_> lista=new List<Autor_>();
                foreach(var item in returnValues)
                {
                    Autor_ temp=new Autor_();
                    temp.DataNastere = item.Data_Nastere;
                    temp.IDAutor = item.ID_Autor;
                    temp.Nume=item.Nume;
                    temp.Prenume=item.Prenume;

                    lista.Add(temp);
                }
                return lista.ToList<TabeleAbstract>();
            }
            if (tabeleName == "Opere_De_Arta")
            {
                var returnValues = (from items in db.Opere_De_Artas
                                    select items).ToList();
                List<OpereDeArta> lista = new List<OpereDeArta>();
                foreach (var item in returnValues)
                {
                    OpereDeArta temp=new OpereDeArta();
                    temp.IDOpera = item.ID_Opera;
                    temp.IDAutor = item.ID_Autor;
                    temp.Nume = item.Nume;
                    temp.An = item.An;
                    temp.Pret = (float)item.Pret_RON_;
                    temp.Detalii=item.Detalii;
                    temp.URL = item.ImageURL;
                    lista.Add(temp);
                }
                return lista.ToList<TabeleAbstract>();
            }
            if (tabeleName == "Users")
            {
                var returnValues = (from items in db.Users
                                    select items).ToList();
                List<User_> lista = new List<User_>();
                foreach (var item in returnValues)
                {
                    User_ temp=new User_();
                    temp.IDUser = item.ID;
                    temp.UserType = item.UserType;
                    temp.Username = item.Username;
                    temp.Password = item.Password;
                    temp.CNP = item.CNP;
                    lista.Add(temp);
                }
                return lista.ToList<TabeleAbstract>();
            }
            if (tabeleName == "Clienti")
            {
                var returnValues = (from items in db.Clientis
                                    select items).ToList();
                List<Client> lista = new List<Client>();
                foreach (var item in returnValues)
                {
                    Client temp = new Client();
                    temp.Localitate= item.Localitate;
                    temp.Nume= item.Nume;
                    temp.NumarTelefon = item.Numar_Telefon;
                    temp.IDClient = item.ID_Client;
                    temp.Prenume=item.Prenume;
                    temp.Adresa= item.Adresa;

                    lista.Add(temp);
                }
                return lista.ToList<TabeleAbstract>();
            }
            if (tabeleName == "Expozitii_Opere_De_Arta")
            {
                var returnValues = (from items in db.Expozitii_Opere_De_Artas
                                    select items).ToList();
                List<ExpozitiiOpere> lista = new List<ExpozitiiOpere>();
                foreach (var item in returnValues)
                {
                    ExpozitiiOpere temp= new ExpozitiiOpere();

                    temp.IDExpozitie = item.ID_Expozitie;
                    temp.IDOpera=item.ID_Opera;
                    temp.IDExpOpere = item.ID;

                    lista.Add(temp);
                }
                return lista.ToList<TabeleAbstract>();
            }
            if (tabeleName == "Comenzi_Opere_De_Arta")
            {
                var returnValues = (from items in db.Comenzi_Opere_De_Artas
                                    select items).ToList();
                List<ComenziOpere> lista = new List<ComenziOpere>();
                foreach (var item in returnValues)
                {
                    ComenziOpere temp= new ComenziOpere();
                    temp.IDComenziOpere = item.ID;
                    temp.IDOpera = item.ID_Opera;
                    temp.IDComenzi=item.ID_Comenzi;

                    lista.Add(temp);
                }
                return lista.ToList<TabeleAbstract>();
            }
            if (tabeleName == "Galerii")
            {
                var returnValues = (from items in db.Galeriis
                                    select items).ToList();
                List<Galerie> lista = new List<Galerie>();
                foreach (var item in returnValues)
                {
                    Galerie temp=new Galerie();
                    temp.IDGalerie = item.ID_Galerie;
                    temp.Nume = item.Nume_Galerie;
                    temp.Adresa = item.Adresa;
                    temp.Localitate = item.Localitate;
                    temp.CodPostal = item.Cod_Postal;
                    temp.URL = item.Image;

                    lista.Add(temp);
                }
                return lista.ToList<TabeleAbstract>();
            }
            if (tabeleName == "Expozitie")
            {
                var returnValues = (from items in db.Expozities
                                    select items).ToList();
                List<Expozitie_> lista = new List<Expozitie_>();
                foreach (var item in returnValues)
                {
                    Expozitie_ temp =new Expozitie_();

                    temp.IDExpozitie = item.ID_Expozitie;
                    temp.IDGalerie=item.ID_Galerie;
                    temp.Nume=item.Nume_Expozitie;
                    temp.DataInceput = item.Data_Inceput;
                    temp.DataSfarsit = item.Data_Sfarsit;

                    lista.Add(temp);
                }
                return lista.ToList<TabeleAbstract>();
            }
            if (tabeleName == "Comenzi")
            {
                var returnValues = (from items in db.Comenzis
                                    select items).ToList();
                List<Comanda> lista = new List<Comanda>();
                foreach (var item in returnValues)
                {
                    Comanda temp=new Comanda();
                    temp.IDComanda = item.ID_Comanda;
                    temp.IDClient=item.ID_Client;
                    if (item.Data_Livrare != null)
                        temp.DataLivrare = (DateTime)item.Data_Livrare;
                    else
                        temp.DataLivrare = DateTime.MinValue;
                    temp.DataPlasare = item.Data_Plasare;
                    temp.IDUser=(int)item.ID_User;

                    lista.Add(temp);
                }
                return lista.ToList<TabeleAbstract>();
            }

            return null;
        }
    }

    public class OpereDeArta : TabeleAbstract
    {
        public int IDOpera { get; set; }
        public int IDAutor { get; set; }
        public string Nume { get; set; }
        public string An { get; set; }
        public float Pret { get; set; }
        public string Detalii { get; set; }
        public string URL { get; set; }
    }
    public class Autor_ : TabeleAbstract
    {
        public int IDAutor { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public DateTime DataNastere { get; set; }
    }
    public class User_ : TabeleAbstract
    {
        public int IDUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
        public string CNP { set; get; }
    }
    public class Galerie : TabeleAbstract
    {
        public int IDGalerie { get; set; }
        public string Nume { get; set; }
        public string Adresa { get; set; }
        public string Localitate { get; set; }
        public int CodPostal { get; set; }
        public string URL { get; set; }
    }
    public class ExpozitiiOpere : TabeleAbstract
    {
        public int IDExpOpere { get; set; }
        public int IDExpozitie { get; set; }
        public int IDOpera { get; set; }
    }
    public class Expozitie_ : TabeleAbstract
    {
        public int IDExpozitie { get; set; }
        public int IDGalerie { get; set; }
        public string Nume { get; set; }
        public DateTime DataInceput { get; set; }
        public DateTime DataSfarsit { get; set; }
    }
    public class ComenziOpere : TabeleAbstract
    {
        public int IDComenziOpere { get; set; }
        public int IDOpera { get; set; }
        public int IDComenzi { get; set; }
    }
    public class Comanda : TabeleAbstract
    {
        public int IDComanda { get; set; }
        public int IDClient { get; set; }
        public int IDUser { get; set; }
        public DateTime DataPlasare { get; set; }
        public DateTime DataLivrare { get; set; }
    }
    public class Client : TabeleAbstract
    {
        public int IDClient { set; get; }
        public string Nume { set; get; }
        public string Prenume { set; get; }
        public string NumarTelefon { set; get; }
        public string Adresa { set; get; }
        public string Localitate { set; get; }
    }
}
