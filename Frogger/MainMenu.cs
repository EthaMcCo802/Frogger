using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Frogger
{
    public partial class MainMenu : UserControl
    {
        SoundPlayer menu = new SoundPlayer(Properties.Resources.Menu);
        public MainMenu()
        {
            InitializeComponent();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            MainScreen ms = new MainScreen();
            Form f = this.FindForm();
            f.Controls.Remove(this);
            f.Controls.Add(ms);
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Close();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            menu.Play();
            Cursor.Hide();
        }
    }
}
