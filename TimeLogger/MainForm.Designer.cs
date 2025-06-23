namespace TimeLogger
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.groupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.allTasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.taskStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mainPanel = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.comboWorkDetails = new System.Windows.Forms.ComboBox();
			this.btnDeleteWorkDetails = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.groupsToolStripMenuItem,
            this.allTasksToolStripMenuItem,
            this.taskStatsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
			this.menuStrip1.Size = new System.Drawing.Size(285, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// groupsToolStripMenuItem
			// 
			this.groupsToolStripMenuItem.Name = "groupsToolStripMenuItem";
			this.groupsToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
			this.groupsToolStripMenuItem.Text = "Groups";
			this.groupsToolStripMenuItem.Click += new System.EventHandler(this.groupsToolStripMenuItem_Click);
			// 
			// allTasksToolStripMenuItem
			// 
			this.allTasksToolStripMenuItem.Name = "allTasksToolStripMenuItem";
			this.allTasksToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
			this.allTasksToolStripMenuItem.Text = "Definitions";
			this.allTasksToolStripMenuItem.Click += new System.EventHandler(this.taskDictionaryToolStripMenuItem_Click);
			// 
			// taskStatsToolStripMenuItem
			// 
			this.taskStatsToolStripMenuItem.Name = "taskStatsToolStripMenuItem";
			this.taskStatsToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
			this.taskStatsToolStripMenuItem.Text = "Statistics";
			this.taskStatsToolStripMenuItem.Click += new System.EventHandler(this.taskStatsToolStripMenuItem_Click);
			// 
			// mainPanel
			// 
			this.mainPanel.Location = new System.Drawing.Point(12, 71);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(260, 108);
			this.mainPanel.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(111, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "additional work details";
			// 
			// comboWorkDetails
			// 
			this.comboWorkDetails.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.comboWorkDetails.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.comboWorkDetails.FormattingEnabled = true;
			this.comboWorkDetails.Location = new System.Drawing.Point(12, 44);
			this.comboWorkDetails.Name = "comboWorkDetails";
			this.comboWorkDetails.Size = new System.Drawing.Size(231, 21);
			this.comboWorkDetails.Sorted = true;
			this.comboWorkDetails.TabIndex = 3;
			// 
			// btnDeleteWorkDetails
			// 
			this.btnDeleteWorkDetails.Image = global::TimeLogger.Properties.Resources.delete;
			this.btnDeleteWorkDetails.Location = new System.Drawing.Point(249, 43);
			this.btnDeleteWorkDetails.Name = "btnDeleteWorkDetails";
			this.btnDeleteWorkDetails.Size = new System.Drawing.Size(23, 23);
			this.btnDeleteWorkDetails.TabIndex = 4;
			this.btnDeleteWorkDetails.UseVisualStyleBackColor = true;
			this.btnDeleteWorkDetails.Click += new System.EventHandler(this.btnDeleteWorkDetails_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(285, 187);
			this.Controls.Add(this.btnDeleteWorkDetails);
			this.Controls.Add(this.comboWorkDetails);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.mainPanel);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Time Logger";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem allTasksToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem taskStatsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem groupsToolStripMenuItem;
		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboWorkDetails;
		private System.Windows.Forms.Button btnDeleteWorkDetails;
	}
}

