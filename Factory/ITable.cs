using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MG_94_2018.Factory
{
    public abstract class ITable
    {
        public abstract int Width { get; }
        public abstract int Height { get; }
        public abstract int NumOfRows { get; }
        public abstract int NumOfColumns { get; }

        public List<List<PictureBox>> _pictureBoxesRandom = new List<List<PictureBox>>();
        string unopenedCardPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Neotvoreno.bmp");
        List<int> positionOfCard = new List<int>();
        List<List<int>> positionOfCardMatrix = new List<List<int>>();

        public List<List<PictureBox>> displayTable(int width, int height, Form form)
        {

            List<List<PictureBox>> pictureBoxes = new List<List<PictureBox>>();

            for (int i = 0; i < this.NumOfRows; i++)
            {
                pictureBoxes.Add(new List<PictureBox>());
                _pictureBoxesRandom.Add(new List<PictureBox>());
                for (int j = 0; j < this.NumOfColumns; j++)
                {
                    PictureBox pictureBox1 = new PictureBox
                    {
                        Name = "pictureBox" + i + j,
                        Location = new Point((int)(width * 0.03 + j * this.Width), (int)(height * 0.03 + i * this.Height)),
                        Size = new Size(this.Width, this.Height),
                        BorderStyle = BorderStyle.FixedSingle,
                    };
                    PictureBox pictureBox2 = new PictureBox
                    {
                        Name = "pictureBox" + i + j,
                        Location = new Point((int)(width * 0.03 + j * this.Width), (int)(height * 0.03 + i * this.Height)),
                        Size = new Size(this.Width, this.Height),
                        BorderStyle = BorderStyle.FixedSingle,
                    };
                    pictureBoxes[i].Add(pictureBox1);
                    _pictureBoxesRandom[i].Add(pictureBox2);
                    form.Controls.Add(pictureBoxes[i][j]);
                }
            }

            return pictureBoxes;
        }

        public void changeTableImage(List<List<PictureBox>> pictureBoxes, string fileName)
        {
            Bitmap image = new Bitmap(Image.FromFile(fileName), new Size(Width * (NumOfColumns / 2), Height * NumOfRows));
            int cutWidth = image.Width / (NumOfColumns / 2);
            int cutHeight = image.Height / NumOfRows;
            List<Bitmap> bitmaps = new List<Bitmap>();
            for (int i = 0; i < NumOfRows; i++)
            {
                for (int j = 0; j < NumOfColumns; j++)
                {
                    int brJ;
                    if (j >= NumOfColumns / 2)
                    {
                        brJ = j - NumOfColumns / 2;
                    }
                    else
                    {
                        brJ = j;
                    }

                    positionOfCard.Add(i * NumOfColumns/2 + brJ);
                    Bitmap bitmap = new Bitmap(cutWidth, cutHeight);
                    Graphics g = Graphics.FromImage(bitmap);
                    g.DrawImage(
                            image,
                            new Rectangle(0, 0, cutWidth, cutHeight),
                            new Rectangle(brJ * cutWidth, i * cutHeight, cutWidth, cutHeight),
                            GraphicsUnit.Pixel
                        );
                    bitmaps.Add(bitmap);
                    g.Dispose();
                }
            }

            Random rng = new Random();
            int rand, size = NumOfRows*NumOfColumns;
            positionOfCardMatrix = new List<List<int>>();
            for (int i = 0; i < NumOfRows; i++)
            {
                positionOfCardMatrix.Add(new List<int>());
                for (int j = 0; j < NumOfColumns; j++)
                {
                    rand = rng.Next(size);
                    positionOfCardMatrix[i].Add(positionOfCard[rand]);
                    positionOfCard.RemoveAt(rand);
                    _pictureBoxesRandom[i][j].Image = bitmaps[rand];
                    pictureBoxes[i][j].Image = new Bitmap(Image.FromFile(unopenedCardPath), new Size(Width, Height));
                    bitmaps.RemoveAt(rand);
                    size--;
                }
            }

        }

        public bool clickOnCard(PictureBox sender, List<List<PictureBox>> pictureBoxes, int counter, int iBefore, int jBefore)
        {
            bool flag = false;
            int i = int.Parse(sender.Name.Substring(sender.Name.Length - 2, 1));
            int j = int.Parse(sender.Name.Substring(sender.Name.Length - 1));
            if (counter == 0)
            {
                pictureBoxes[i][j].Image = _pictureBoxesRandom[i][j].Image;
                flag = true;
            }
            else if(positionOfCardMatrix[iBefore][jBefore] == positionOfCardMatrix[i][j])
            {
                pictureBoxes[i][j].Image = _pictureBoxesRandom[i][j].Image;
                flag = true;
            }
            else
            {
                pictureBoxes[iBefore][jBefore].Image = new Bitmap(Image.FromFile(unopenedCardPath), new Size(Width, Height));
            }
            return flag;
        }
    }
}
