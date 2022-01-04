using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;

namespace cs_launcher_1
{
    public partial class murrelet : Form
    {
        public static DataTable dataTable = new DataTable();
        checkDel checkDel = new checkDel();
        esidAdd esidAdd = new esidAdd();
        hensyu hensyu = new hensyu();
        chkDD chkDD = new chkDD();
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
                dataGridView1.DataSource = dataTable;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                con.Close();

            }
            string[] width = cheackWidth();
            for (int i = 0; i < width.Length; i++)
            {
                int r = i + 1;
                dataGridView1.Columns[r].Width = int.Parse(width[i]);
            }
        }

        void dataGridView1_CellClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string title;
            string brand;
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right)
            {

                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];

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

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string uid = (string)dataGridView1[0, e.RowIndex].Value;
                DateTime dt = DateTime.Now;
                string now = dt.ToString("yyyy/MM/dd HH:mm:ss");
                dataGridView1[3, e.RowIndex].Value = now;

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

                        Process process = new Process();
                        while (sdr.Read() == true)
                        {
                            //Process.Start((string)@sdr["execpath"]);
                            string pathTar = (string)sdr["execpath"];
                            process.StartInfo.FileName = pathTar;

                            var ic = pathTar.LastIndexOf('\\');

                            process.StartInfo.WorkingDirectory = pathTar.Substring(0, ic);
                            process.Start();

                        }

                        sdr.Close();
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                dataTable = (DataTable)dataGridView1.DataSource;
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
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //エラーでる
            string uid = (string)dataGridView1[0, row].Value;
            dataGridView1.Rows.RemoveAt(row);

            using(SQLiteConnection con = new SQLiteConnection("Data Source = test.db"))
            {
                con.Open();
                try
                {
                    SQLiteCommand com = new SQLiteCommand("DELETE FROM games WHERE uid =" + "'" + uid + "'", con);
                    com.ExecuteNonQuery();

                    SQLiteCommand com2 = new SQLiteCommand("DELETE FROM pathInfo WHERE uid =" + "'" + uid + "'", con);
                    com2.ExecuteNonQuery();
                }
                catch
                {
                    //Console.WriteLine("sqlエラー");
                }
                finally
                {
                    con.Close();
                }
            }

            checkDel.Close();

        }

        private void 設定ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(dataGridView1[5,row].Value.ToString() == "" ||dataGridView1[5,row].Value.ToString() == "0")
            {
                hensyu.button4.Text = "☆";
                hensyu.button5.Text = "☆";
                hensyu.button6.Text = "☆";
                hensyu.button7.Text = "☆";
                hensyu.button8.Text = "☆";
            }else if(dataGridView1[5,row].Value.ToString() == "1")
            {
                hensyu.button4.Text = "★";
                hensyu.button5.Text = "☆";
                hensyu.button6.Text = "☆";
                hensyu.button7.Text = "☆";
                hensyu.button8.Text = "☆";
            }else if(dataGridView1[5,row].Value.ToString() == "2")
            {
                hensyu.button4.Text = "★";
                hensyu.button5.Text = "★";
                hensyu.button6.Text = "☆";
                hensyu.button7.Text = "☆";
                hensyu.button8.Text = "☆";
            }
            else if (dataGridView1[5, row].Value.ToString() == "3")
            {
                hensyu.button4.Text = "★";
                hensyu.button5.Text = "★";
                hensyu.button6.Text = "★";
                hensyu.button7.Text = "☆";
                hensyu.button8.Text = "☆";
            }
            else if (dataGridView1[5, row].Value.ToString() == "4")
            {
                hensyu.button4.Text = "★";
                hensyu.button5.Text = "★";
                hensyu.button6.Text = "★";
                hensyu.button7.Text = "★";
                hensyu.button8.Text = "☆";
            }
            else if (dataGridView1[5, row].Value.ToString() == "5")
            {
                hensyu.button4.Text = "★";
                hensyu.button5.Text = "★";
                hensyu.button6.Text = "★";
                hensyu.button7.Text = "★";
                hensyu.button8.Text = "★";
            }

            hensyu.Visible = true;
            this.hensyu.button2.Click += hensyu_tekio_button;
            hensyu.label7.Text = dataGridView1[0, row].Value.ToString();
            hensyu.textBox1.Text = dataGridView1[1, row].Value.ToString();
            hensyu.textBox2.Text = dataGridView1[2, row].Value.ToString();
            hensyu.textBox3.Text = dataGridView1[4, row].Value.ToString();
            hensyu.textBox4.Text = dataGridView1[6, row].Value.ToString();
            hensyu.label8.Text = dataGridView1[5, row].Value.ToString();

            string uid = (string)dataGridView1[0, row].Value;
            using(SQLiteConnection con = new SQLiteConnection("Data Source = test.db"))
            {
                con.Open();
                try
                {
                    SQLiteCommand com = new SQLiteCommand("SELECT * FROM pathInfo WHERE uid =" + "'" + uid + "'", con);
                    SQLiteDataReader sdr = com.ExecuteReader();
                    while (sdr.Read() == true)
                    {
                        hensyu.textBox6.Text = (string)@sdr["execpath"];
                    }
                    sdr.Close();
                }
                catch(Exception q)
                {
                    //Console.WriteLine(q);
                }
                finally
                {
                    con.Close();
                }
            }
            hensyu.Show();
        }
        private void hensyu_tekio_button(object sender, EventArgs e)
        {
            string saleday = hensyu.textBox3.Text;
            string esid = hensyu.textBox4.Text;

            if (saleday != "")
            {
                try
                {
                    if (saleday.Substring(4, 1) == "-" && saleday.Substring(7, 1) == "-" && saleday.Length == 10)
                    {
                        try
                        {
                            int.Parse(saleday.Substring(0, 4));
                            int.Parse(saleday.Substring(5, 2));
                            int.Parse(saleday.Substring(8, 2));
                        }
                        catch
                        {
                            hensyu.toolStripStatusLabel1.Text = "'発売日はyyyy-mm-dd'のように入力してください";

                            return;
                        }
                    }
                    else
                    {
                        hensyu.toolStripStatusLabel1.Text = "'発売日はyyyy-mm-dd'のように入力してください";
                        return;
                    }
                }
                catch
                {
                    hensyu.toolStripStatusLabel1.Text = "'発売日はyyyy-mm-dd'のように入力してください";
                    return;
                }
            }

            try
            {
                int ckes = int.Parse(esid);
            }
            catch
            {
                esid = "-1";
            }


            using(SQLiteConnection con = new SQLiteConnection("Data Source = test.db"))
            {
                con.Open();
                try
                {
                    SQLiteCommand titleAndBrand_com = new SQLiteCommand("UPDATE games SET title = '"+hensyu.textBox1.Text+"', brand = '"+hensyu.textBox2.Text+"' WHERE uid = '"+hensyu.label7.Text+"'", con);
                    SQLiteDataReader sdr1 = titleAndBrand_com.ExecuteReader();
                    sdr1.Close();
                    //タイトルとブランドの更新

                    SQLiteCommand path_com = new SQLiteCommand("UPDATE pathInfo SET execpath = '"+hensyu.textBox6.Text+"' WHERE uid ='"+hensyu.label7.Text+"'",con);
                    SQLiteDataReader sdr2 = path_com.ExecuteReader();
                    sdr2.Close();
                    //パスの更新

                    SQLiteCommand day_com = new SQLiteCommand("UPDATE games SET saleday = '" + saleday + "' WHERE uid ='" + hensyu.label7.Text + "'", con);
                    SQLiteDataReader sdr3 = day_com.ExecuteReader();
                    sdr3.Close();
                    //発売日の更新

                    SQLiteCommand esid_com = new SQLiteCommand("UPDATE games SET esid = '" + int.Parse(esid) + "' WHERE uid ='" + hensyu.label7.Text + "'", con);
                    SQLiteDataReader sdr4 = esid_com.ExecuteReader();
                    sdr4.Close();
                    //esidの更新

                    SQLiteCommand memo_com = new SQLiteCommand("UPDATE games SET memo = '" + int.Parse(hensyu.label8.Text) + "' WHERE uid ='" + hensyu.label7.Text + "'", con);
                    SQLiteDataReader sdr5 = memo_com.ExecuteReader();
                    sdr5.Close();
                    //空欄はなし　sqlのデフォルトを0に
                }
                catch(Exception x)
                {
                    //Console.WriteLine("エラーでてます");
                }
                finally
                {
                    con.Close();
                    dataGridView1[1, row].Value = hensyu.textBox1.Text;
                    dataGridView1[2, row].Value = hensyu.textBox2.Text;
                    dataGridView1[4, row].Value = saleday;
                    dataGridView1[6, row].Value = esid;
                    dataGridView1[5, row].Value = long.Parse(hensyu.label8.Text);
                }
            }

            hensyu.Close();
        }

        private void murrelet_FormClosing(object sender, FormClosingEventArgs e)
        {
            int[] width = new int[] { dataGridView1.Columns[1].Width, dataGridView1.Columns[2].Width, dataGridView1.Columns[3].Width, dataGridView1.Columns[4].Width, dataGridView1.Columns[5].Width };

            try
            {
                StreamWriter file = new StreamWriter(@"dataGridWidth.csv", false,Encoding.UTF8);
                file.WriteLine(string.Format("{0},{1},{2},{3},{4}", width[0], width[1], width[2], width[3], width[4]));
                file.Close();
            }
            catch(Exception x)
            {
                //Console.WriteLine("えらー！"+ x.Message);
            }
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
                        //Console.WriteLine("エラー>>" + a);
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

        private static string[] cheackWidth()
        {
            string[] values;
            values = new string[5];
            StreamReader sr = new StreamReader(@"dataGridWidth.csv");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                values = line.Split(',');

            }
            sr.Close();
            return (values);
        }

        private void murrelet_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] drags = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string s in drags)
                {
                    if (!File.Exists(s))
                    {
                        return;
                    }
                }
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        string filePath = "";
        string targetPath = "";
        public void murrelet_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (files.Length == 1)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    string ex = Path.GetExtension(files[i]);
 //                   string filePath = "";
 //                   string targetPath = "";

                    if (".lnk" == ex)
                    {
                        filePath = files[i];
                        this.toolStripStatusLabel1.Text = Path.GetFileNameWithoutExtension(filePath);
                        IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
                        IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(filePath);
                        targetPath = shortcut.TargetPath.ToString();

                    }
                    else if (".url" == ex)
                    {
                        filePath = files[i];
                        this.toolStripStatusLabel1.Text = Path.GetFileNameWithoutExtension(filePath);
                        IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
                        IWshRuntimeLibrary.IWshURLShortcut shortcut = (IWshRuntimeLibrary.IWshURLShortcut)shell.CreateShortcut(filePath);
                        targetPath = shortcut.TargetPath.ToString();

                    }
                    else if (".exe" == ex)
                    {
                        filePath = files[i];
                        this.toolStripStatusLabel1.Text = Path.GetFileNameWithoutExtension(filePath);
                        targetPath = filePath;
                    }
                    else
                    {
                        this.toolStripStatusLabel1.Text = "このファイル形式には対応していません";
                        return;
                    }
                    chkDD.Visible = true;
                    this.chkDD.button1.Click += Button1_Click2;
                    this.chkDD.button2.Click += Button2_Click1;
                    chkDD.Show();

                }
            }
            else
            {
                this.toolStripStatusLabel1.Text = "複数ファイル同時には読み込めません";
            }
        }

        private void Button2_Click1(object sender, EventArgs e)
        {
            chkDD.Close();
            //キャンセル
        }

        private void Button1_Click2(object sender, EventArgs e)
        {
            string uid = newGuid();

            using (SQLiteConnection con = new SQLiteConnection("Data Source = test.db"))
            {
                con.Open();
                try
                {
                    SQLiteCommand com = new SQLiteCommand("INSERT INTO games VALUES('" + uid + "','"+ Path.GetFileNameWithoutExtension(filePath) + "','','','','','-1')", con);
                    //sql文変更
                    com.ExecuteNonQuery();

                    SQLiteCommand com2 = new SQLiteCommand("INSERT INTO pathInfo VALUES('" + uid + "','" + 0 + "','"+targetPath+"')", con);
                    com2.ExecuteNonQuery();
                }
                catch
                {
                    Console.WriteLine("sqlエラー");
                }
                finally
                {
                    con.Close();
                    DataRow row = dataTable.NewRow();
                    row["uid"] = uid;
                    row["title"] = Path.GetFileNameWithoutExtension(filePath);
                    row["brand"] = null;
                    row["latestPlay"] = null;
                    row["saleday"] = null;
                    row["memo"] = 0;
                    row["esid"] = "-1";
                    dataTable.Rows.Add(row);
                    dataGridView1.DataSource = dataTable;
                }
            }

            chkDD.Close();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if(dgv.Columns[e.ColumnIndex].Name == "memo")
            {
                switch (e.Value)
                {
                    case (long)1:
                        e.Value = "★ ☆ ☆ ☆ ☆";
                        break;
                    case (long)2:
                        e.Value = "★ ★ ☆ ☆ ☆";
                        break;
                    case (long)3:
                        e.Value = "★ ★ ★ ☆ ☆";
                        break;
                    case (long)4:
                        e.Value = "★ ★ ★ ★ ☆";
                        break;
                    case (long)5:
                        e.Value = "★ ★ ★ ★ ★";
                        break;
                    default:
                        e.Value = "☆ ☆ ☆ ☆ ☆";
                        break;

                }
                e.FormattingApplied = true;
            }
        }

        private void ヘルプToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cd = System.Environment.CurrentDirectory;
            cd = cd + "\\help.html";
            Process.Start(cd);
        }
    }

}
