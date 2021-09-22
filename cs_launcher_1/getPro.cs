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

            System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcesses();

            foreach(System.Diagnostics.Process p in ps)
            {
                try
                {
                    row = dataTable.NewRow();
                    row["pid"] = p.Id;
                    row["プロセス名"] = p.ProcessName;
                    row["タイトル名"] = p.MainModule.ModuleName;
                    row["パス"] = p.MainModule.FileName;
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
    }
}
