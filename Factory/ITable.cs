using System;
using System.Collections.Generic;
using System.Drawing;
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

        public List<List<PictureBox>> displayTable(int width, int height, Form form)
        {

            List<List<PictureBox>> pictureBoxes = new List<List<PictureBox>>();

            for (int i = 0; i < this.NumOfRows; i++)
            {
                pictureBoxes.Add(new List<PictureBox>());
                for (int j = 0; j < this.NumOfColumns; j++)
                {
                    PictureBox pictureBox = new PictureBox
                    {
                        Name = "pictureBox" + i + j,
                        Location = new Point((int)(width * 0.03 + j * this.Width), (int)(height * 0.03 + i * this.Height)),
                        Size = new Size(this.Width, this.Height),
                        BorderStyle = BorderStyle.FixedSingle,
                    };
                    pictureBoxes[i].Add(pictureBox);
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
            int brJ = 0;
            for (int i = 0; i < NumOfRows; i++)
            {
                for (int j = 0; j < NumOfColumns; j++)
                {
                    if (j >= NumOfColumns / 2)
                    {
                        brJ = j - NumOfColumns / 2;
                    }
                    else
                    {
                        brJ = j;
                    }

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
            for (int i = NumOfRows-1; i >=0; i--)
            {
                for (int j = 0; j < NumOfColumns; j++)
                {
                    rand = rng.Next(size);
                    pictureBoxes[i][j].Image = bitmaps[rand];
                    bitmaps.Remove(bitmaps[rand]);
                    size--;
                }
            }

        }
    }
}
