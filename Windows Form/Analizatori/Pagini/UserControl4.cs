using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analizatori.Pagini
{
    public partial class UserControl4 : UserControl
    {
        public Action backToStartAction;
        public UserControl4()
        {
            InitializeComponent();
            mediaPlayer.uiMode = "none";
        }

        private void cutanatButton_Click(object sender, EventArgs e)
        {
            var strTempFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Analizatorul cutanat.mp4");
            File.WriteAllBytes(strTempFile, Properties.Resources.Analizatorul_cutanat1);
            mediaPlayer.URL = strTempFile;
        }

        private void vizualButton_Click(object sender, EventArgs e)
        {
            var strTempFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Analizatorul vizual.mp4");
            File.WriteAllBytes(strTempFile, Properties.Resources.Analizatorul_vizual1);
            mediaPlayer.URL = strTempFile;
        }

        private void acusticoVestivularButton_Click(object sender, EventArgs e)
        {
            var strTempFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Analizatorul acustico-vestivular.mp4");
            File.WriteAllBytes(strTempFile, Properties.Resources.Analizatorul_acustico_vestivular);
            mediaPlayer.URL = strTempFile;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            mediaPlayer.Ctlcontrols.stop();
            backToStartAction();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            mediaPlayer.Ctlcontrols.play();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            mediaPlayer.Ctlcontrols.stop();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            mediaPlayer.Ctlcontrols.pause();
        }
    }
}
