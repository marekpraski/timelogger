namespace TimeLogger
{
	partial class GroupsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dgv = new System.Windows.Forms.DataGridView();
			this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgv
			// 
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupName});
			this.dgv.Location = new System.Drawing.Point(12, 27);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(264, 248);
			this.dgv.TabIndex = 0;
			// 
			// GroupName
			// 
			this.GroupName.HeaderText = "Task Group Name";
			this.GroupName.Name = "GroupName";
			this.GroupName.Width = 200;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(294, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// GroupsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(294, 294);
			this.Controls.Add(this.dgv);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "GroupsForm";
			this.Text = "Task Groups";
			this.Load += new System.EventHandler(this.TaskDictionaryForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
	}
}