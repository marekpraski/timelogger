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
			this.menuStrip1.Size = new System.Drawing.Size(401, 28);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// groupsToolStripMenuItem
			// 
			this.groupsToolStripMenuItem.Name = "groupsToolStripMenuItem";
			this.groupsToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
			this.groupsToolStripMenuItem.Text = "Groups";
			this.groupsToolStripMenuItem.Click += new System.EventHandler(this.groupsToolStripMenuItem_Click);
			// 
			// allTasksToolStripMenuItem
			// 
			this.allTasksToolStripMenuItem.Name = "allTasksToolStripMenuItem";
			this.allTasksToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
			this.allTasksToolStripMenuItem.Text = "Definitions";
			this.allTasksToolStripMenuItem.Click += new System.EventHandler(this.taskDictionaryToolStripMenuItem_Click);
			// 
			// taskStatsToolStripMenuItem
			// 
			this.taskStatsToolStripMenuItem.Name = "taskStatsToolStripMenuItem";
			this.taskStatsToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
			this.taskStatsToolStripMenuItem.Text = "Statistics";
			this.taskStatsToolStripMenuItem.Click += new System.EventHandler(this.taskStatsToolStripMenuItem_Click);
			// 
			// mainPanel
			// 
			this.mainPanel.Location = new System.Drawing.Point(16, 87);
			this.mainPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(365, 133);
			this.mainPanel.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 34);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(140, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "additional work details";
			// 
			// comboWorkDetails
			// 
			this.comboWorkDetails.FormattingEnabled = true;
			this.comboWorkDetails.Location = new System.Drawing.Point(16, 54);
			this.comboWorkDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.comboWorkDetails.Name = "comboWorkDetails";
			this.comboWorkDetails.Size = new System.Drawing.Size(364, 24);
			this.comboWorkDetails.Sorted = true;
			this.comboWorkDetails.TabIndex = 3;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(401, 230);
			this.Controls.Add(this.comboWorkDetails);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.mainPanel);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
	}
}

