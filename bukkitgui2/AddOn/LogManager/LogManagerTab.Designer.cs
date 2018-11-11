namespace Net.Bertware.Bukkitgui2.AddOn.LogManager
{
    partial class LogManagerTab
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SlvLogs = new Net.Bertware.Bukkitgui2.Controls.SortableListView.SortableListView();
            this.ColName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BtnRefresh = new MetroFramework.Controls.MetroButton();
            this.BtnOpenDir = new MetroFramework.Controls.MetroButton();
            this.BtnDelete = new MetroFramework.Controls.MetroButton();
            this.GbPreview = new System.Windows.Forms.GroupBox();
            this.RtbPreview = new System.Windows.Forms.RichTextBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.GbPreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer1.Panel1.Controls.Add(this.SlvLogs);
            this.splitContainer1.Panel1.Controls.Add(this.BtnDelete);
            this.splitContainer1.Panel1.Controls.Add(this.BtnRefresh);
            this.splitContainer1.Panel1.Controls.Add(this.BtnOpenDir);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.GbPreview);
            this.splitContainer1.Size = new System.Drawing.Size(794, 494);
            this.splitContainer1.SplitterDistance = 262;
            this.splitContainer1.TabIndex = 0;
            // 
            // SlvLogs
            // 
            this.SlvLogs.Anchor = System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Left
                | System.Windows.Forms.AnchorStyles.Bottom
                | System.Windows.Forms.AnchorStyles.Right;
            this.SlvLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColName,
            this.ColDate,
            this.ColSize});
            this.SlvLogs.Dock = System.Windows.Forms.DockStyle.None;
            this.SlvLogs.Location = new System.Drawing.Point(0, 0);
            this.SlvLogs.Name = "SlvLogs";
            this.SlvLogs.Size = new System.Drawing.Size(794, 231);
            this.SlvLogs.TabIndex = 0;
            this.SlvLogs.UseCompatibleStateImageBehavior = false;
            this.SlvLogs.View = System.Windows.Forms.View.Details;
            // 
            // ColName
            // 
            this.ColName.Text = "Name";
            this.ColName.Width = 300;
            // 
            // ColDate
            // 
            this.ColDate.Text = "Date";
            this.ColDate.Width = 180;
            //
            // ColSize
            //
            this.ColSize.Text = "Size";
            this.ColSize.Width = 90;
            //
            // BtnRefresh
            //
            this.BtnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Right
                | System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnRefresh.Location = new System.Drawing.Point(715, 235);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(75, 23);
            this.BtnRefresh.TabIndex = 2;
            this.BtnRefresh.Text = "Refresh";
            this.BtnRefresh.UseSelectable = true;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            //
            // BtnOpenDir
            //
            this.BtnOpenDir.Anchor = System.Windows.Forms.AnchorStyles.Right
                | System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnOpenDir.Location = new System.Drawing.Point(560, 235);
            this.BtnOpenDir.Name = "BtnOpenDir";
            this.BtnOpenDir.Size = new System.Drawing.Size(150, 23);
            this.BtnOpenDir.TabIndex = 1;
            this.BtnOpenDir.Text = "Open Logs Directory";
            this.BtnOpenDir.UseSelectable = true;
            this.BtnOpenDir.Click += new System.EventHandler(this.BtnOpenDir_Click);
            //
            // BtnDelete
            //
            this.BtnDelete.Anchor = System.Windows.Forms.AnchorStyles.Left
                | System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnDelete.Location = new System.Drawing.Point(5, 235);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(75, 23);
            this.BtnDelete.TabIndex = 2;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseSelectable = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // GbPreview
            // 
            this.GbPreview.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.GbPreview.Controls.Add(this.RtbPreview);
            this.GbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbPreview.Location = new System.Drawing.Point(0, 0);
            this.GbPreview.Name = "GbPreview";
            this.GbPreview.Size = new System.Drawing.Size(794, 228);
            this.GbPreview.TabIndex = 0;
            this.GbPreview.TabStop = false;
            this.GbPreview.Text = "Preview";
            // 
            // RtbPreview
            // 
            this.RtbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RtbPreview.Location = new System.Drawing.Point(3, 18);
            this.RtbPreview.Name = "RtbPreview";
            this.RtbPreview.Size = new System.Drawing.Size(788, 207);
            this.RtbPreview.TabIndex = 0;
            this.RtbPreview.Text = "";
            // 
            // LogManagerTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "LogManagerTab";
            this.Size = new System.Drawing.Size(800, 500);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.GbPreview.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controls.SortableListView.SortableListView SlvLogs;
        private System.Windows.Forms.ColumnHeader ColName;
        private System.Windows.Forms.ColumnHeader ColDate;
        private System.Windows.Forms.ColumnHeader ColSize;
        private MetroFramework.Controls.MetroButton BtnRefresh;
        private MetroFramework.Controls.MetroButton BtnOpenDir;
        private MetroFramework.Controls.MetroButton BtnDelete;
        private System.Windows.Forms.GroupBox GbPreview;
        private System.Windows.Forms.RichTextBox RtbPreview;
    }
}
