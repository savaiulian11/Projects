using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analizatori
{
    public partial class Form1 : Form
    {
        UserControl1 startPage = new UserControl1();
        Pagini.UserControl2 cursuriPage=new Pagini.UserControl2();
        Pagini.UserControl3 testePage=new Pagini.UserControl3();
        Pagini.UserControl4 videoPage=new Pagini.UserControl4();
        public Form1()
        {
            InitializeComponent();
            startPageInitialization();
        }

        private void startPageInitialization()
        {
            //actiunea este o functie din StartPage care este apelata in momentul apasarii butonului pentru cursuri,iar actiunea are ca functii atasata cursuriPageInitialization
            startPage.cursuriPageAction += cursuriPageInitialization;
            startPage.videoPageAction += videoPageInitialization;
            startPage.testePageAction += testePageInitialization;
            panel.Controls.Clear();
            panel.Controls.Add(startPage);
        }

        private void cursuriPageInitialization()
        {
            cursuriPage.backToStartAction += startPageInitialization;
            panel.Controls.Clear();
            panel.Controls.Add(cursuriPage);
        }

        private void videoPageInitialization()
        {
            videoPage.backToStartAction += startPageInitialization;
            panel.Controls.Clear();
            panel.Controls.Add(videoPage);
        }

        private void testePageInitialization()
        {
            testePage.backToStartAction += startPageInitialization;
            panel.Controls.Clear();
            panel.Controls.Add(testePage);
        }
    }
}
