using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragDropDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            listBox1.AllowDrop = true;
            pictureBox1.AllowDrop = true;
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Text = "Mouse down";
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.DoDragDrop(textBox1.Text, DragDropEffects.Copy);
            }
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            Text = "Drag enter";
            if (e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void listBox1_DragLeave(object sender, EventArgs e)
        {
            Text = "Drag leave";
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                var text = e.Data.GetData(DataFormats.Text);
                listBox1.Items.Add(text);
            }

            Text = "Done";
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var data = e.Data.GetData(DataFormats.FileDrop);
                var path = ((string[])data)[0];

                pictureBox1.Image = Image.FromFile(path);
            }
        }
    }
}
