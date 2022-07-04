using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analizatori
{
    public partial class UserControl1 : UserControl
    {
        public Action cursuriPageAction;
        public Action videoPageAction;
        public Action testePageAction;
        public UserControl1()
        {
            InitializeComponent();
            stiaiCaPDFViewer.Hide();
        }

        private void cursuriButton_Click(object sender, EventArgs e)
        {
            stiaiCaPDFViewer.Hide();
            cursuriPageAction();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            if (File.Exists("stiatiCa.pdf"))
                File.Delete("stiatiCa.pdf");
            ((Form)this.TopLevelControl).Close();
        }

        private void stiaiCaButton_Click(object sender, EventArgs e)
        {
            //vector de byte pt ca in Resource pdf-ul e salvat in octeti
            byte[] PDF = Properties.Resources.Șțiați_că;
            openPDF(PDF, "stiatiCa.pdf");
            stiaiCaPDFViewer.Show();
        }

        private void videoButton_Click(object sender, EventArgs e)
        {
            stiaiCaPDFViewer.Hide();
            videoPageAction();
        }

        private void testeButton_Click(object sender, EventArgs e)
        {
            stiaiCaPDFViewer.Hide();
            testePageAction();
        }
        private void openPDF(byte[] PDF, string fileName)
        {
            MemoryStream ms = new MemoryStream(PDF);
            FileStream f = new FileStream(fileName, FileMode.OpenOrCreate);
            ms.WriteTo(f);
            f.Close();
            ms.Close();
            stiaiCaPDFViewer.LoadFile(fileName);
        }
    }
}
