using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frogger
{
    public partial class MainScreen : UserControl
    {
        Boolean upArrowDown, downArrowDown;

        List<Logs> Log = new List<Logs>();

        int xLeft = 250;
        int gap = 300;

        bool moveRight = true;
        int patternLength = 10;
        int xChange = 20;

        int newBoxCounter = 0;

        Logs hero;

        Random randGen = new Random();

        public MainScreen()
        {
            InitializeComponent();
            OnStart();
        }

        public void OnStart()
        {

        }

        private void MainScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;

            }
        }

        public void CreateLog()
        {

        }


    }
}
