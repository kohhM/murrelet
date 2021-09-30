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
using System.Text.Json;

namespace cs_launcher_1
{
    public partial class murrelet : Form
    {
        public static DataTable dataTable = new DataTable();
        checkDel checkDel = new checkDel();
        getPro getPro = new getPro();
        esidAdd esidAdd = new esidAdd();
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
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[6].Visible = false;
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
            dataGridView1.DataSource = dataTable;

            
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
                title = (string)dataGridView1[1,row].Value;
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
                brand = (string)dataGridView1[2,row].Value;
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
            string uid = (string)dataGridView1[0,row].Value;

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

        }

        private void erogameScapeを開くToolStripMenuItem_Click(object sender, EventArgs e)
        {
            long esid = (Int64)dataGridView1[6,row].Value;
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
            checkDel.Visible = true;
            this.checkDel.button2.Click += Button2_Click;
            this.checkDel.button1.Click += Button1_Click1;
            this.checkDel.label1.Text = (string)dataGridView1[1,row].Value+"\nを本当に削除しますか？";
            checkDel.Show();
        }

        private void Button1_Click1(object sender, EventArgs e)
        {
            checkDel.Close();
            //キャンセル
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string uid = (string)dataGridView1[0, row].Value;
            dataGridView1.Rows.RemoveAt(row);

            using(SQLiteConnection con = new SQLiteConnection("Data Source = test.db"))
            {
                con.Open();
                try
                {
                    SQLiteCommand com = new SQLiteCommand("DELETE FROM games WHERE uid =" + "'" + uid + "'", con);
                    com.ExecuteNonQuery();
                }
                catch
                {
                    Console.WriteLine("sqlエラー");
                }
                finally
                {
                    con.Close();
                }
            }

            checkDel.Close();
            //削除確定
        }

        private void 設定ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void murrelet_FormClosing(object sender, FormClosingEventArgs e)
        {
            //https://shikaku-sh.hatenablog.com/entry/wpf-restore-datagrid-column-index-and-width#%E5%8F%82%E8%80%83
        }

        private void プロセスから追加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getPro.Show();
            getPro.Visible = true;
        }

        private void erogameScapeから追加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            esidAdd.Visible = true;
            this.esidAdd.button1.Click += Button1_Click;
            this.esidAdd.textBox1.Text = "";
            esidAdd.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DataRow row;
            string esidS = esidAdd.textBox1.Text;
            int esid = -1;
            string[] add = new string[3];
            long idEE = -1;
            try
            {
                esid = Int32.Parse(esidS);
//                this.toolStripStatusLabel1.Text = esidS;

                using(SQLiteConnection con = new SQLiteConnection("Data Source = data.db"))
                {
                    con.Open();
                    try
                    {
                        SQLiteCommand com1 = new SQLiteCommand("SELECT * FROM erogamescape WHERE id =" + "'"+esid+"'", con);
                        SQLiteDataReader sdr = com1.ExecuteReader();
                        while (sdr.Read() == true)
                        {
                            idEE = (long)sdr["id"];
                            add[0] = (string)sdr["title"];
                            add[1] = (string)sdr["saleday"];
                            add[2] = (string)sdr["brand"];

                            this.toolStripStatusLabel1.Text = "成功:《"+add[0] + "》を追加しました";
                        }
                        sdr.Close();
                    }
                    catch(Exception a)
                    {
                        this.toolStripStatusLabel1.Text = "本アプリのデータが古い、または存在しないidです";
                        //sqlにesidがなくてもエラーを吐かない。そこは修正必要だけどめんどいから後で。
                        //別にそこを確認する必要ない？
                        Console.WriteLine("エラー>>" + a);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            catch
            {
                this.toolStripStatusLabel1.Text = "失敗しました:半角で数値を入力してください";
            }

            row = dataTable.NewRow();
            row["uid"] = newGuid();
            row["title"] = add[0];
            row["brand"] = add[2];
            row["saleday"] = add[1];
            dataTable.Rows.Add(row);
            this.toolStripStatusLabel1.Text = (string)row["uid"];
            dataGridView1.DataSource = dataTable;


            using(SQLiteConnection con = new SQLiteConnection("Data Source = test.db"))
            {
                con.Open();
                try
                {
                    SQLiteCommand com2 = new SQLiteCommand("INSERT INTO games('uid','title','brand','saleday','esid')VALUES('"+row["uid"]+"','"+row["title"]+"','"+row["brand"]+"','"+row["saleday"]+"','"+idEE+"')",con);
                    com2.ExecuteNonQuery();

                }
                catch(Exception a)
                {
                    this.toolStripStatusLabel1.Text = "失敗しました:SQLite書き込みエラー";
                    Console.WriteLine("エラー>>" + a);
                }
                finally
                {
                    con.Close();
                }
            }



            esidAdd.Close();
        }

        private static string newGuid()
        {
            string Nguid;
            Guid guidValue = Guid.NewGuid();
            Nguid = guidValue.ToString("N").ToUpper();
            return (Nguid);
        }

        private void ゲーム起動ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string uid = (string)dataGridView1[0,row].Value;
            DateTime dt = DateTime.Now;
            string now = dt.ToString("yyyy/MM/dd HH:mm:ss");
            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                if((string)dataTable.Rows[row][0] == uid)
                {
                    dataTable.Rows[row][3] = now;
                }
            }
            dataTable.AcceptChanges();
            dataGridView1.DataSource = dataTable;


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
    }
}
