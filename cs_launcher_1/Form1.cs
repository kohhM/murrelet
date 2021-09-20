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
        int row = -1;

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

        void dataGridView1_CellClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string title;
            string brand;
            //           if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == System.Windows.Forms.MouseButtons.Right)
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                row = e.RowIndex;
                //テスト
                Console.WriteLine(row);
            }
            else if((e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == System.Windows.Forms.MouseButtons.Left))
            {
                try
                {
                    title = (string)dataGridView1[1, e.RowIndex].Value;
                }
                catch
                {
                    title = "";
                }
                try
                {
                    brand = (string)dataGridView1[2, e.RowIndex].Value;
                }
                catch
                {
                    brand = "";
                }
                finally
                {
                    this.toolStripStatusLabel1.Text = title;
                }
            }
            else
            {
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
            DateTime dt = DateTime.Now;
            string now = dt.ToString("yyyy/MM/dd HH:mm:ss");
            dataTable.Rows[e.RowIndex][3] = now;
            dataTable.AcceptChanges();
            //sqliteに反映させないといけない
            
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

        private void タイトルToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = (string)dataTable.Rows[row][1];
            Clipboard.SetText(title);
        }
    }
}
