using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace cs_launcher_1
{
    public partial class getPro : Form
    {
        public static DataTable dataTable = new DataTable();
        public getPro()
        {
            InitializeComponent();
        }

        private void getPro_Load(object sender, EventArgs e)
        {
            dataTable.Columns.Add("pid", typeof(int));
            dataTable.Columns.Add("プロセス名", typeof(string));
            dataTable.Columns.Add("タイトル名", typeof(string));
            dataTable.Columns.Add("パス", typeof(string));
            DataRow row;

            //System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcesses();
            var processes = Process.GetProcesses();

            //foreach(System.Diagnostics.Process p in ps)
            foreach(var process in processes)
            {
                try
                {
                    row = dataTable.NewRow();
                    row["pid"] = process.Id;

                    row["プロセス名"] = process.ProcessName;
                    //                    row["タイトル名"] = p.MainModule.ModuleName;
                    row["タイトル名"] = process.MainWindowTitle;
                    //                   row["パス"] = p.MainModule.FileName;
                    row["パス"] = process.MainModule.FileName;
                    dataTable.Rows.Add(row);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void getPro_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void 再読み込みToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
