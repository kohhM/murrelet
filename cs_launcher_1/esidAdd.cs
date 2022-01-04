using System.Windows.Forms;

namespace cs_launcher_1
{
    public partial class esidAdd : Form
    {
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
