using System;
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
    public partial class esidAdd : Form
    {
//        Form1 Form1 = new Form1();
        public string esid;
        public esidAdd()
        {
            InitializeComponent();
        }


        private void esidAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }
    }
}
