using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;


namespace CG1
{
    public partial class Form1 : Form
    {
        Bitmap src_image = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                src_image = new Bitmap(openFileDialog1.FileName);   

                pictureBox1.Image = new Bitmap(src_image);
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            float C = 1.0f; 
            float B = (float)trackBar1.Value / 100; 

            float[][] matrix = {
                new float[] {1, 0, 0, 0, 0}, //R
                new float[] {0, 1, 0, 0, 0}, //G
                new float[] {0, 0, 1, 0, 0}, //B
                new float[] {0, 0, 0, 1, 0}, //A
                new float[] {B, B, B, 0, 1} //W
            };

            ImageAttributes attr = new ImageAttributes();
            attr.SetColorMatrix(new ColorMatrix(matrix));

            if (pictureBox1.Image != null)
            {
                using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                {
                    Rectangle rect = new Rectangle(0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height);
                    g.DrawImage(src_image, rect, 0, 0, src_image.Width, src_image.Height, GraphicsUnit.Pixel, attr);
                }
                pictureBox1.Refresh();
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            float C = 0.04f*trackBar2.Value; 
            

            float[][] matrix = {
                new float[] {C, 0, 0, 0, 0}, //R
                new float[] {0, C, 0, 0, 0}, //G
                new float[] {0, 0, C, 0, 0}, //B
                new float[] {0, 0, 0, 1, 0}, //A
                new float[] {0.001f, 0.001f, 0.001f, 0, 1} //W
            };

            ImageAttributes attr = new ImageAttributes();
            attr.SetColorMatrix(new ColorMatrix(matrix));

            if (pictureBox1.Image != null)
            {
                using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                {
                    Rectangle rect = new Rectangle(0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height);
                    g.DrawImage(src_image, rect, 0, 0, src_image.Width, src_image.Height, GraphicsUnit.Pixel, attr);
                }
                pictureBox1.Refresh();
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            float S = 0.05f * trackBar3.Value;
            float[][] matrix = {
                new float[] {S, 0, 0, 0, 0}, //R
                new float[] {0, S, 0, 0, 0}, //G
                new float[] {0, 0, S, 0, 0}, //B
                new float[] {0, 0, 0, 1, 0}, //A
                new float[] {0, 0, 0, 0, 1} //W
            };

            ImageAttributes attr = new ImageAttributes();
            attr.SetColorMatrix(new ColorMatrix(matrix));

            if (pictureBox1.Image != null)
            {
                using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                {
                    Rectangle rect = new Rectangle(0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height);
                    g.DrawImage(src_image, rect, 0, 0, src_image.Width, src_image.Height, GraphicsUnit.Pixel, attr);
                }
                pictureBox1.Refresh();
            }





        }
    }
}
