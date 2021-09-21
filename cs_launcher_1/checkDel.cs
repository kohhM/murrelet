using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Diagnostics;

namespace cs_launcher_1
{
    public partial class checkDel : Form
    {
        public checkDel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            using(SQLiteConnection con = new SQLiteConnection("Data Source = test.db"))
            {
                con.Open();
                try
                {
                    SQLiteCommand com = new SQLiteCommand("DELETE FROM games WHERE uid = "+"'"+Form1.uid+"'", con);
                    SQLiteDataReader sdr = com.ExecuteReader();
                    sdr.Close();
                }
                finally
                {
                    con.Close();
                }
            }
            */
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
