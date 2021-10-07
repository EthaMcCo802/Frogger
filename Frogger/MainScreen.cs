using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Frogger
{
    public partial class MainScreen : UserControl
    {
        Boolean upArrowDown, downArrowDown;

        List<Logs> log = new List<Logs>();

        Water water;

        Finish finishLine;

        int yUp = 250;                                                                      
        int gap = 300;

        bool moveUp = true;

        int newLogCounter = 0;

        Logs frog;

        SolidBrush waterBrush = new SolidBrush(Color.CadetBlue);
        SolidBrush finishBrush = new SolidBrush(Color.ForestGreen);

        MainMenu mm = new MainMenu();

        SoundPlayer croak = new SoundPlayer(Properties.Resources.Croak);
        public MainScreen()
        {
            InitializeComponent();
            OnStart();
        }

        public void OnStart()
        {
            CreateLog(yUp);
            CreateLog(yUp + gap);

            water = new Water(0, 250, 700, 30, waterBrush);
            finishLine = new Finish(0, 180, 700, 30, finishBrush);
            frog = new Logs(this.Width / 2 - 15, this.Height - 100, 30, 30, 4, new SolidBrush(Color.DarkGreen));
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

        public void CreateLog(int y)
        {
            SolidBrush logBrush = new SolidBrush(Color.SaddleBrown);
            Logs l = new Logs(700, y, 100, 31, 2, logBrush);
            log.Add(l);
        }

        private void MainScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(water.brushColor, water.x, water.y, water.width, water.height);

            e.Graphics.FillRectangle(finishLine.brushColor, finishLine.x, finishLine.y, finishLine.width, finishLine.height);
            
            foreach (Logs l in log)
            {
                e.Graphics.FillRectangle(l.brushColor, l.x, l.y, l.width, l.height);
            }
            e.Graphics.FillRectangle(frog.brushColor, frog.x, frog.y, frog.width, frog.height);
        }

        private void MainScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;

            }
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            croak.Play();
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            newLogCounter++;

            if (downArrowDown)
            {
                frog.Move("down");  

            }
            else if (upArrowDown)
            {
                frog.Move("up");
            }

            foreach (Logs b in log)
            {
                b.Move();
            }

            if (log[0].y > this.Width)
            {
                log.RemoveAt(0);
            }

            if (newLogCounter == 250)
            {
                if (moveUp == true)
                CreateLog(yUp);
                CreateLog(yUp + gap);

                newLogCounter = 0;

            }
            
            bool ok = true;

            Rectangle frogRec = new Rectangle(frog.x, frog.y, frog.width, frog.height);
            Rectangle waterRec = new Rectangle(water.x, water.y, water.width, water.height);
            Rectangle finishRec = new Rectangle(finishLine.x, finishLine.y, finishLine.width, finishLine.height);
           
            foreach (Logs l in log)
            {
                Rectangle logRec = new Rectangle(l.x, l.y, l.width, l.height);
                
                if (frogRec.IntersectsWith(waterRec) && !frogRec.IntersectsWith(logRec))
                {

                    ok = false;

                }
                else //if (frogRec.IntersectsWith(waterRec))
                {
                    ok = true;
                    break;
                }
            }

            if (ok == false)
            {
                gameLoop.Enabled = false;              
                Form f = this.FindForm();
                f.Controls.Remove(this);
                f.Controls.Add(mm);
            }

            if (frogRec.IntersectsWith(finishRec))
            {
                gameLoop.Enabled = false;
                Form f = this.FindForm();
                f.Controls.Remove(this);
                f.Controls.Add(mm);
            }

            if (frog.y > 400)
            {
                frog.y -= frog.speed;
            }

            Refresh();
        }
    }

}
