using MG_94_2018.Factory;
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

namespace MG_94_2018
{
    public partial class Form1 : Form
    {
        ITable table = null;
        List<List<PictureBox>> pictureBoxes = new List<List<PictureBox>>();
        string fileName = null;
        string newGameFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "newgame.bmp");
        int counter = 0;
        int moveCounter = 0;
        int iBefore = -1, jBefore = -1;
        bool disableClickPrevious = false;
        DateTime time;
        Timer timer = new Timer();

        public Form1()
        {
            InitializeComponent();
            button2.Image = new Bitmap(newGameFilePath);
            
        }

        void place_picture_boxes()
        {
            foreach(List<PictureBox> pictureBoxList in pictureBoxes)
            {
                foreach(PictureBox pictureBox in pictureBoxList)
                {
                    Controls.Remove(pictureBox);
                }
            }

            pictureBoxes = table.displayTable(ClientSize.Width, ClientSize.Height, this);


            foreach (List<PictureBox> pictureBoxList in pictureBoxes)
            {
                foreach (PictureBox pictureBox in pictureBoxList)
                {
                    pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
                    this.Controls.Add(pictureBox);
                }
            }
            counter = 0;
            iBefore = -1;
            jBefore = -1;
            disableClickPrevious = false;
            moveCounter = 0;
            brojacPoteza.Text = "Broj poteza: " + moveCounter;
            if (fileName != null)
            {
                timer.Stop();
                var startTime = DateTime.Now;
                timer.Tick += (s, ev) => { vremeOdPocetka.Text = "Broj sekundi od pocetka igre: " + string.Format("{0:00}", (DateTime.Now - startTime).Seconds); };
                timer.Interval = 100;
                timer.Start();
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBoxSender = (PictureBox)sender;
            int i = int.Parse(pictureBoxSender.Name.Substring(pictureBoxSender.Name.Length - 2, 1));
            int j = int.Parse(pictureBoxSender.Name.Substring(pictureBoxSender.Name.Length - 1));
            bool disableClick = table.clickOnCard(pictureBoxSender, pictureBoxes, counter, iBefore, jBefore);
            if(counter == 0)
            {
                counter++;
            }
            else
            {
                moveCounter++;
                brojacPoteza.Text = "Broj poteza: " + moveCounter;
                counter = 0;
            }
            if (disableClick == true)
            {
                pictureBoxes[i][j].Click -= new System.EventHandler(this.pictureBox_Click);
            }
            else if (disableClickPrevious == true)
            {
                pictureBoxes[iBefore][jBefore].Click += new System.EventHandler(this.pictureBox_Click);
            }
            iBefore = i;
            jBefore = j;
            disableClickPrevious = disableClick;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                table = Factory.Factory.GetTable(SizeType.size_3x3x2);
                place_picture_boxes();
                if(fileName != null)
                {
                    table.changeTableImage(pictureBoxes, fileName);
                }
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked)
            {
                table = Factory.Factory.GetTable(SizeType.size_3x4x2);
                place_picture_boxes();
                if (fileName != null)
                {
                    table.changeTableImage(pictureBoxes, fileName);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            place_picture_boxes();
            if (fileName != null)
            {
                table.changeTableImage(pictureBoxes, fileName);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if(open.ShowDialog() == DialogResult.OK)
            {
                fileName = open.FileName;
                nazivSlike.Text = Path.GetFileName(fileName);
                place_picture_boxes();
                table.changeTableImage(pictureBoxes, fileName);
            }
        }

    }
}
