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
        checkDel CheckDel;
        public static DataTable dataTable = new DataTable();
        int row;

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

        void dataGridView1_CellClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string title;
            string brand;
            //           if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == System.Windows.Forms.MouseButtons.Right)
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == System.Windows.Forms.MouseButtons.Right)
            {

                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                //セルを選択できるように

                row = e.RowIndex;
                contextMenuStrip1.Show();
                contextMenuStrip1.Left = MousePosition.X;
                contextMenuStrip1.Top = MousePosition.Y;
            }
            else if(e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == System.Windows.Forms.MouseButtons.Left)
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

            
            //           SQLiteConnection con = new SQLiteConnection("Data Source = test.db");
            using (SQLiteConnection con = new SQLiteConnection("Data Source = test.db"))
            {
                con.Open();
                try
                {
                    SQLiteCommand com1 = new SQLiteCommand("UPDATE games SET latestPlay = "+"'"+now+"'"+"WHERE uid ="+"'"+uid+"'", con);
                    SQLiteDataReader sdr2 = com1.ExecuteReader();
                    sdr2.Close();
                    

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
            string title;
            try
            {
                title = (string)dataTable.Rows[row][1];
                Clipboard.SetText(title);
                this.toolStripStatusLabel1.Text = title+"をコピーしました";
            }
            catch
            {
                this.toolStripStatusLabel1.Text = "コピー失敗 >> タイトルが未記入です";
            }

        }

        private void ブランドToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string brand;
            try
            {
                brand = (string)dataTable.Rows[row][2];
                Clipboard.SetText(brand);
                this.toolStripStatusLabel1.Text = brand+"をコピーしました";
            }
            catch
            {
                this.toolStripStatusLabel1.Text = "コピー失敗 >> ブランドが未記入です";
            }
        }

        private void フォルダーを開くToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string uid = (string)dataTable.Rows[row][0];

            using (SQLiteConnection con = new SQLiteConnection("Data Source = test.db"))
            {
                con.Open();
                try
                {
                    SQLiteCommand com = new SQLiteCommand("SELECT * FROM pathInfo WHERE uid =" + "'" + uid + "'", con);
                    SQLiteDataReader sdr = com.ExecuteReader();
                    while (sdr.Read() == true)
                    {
                        Process.Start("EXPLORER.EXE","/select,"+(string)@sdr["execpath"]);
                        this.toolStripStatusLabel1.Text = "フォルダを開きました";
                    }

                    sdr.Close();
                }
                finally
                {
                    con.Close();
                }
            }

        }

        private void 編集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string uid = (string)dataTable.Rows[row][0];
            DateTime dt = DateTime.Now;
            string now = dt.ToString("yyyy/MM/dd HH:mm:ss");
            dataTable.Rows[row][3] = now;
            dataTable.AcceptChanges();


            //           SQLiteConnection con = new SQLiteConnection("Data Source = test.db");
            using (SQLiteConnection con = new SQLiteConnection("Data Source = test.db"))
            {
                con.Open();
                try
                {
                    SQLiteCommand com1 = new SQLiteCommand("UPDATE games SET latestPlay = " + "'" + now + "'" + "WHERE uid =" + "'" + uid + "'", con);
                    SQLiteDataReader sdr2 = com1.ExecuteReader();
                    sdr2.Close();


                    SQLiteCommand com = new SQLiteCommand("SELECT * FROM pathInfo WHERE uid =" + "'" + uid + "'", con);
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

        private void erogameScapeを開くToolStripMenuItem_Click(object sender, EventArgs e)
        {
            long esid = (Int64)dataTable.Rows[row][6];
            if (esid != -1)
            {
                Process.Start("http://erogamescape.dyndns.org/~ap2/ero/toukei_kaiseki/game.php?game=" + esid);
            }
            else
            {
                this.toolStripStatusLabel1.Text = "erogameScapeIDが登録されていません";
            }
        }

        private void 削除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkDel checkDel = new checkDel();
            checkDel.Show();
        }

        private void 設定ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
