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
    public partial class murrelet : Form
    {
        private DataTable dataTable = new DataTable();

        public murrelet()
        {
            InitializeComponent();

        }

        private void murrelet_Load(object sender, EventArgs e)
        {
            this.Text = "murrelet";
            using (SQLiteConnection con = new SQLiteConnection("Data Source = test.db"))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM games", con))
            {
                adapter.Fill(dataTable);
                con.Close();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.B == MouseButtons.Left)
            {
                var hoge = dataGridView1[0, e.RowIndex].Value;
                this.toolStripStatusLabel1.Text = (hoge.ToString());
            }
            else
            {
                string title = (string) dataGridView1[1, e.RowIndex].Value;
                string brand = (string)dataGridView1[2, e.RowIndex].Value;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            dataGridView1.DataSource = dataTable;
            base.OnLoad(e);
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string uid = (string)dataGridView1[0,e.RowIndex].Value;
            //           SQLiteConnection con = new SQLiteConnection("Data Source = test.db");
            using (SQLiteConnection con = new SQLiteConnection("Data Source = test.db"))
            {
                con.Open();
                try
                {
                    SQLiteCommand com = new SQLiteCommand("SELECT * FROM pathInfo WHERE uid ="+"'"+uid +"'", con);
                    SQLiteDataReader sdr = com.ExecuteReader();
                    while (sdr.Read() == true)
                    {
                        Process.Start((string)@sdr["execpath"]);
                    }

                    sdr.Close();
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void タイトルToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
