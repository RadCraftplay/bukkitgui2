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
            this.splitContainer1.Panel1.Controls.Add(this.SlvLogs);
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
            this.SlvLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColName,
            this.ColDate,
            this.ColSize});
            this.SlvLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SlvLogs.Location = new System.Drawing.Point(0, 0);
            this.SlvLogs.Name = "SlvLogs";
            this.SlvLogs.Size = new System.Drawing.Size(794, 262);
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
        private System.Windows.Forms.GroupBox GbPreview;
        private System.Windows.Forms.RichTextBox RtbPreview;
    }
}
