
namespace cs_launcher_1
{
    partial class murrelet
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.編集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.フォルダーを開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erogameScapeを開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.設定ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.コピーToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.タイトルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ブランドToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.f1 = new System.Windows.Forms.ToolStripMenuItem();
            this.プロセスから追加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erogameScapeから追加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ツールToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.バージョン確認ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 27);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(802, 401);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.編集ToolStripMenuItem,
            this.開くToolStripMenuItem,
            this.設定ToolStripMenuItem1,
            this.コピーToolStripMenuItem,
            this.削除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(126, 114);
            // 
            // 編集ToolStripMenuItem
            // 
            this.編集ToolStripMenuItem.Name = "編集ToolStripMenuItem";
            this.編集ToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.編集ToolStripMenuItem.Text = "ゲーム起動";
            this.編集ToolStripMenuItem.Click += new System.EventHandler(this.編集ToolStripMenuItem_Click);
            // 
            // 開くToolStripMenuItem
            // 
            this.開くToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.フォルダーを開くToolStripMenuItem,
            this.erogameScapeを開くToolStripMenuItem});
            this.開くToolStripMenuItem.Name = "開くToolStripMenuItem";
            this.開くToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.開くToolStripMenuItem.Text = "開く";
            // 
            // フォルダーを開くToolStripMenuItem
            // 
            this.フォルダーを開くToolStripMenuItem.Name = "フォルダーを開くToolStripMenuItem";
            this.フォルダーを開くToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.フォルダーを開くToolStripMenuItem.Text = "フォルダーを開く";
            this.フォルダーを開くToolStripMenuItem.Click += new System.EventHandler(this.フォルダーを開くToolStripMenuItem_Click);
            // 
            // erogameScapeを開くToolStripMenuItem
            // 
            this.erogameScapeを開くToolStripMenuItem.Name = "erogameScapeを開くToolStripMenuItem";
            this.erogameScapeを開くToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.erogameScapeを開くToolStripMenuItem.Text = "ErogameScapeを開く";
            this.erogameScapeを開くToolStripMenuItem.Click += new System.EventHandler(this.erogameScapeを開くToolStripMenuItem_Click);
            // 
            // 設定ToolStripMenuItem1
            // 
            this.設定ToolStripMenuItem1.Name = "設定ToolStripMenuItem1";
            this.設定ToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.設定ToolStripMenuItem1.Text = "編集";
            this.設定ToolStripMenuItem1.Click += new System.EventHandler(this.設定ToolStripMenuItem1_Click);
            // 
            // コピーToolStripMenuItem
            // 
            this.コピーToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.タイトルToolStripMenuItem,
            this.ブランドToolStripMenuItem});
            this.コピーToolStripMenuItem.Name = "コピーToolStripMenuItem";
            this.コピーToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.コピーToolStripMenuItem.Text = "コピー";
            // 
            // タイトルToolStripMenuItem
            // 
            this.タイトルToolStripMenuItem.Name = "タイトルToolStripMenuItem";
            this.タイトルToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.タイトルToolStripMenuItem.Text = "タイトル";
            this.タイトルToolStripMenuItem.Click += new System.EventHandler(this.タイトルToolStripMenuItem_Click);
            // 
            // ブランドToolStripMenuItem
            // 
            this.ブランドToolStripMenuItem.Name = "ブランドToolStripMenuItem";
            this.ブランドToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.ブランドToolStripMenuItem.Text = "ブランド";
            this.ブランドToolStripMenuItem.Click += new System.EventHandler(this.ブランドToolStripMenuItem_Click);
            // 
            // 削除ToolStripMenuItem
            // 
            this.削除ToolStripMenuItem.Name = "削除ToolStripMenuItem";
            this.削除ToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.削除ToolStripMenuItem.Text = "削除";
            this.削除ToolStripMenuItem.Click += new System.EventHandler(this.削除ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.f1,
            this.ツールToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(802, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // f1
            // 
            this.f1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.プロセスから追加ToolStripMenuItem,
            this.erogameScapeから追加ToolStripMenuItem,
            this.終了ToolStripMenuItem});
            this.f1.Name = "f1";
            this.f1.Size = new System.Drawing.Size(53, 20);
            this.f1.Text = "ファイル";
            // 
            // プロセスから追加ToolStripMenuItem
            // 
            this.プロセスから追加ToolStripMenuItem.Name = "プロセスから追加ToolStripMenuItem";
            this.プロセスから追加ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.プロセスから追加ToolStripMenuItem.Text = "プロセスから追加";
            // 
            // erogameScapeから追加ToolStripMenuItem
            // 
            this.erogameScapeから追加ToolStripMenuItem.Name = "erogameScapeから追加ToolStripMenuItem";
            this.erogameScapeから追加ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.erogameScapeから追加ToolStripMenuItem.Text = "ErogameScapeから追加";
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.終了ToolStripMenuItem.Text = "終了";
            this.終了ToolStripMenuItem.Click += new System.EventHandler(this.終了ToolStripMenuItem_Click);
            // 
            // ツールToolStripMenuItem
            // 
            this.ツールToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.設定ToolStripMenuItem,
            this.バージョン確認ToolStripMenuItem});
            this.ツールToolStripMenuItem.Name = "ツールToolStripMenuItem";
            this.ツールToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.ツールToolStripMenuItem.Text = "ツール";
            // 
            // 設定ToolStripMenuItem
            // 
            this.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
            this.設定ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.設定ToolStripMenuItem.Text = "設定";
            // 
            // バージョン確認ToolStripMenuItem
            // 
            this.バージョン確認ToolStripMenuItem.Name = "バージョン確認ToolStripMenuItem";
            this.バージョン確認ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.バージョン確認ToolStripMenuItem.Text = "バージョン情報";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 431);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(802, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(51, 17);
            this.toolStripStatusLabel1.Text = "murrelet";
            // 
            // murrelet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 453);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "murrelet";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.murrelet_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.murrelet_FormClosed);
            this.Load += new System.EventHandler(this.murrelet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem f1;
        private System.Windows.Forms.ToolStripMenuItem プロセスから追加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erogameScapeから追加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ツールToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem バージョン確認ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 編集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開くToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem フォルダーを開くToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erogameScapeを開くToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem コピーToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem タイトルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ブランドToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 削除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 設定ToolStripMenuItem1;
    }
}

