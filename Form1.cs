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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if(open.ShowDialog() == DialogResult.OK)
            {
                fileName = open.FileName;
                table.changeTableImage(pictureBoxes, fileName);
            }
        }
    }
}
