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

namespace cs_launcher_1
{
    public partial class hensyu : Form
    {
        public hensyu()
        {
            InitializeComponent();
        }

        private void hensyu_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (button4.Text == "☆")
            {
                button4.Text = "★";
                label8.Text = "1";
            }
            else
            {
                button4.Text = "☆";
                button5.Text = "☆";
                button6.Text = "☆";
                button7.Text = "☆";
                button8.Text = "☆";
                label8.Text = "0";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(button5.Text == "☆")
            {
                button4.Text = "★";
                button5.Text = "★";
                label8.Text = "2";
            }
            else
            {
                button4.Text = "☆";
                button5.Text = "☆";
                button6.Text = "☆";
                button7.Text = "☆";
                button8.Text = "☆";
                label8.Text = "0";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "☆")
            {
                button4.Text = "★";
                button5.Text = "★";
                button6.Text = "★";
                label8.Text = "3";
            }
            else
            {
                button4.Text = "☆";
                button5.Text = "☆";
                button6.Text = "☆";
                button7.Text = "☆";
                button8.Text = "☆";
                label8.Text = "0";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text == "☆")
            {
                button4.Text = "★";
                button5.Text = "★";
                button6.Text = "★";
                button7.Text = "★";
                label8.Text = "4";
            }
            else
            {
                button4.Text = "☆";
                button5.Text = "☆";
                button6.Text = "☆";
                button7.Text = "☆";
                button8.Text = "☆";
                label8.Text = "0";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.Text == "☆")
            {
                button4.Text = "★";
                button5.Text = "★";
                button6.Text = "★";
                button7.Text = "★";
                button8.Text = "★";
                label8.Text = "5";
            }
            else
            {
                button4.Text = "☆";
                button5.Text = "☆";
                button6.Text = "☆";
                button7.Text = "☆";
                button8.Text = "☆";
                label8.Text = "0";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.FileName = "";
            try
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(@textBox6.Text);
                Console.WriteLine(openFileDialog.InitialDirectory);
            }
            catch
            {
                try
                {
                    using (StreamReader reader = new StreamReader("path.txt"))
                    {
                        string line;
                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();
                            openFileDialog.InitialDirectory = line;
                        }
                    }
                }
                catch
                {
                    openFileDialog.InitialDirectory = @"";
                }
            }
            openFileDialog.Filter = "EXEファイル(*.exe)|*.exe|すべてのファイル(*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Title = "パスの選択";
//            openFileDialog.RestoreDirectory = true;
//必要になったら
            
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine(openFileDialog.FileName);
                textBox6.Text = openFileDialog.FileName;
                using(StreamWriter writer = new StreamWriter(@"path.txt",false,Encoding.GetEncoding("UTF-8")))
                {
                    writer.WriteLine(Path.GetDirectoryName(textBox6.Text));
                }
            }
        }

    }
}
