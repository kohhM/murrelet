﻿using System;
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

            Dictionary<int, string> title = new Dictionary<int, string>();

            System.Management.ManagementClass mc = new System.Management.ManagementClass("Win32_Process");
            System.Management.ManagementObjectCollection moc = mc.GetInstances();

            foreach(System.Management.ManagementObject mo in moc)
            {
                
                try
                {
                    row = dataTable.NewRow();
                    row["pid"] = mo["ProcessId"];
                    row["プロセス名"] = mo["Name"];
                    row["パス"] = mo["ExecutablePath"];
                    dataTable.Rows.Add(row);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    mo.Dispose();
                }
            }
            moc.Dispose();
            mc.Dispose();
            dataGridView1.DataSource = dataTable;


            var processes = Process.GetProcesses();

            foreach(var process in processes)
            {
                if (process.MainWindowTitle != "")
                {
                    try
                    {
                        title.Add(process.Id, process.MainWindowTitle);
                        Console.WriteLine(process.Id + "," + process.MainWindowTitle);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            //辞書作成

            foreach(KeyValuePair<int,string> x in title)
            {
                for(int i= 0; i < dataGridView1.Rows.Count; i++)
                {
                    Console.WriteLine(dataGridView1[0, i].Value);
                    if(int.Parse(dataGridView1[0,i].Value.ToString()) == x.Key)
                    {
                        dataGridView1[2, i].Value = x.Value;
                    }
                }
            }

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
            dataTable.Clear();
            DataRow row;

            System.Management.ManagementClass mc = new System.Management.ManagementClass("Win32_Process");
            System.Management.ManagementObjectCollection moc = mc.GetInstances();

            foreach (System.Management.ManagementObject mo in moc)
            {
                try
                {
                    row = dataTable.NewRow();
                    row["pid"] = mo["ProcessId"];
                    row["プロセス名"] = mo["Name"];
                    row["タイトル名"] = mo["status"];
                    row["パス"] = mo["ExecutablePath"];
                    dataTable.Rows.Add(row);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("エラーやよー" + ex.Message);
                }
                finally
                {
                    mo.Dispose();
                }
            }
            moc.Dispose();
            mc.Dispose();
            dataGridView1.DataSource = dataTable;
            Console.WriteLine("更新完了");
            //あとでけす

        }

    }
}
