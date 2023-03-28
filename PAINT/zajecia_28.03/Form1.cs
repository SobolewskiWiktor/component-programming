using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zajecia_28._03
{
    public partial class Form1 : Form
    {
        Point start;
        Point a;
        Point b;
        Color color = Color.Black;
        Color fill = Color.Transparent; 
        float size = 1;
        int click; 
        Graphics g;
        Brush myBrush;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image); 
            g.Clear(Color.White);
            numericUpDown1.Value = (decimal)size; 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(radioButton7.Checked)
            {
                if(click == 1)
                {
                    g.DrawLine(new Pen(color, size), start, e.Location);
                    pictureBox1.Refresh();
                    start = e.Location;
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                a = e.Location;
                start = e.Location;
                click = 1; 
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                click = 0; 
                if (radioButton1.Checked)
                {
                    b = e.Location;
                    g.DrawLine(new Pen(color, size), a, b);
                    pictureBox1.Refresh();
                }
                if(radioButton4.Checked)
                {
                    b = e.Location;
                    if (radioButton8.Checked)
                    {
                        g.FillRectangle(myBrush, Math.Min(a.X, b.X), Math.Min(a.Y, b.Y), Math.Abs(a.X - b.X), Math.Abs(a.Y - b.Y)); 
                    }
                    g.DrawRectangle(new Pen(color, size), Math.Min(a.X, b.X), Math.Min(a.Y, b.Y), Math.Abs(a.X - b.X),Math.Abs(a.Y - b.Y));
                    pictureBox1.Refresh();
                }
                if(radioButton6.Checked)
                {
                    b = e.Location;
                    if (radioButton8.Checked)
                    {
                        g.FillEllipse(myBrush, Math.Min(a.X, b.X), Math.Min(a.Y, b.Y), Math.Abs(a.X - b.X), Math.Abs(a.Y - b.Y));
                    }
    
                    g.DrawEllipse(new Pen(color, size), Math.Min(a.X, b.X), Math.Min(a.Y, b.Y), Math.Abs(a.X - b.X), Math.Abs(a.Y - b.Y));
                    pictureBox1.Refresh();
                }
       

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Bitmapa | *.bmp";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(sfd.FileName); 
            }
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Bitmapa | *.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
                g = Graphics.FromImage(pictureBox1.Image);
            }
        }

        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Refresh();
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cl = new ColorDialog();
            if(cl.ShowDialog() == DialogResult.OK)
            {
                color = cl.Color;
                button1.BackColor = color;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_MouseUp(object sender, MouseEventArgs e)
        {
            size = (float)numericUpDown1.Value; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog cl = new ColorDialog();
            if (cl.ShowDialog() == DialogResult.OK)
            {
                fill = cl.Color;
                button2.BackColor = fill;
                myBrush = new SolidBrush(fill);  
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cofnijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = 
        }
    }
}
