using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analizatori.Pagini
{
    public partial class UserControl2 : UserControl
    {
        public Action backToStartAction;
        public UserControl2()
        {
            InitializeComponent();
            cursuriPDFViewer.Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (File.Exists("cutanat.pdf"))
                File.Delete("cutanat.pdf");
            if (File.Exists("introducere.pdf"))
                File.Delete("introducere.pdf");
            if (File.Exists("vizual.pdf"))
                File.Delete("vizual.pdf");
            if (File.Exists("acustico.pdf"))
                File.Delete("acustico.pdf");
            if (File.Exists("patologii.pdf"))
                File.Delete("patologii.pdf");
            backToStartAction();
        }

        private void introducereButton_Click(object sender, EventArgs e)
        {
            byte[] PDF = Properties.Resources.Introducere;
            openPDF(PDF,"introducere.pdf");
            cursuriPDFViewer.Show();
        }
        
        private void cutanatButton_Click(object sender, EventArgs e)
        {
            byte[] PDF = Properties.Resources.ANALIZATORUL_CUTANAT;
            openPDF(PDF,"cutanat.pdf");
            cursuriPDFViewer.Show();
        }

        private void vizualButton_Click(object sender, EventArgs e)
        {
            byte[] PDF = Properties.Resources.Analizatorul_vizual;
            openPDF(PDF,"vizual.pdf");
            cursuriPDFViewer.Show();
        }

        private void acusticoVestivularButton_Click(object sender, EventArgs e)
        {
            byte[] PDF = Properties.Resources.ANALIZATORUL_ACUSTICO;
            openPDF(PDF,"acustico.pdf");
            cursuriPDFViewer.Show();
        }

        private void patologiileButton_Click(object sender, EventArgs e)
        {
            byte[] PDF = Properties.Resources.PATOLOGIILE;
            openPDF(PDF,"patologii.pdf");
            cursuriPDFViewer.Show();
        }
        private void openPDF(byte[] PDF, string fileName)
        {
            //creez o memorie de genul MemoryStream si ii asociez un fisier 
            MemoryStream ms = new MemoryStream(PDF);
            FileStream f = new FileStream(fileName, FileMode.OpenOrCreate);
            ms.WriteTo(f);
            f.Close();
            ms.Close();
            cursuriPDFViewer.LoadFile(fileName);
        }

        
    }
}
