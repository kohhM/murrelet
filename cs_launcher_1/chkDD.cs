using System;
using System.Windows.Forms;

namespace cs_launcher_1
{
    public partial class chkDD : Form
    {
        public chkDD()
        {
            InitializeComponent();
        }

        private void chkDD_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
