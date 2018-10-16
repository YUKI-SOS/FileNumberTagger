using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace FileNameRenumber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
           
            foreach (string file in files)
            {
                listBox1.Items.Add(file);
            }
           
           
            if (listBox1.SelectedIndex == 0) { return; }
            Point point = listBox1.PointToClient(new Point(e.X, e.Y));
            int index = this.listBox1.IndexFromPoint(point);
            if (index < 0) index = this.listBox1.Items.Count - 1;
            object data = listBox1.SelectedItem;
            this.listBox1.Items.Remove(data);
            this.listBox1.Items.Insert(index, data);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.listBox1.SelectedItem == null) return;
            this.listBox1.DoDragDrop(this.listBox1.SelectedItem, DragDropEffects.Move);
        }

        //up
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            { MessageBox.Show("항목을 선택하세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
         else   {
                int newIndex = listBox1.SelectedIndex - 1;
                if (newIndex < 0)
                {
                    return;
                }
                object selectedItem = listBox1.SelectedItem;
                listBox1.Items.Remove(selectedItem);
                listBox1.Items.Insert(newIndex, selectedItem);
                listBox1.SetSelected(newIndex, true);
            }
        }
        //down
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            { MessageBox.Show("항목을 선택하세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                int newIndex = listBox1.SelectedIndex + 1;
                if (newIndex >= listBox1.Items.Count)
                {
                    return;
                }
                object selectedItem = listBox1.SelectedItem;
                listBox1.Items.Remove(selectedItem);
                listBox1.Items.Insert(newIndex, selectedItem);
                listBox1.SetSelected(newIndex, true);
            }
        }

        //filepath
        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FB = new FolderBrowserDialog();
            if (FB.ShowDialog() == DialogResult.OK)
            {
                textBox1.Clear();
                textBox1.Text = FB.SelectedPath;
            }
        }
        //numcreate
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("파일을 복사할 경로를 설정해주세요.","Error",MessageBoxButtons.OK , MessageBoxIcon.Error);
                return;
            }
            string[] FileArray = new string[1000];
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                FileArray[i] = @listBox1.Items[i].ToString();
                //File.Copy(FileArray[i], Path.GetDirectoryName(FileArray[i]) + "\\" + i + ".jpeg" );
                if(Path.GetExtension(FileArray[i]) == ".jpg")
                {
                 File.Copy(FileArray[i], textBox1.Text + "\\" + i.ToString("D3") + "_" + Path.GetFileName(FileArray[i]) + ".jpg");
                }
                if (Path.GetExtension(FileArray[i]) == ".png")
                {
                    File.Copy(FileArray[i], textBox1.Text + "\\" + i.ToString("D3") + "_" + Path.GetFileName(FileArray[i]) + ".png");
                }
                if (Path.GetExtension(FileArray[i]) == ".mp3")
                {
                    File.Copy(FileArray[i], textBox1.Text + "\\" + i.ToString("D3") + "_" + Path.GetFileName(FileArray[i]) + ".mp3");
                }
                if (Path.GetExtension(FileArray[i]) == ".mp4")
                {
                    File.Copy(FileArray[i], textBox1.Text + "\\" + i.ToString("D3") + "_" + Path.GetFileName(FileArray[i]) + ".mp4");
                }
                if (Path.GetExtension(FileArray[i]) == ".wav")
                {
                    File.Copy(FileArray[i], textBox1.Text + "\\" + i.ToString("D3") + "_" + Path.GetFileName(FileArray[i]) + ".wav");
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/YUKI-SOS/FileNumberTagger");
        }
    }
}
