namespace TimeLogger
{
	partial class TaskDefinitionsForm
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
			this.components = new System.ComponentModel.Container();
			this.comboGroups = new System.Windows.Forms.ComboBox();
			this.tbNewTask = new System.Windows.Forms.TextBox();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.groupNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.isActiveDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.taskDictionaryItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.usunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dodajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.taskDictionaryItemBindingSource)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboGroups
			// 
			this.comboGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboGroups.FormattingEnabled = true;
			this.comboGroups.Location = new System.Drawing.Point(12, 27);
			this.comboGroups.Name = "comboGroups";
			this.comboGroups.Size = new System.Drawing.Size(213, 21);
			this.comboGroups.Sorted = true;
			this.comboGroups.TabIndex = 0;
			// 
			// tbNewTask
			// 
			this.tbNewTask.Location = new System.Drawing.Point(231, 27);
			this.tbNewTask.Name = "tbNewTask";
			this.tbNewTask.Size = new System.Drawing.Size(382, 20);
			this.tbNewTask.TabIndex = 1;
			// 
			// dgv
			// 
			this.dgv.AllowUserToAddRows = false;
			this.dgv.AllowUserToDeleteRows = false;
			this.dgv.AutoGenerateColumns = false;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.groupNameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.isActiveDataGridViewCheckBoxColumn});
			this.dgv.DataSource = this.taskDictionaryItemBindingSource;
			this.dgv.Location = new System.Drawing.Point(12, 55);
			this.dgv.Name = "dgv";
			this.dgv.RowHeadersVisible = false;
			this.dgv.Size = new System.Drawing.Size(622, 258);
			this.dgv.TabIndex = 2;
			this.dgv.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseUp);
			this.dgv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellValueChanged);
			// 
			// groupNameDataGridViewTextBoxColumn
			// 
			this.groupNameDataGridViewTextBoxColumn.DataPropertyName = "groupName";
			this.groupNameDataGridViewTextBoxColumn.HeaderText = "groupName";
			this.groupNameDataGridViewTextBoxColumn.Name = "groupNameDataGridViewTextBoxColumn";
			this.groupNameDataGridViewTextBoxColumn.Width = 200;
			// 
			// descriptionDataGridViewTextBoxColumn
			// 
			this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
			this.descriptionDataGridViewTextBoxColumn.HeaderText = "description";
			this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
			this.descriptionDataGridViewTextBoxColumn.Width = 300;
			// 
			// isActiveDataGridViewCheckBoxColumn
			// 
			this.isActiveDataGridViewCheckBoxColumn.DataPropertyName = "isActive";
			this.isActiveDataGridViewCheckBoxColumn.HeaderText = "isActive";
			this.isActiveDataGridViewCheckBoxColumn.Name = "isActiveDataGridViewCheckBoxColumn";
			// 
			// taskDictionaryItemBindingSource
			// 
			this.taskDictionaryItemBindingSource.DataSource = typeof(TimeLogger.TaskDefinitionItem);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usunToolStripMenuItem,
            this.dodajToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(645, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// usunToolStripMenuItem
			// 
			this.usunToolStripMenuItem.Name = "usunToolStripMenuItem";
			this.usunToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.usunToolStripMenuItem.Text = "Delete";
			this.usunToolStripMenuItem.Click += new System.EventHandler(this.usunToolStripMenuItem_Click);
			// 
			// dodajToolStripMenuItem
			// 
			this.dodajToolStripMenuItem.Name = "dodajToolStripMenuItem";
			this.dodajToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.dodajToolStripMenuItem.Text = "Add";
			this.dodajToolStripMenuItem.Click += new System.EventHandler(this.dodajToolStripMenuItem_Click);
			// 
			// TaskDictionaryForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(645, 327);
			this.Controls.Add(this.dgv);
			this.Controls.Add(this.tbNewTask);
			this.Controls.Add(this.comboGroups);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "TaskDictionaryForm";
			this.Text = "Task Dictionary";
			this.Load += new System.EventHandler(this.TaskDictionaryForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.taskDictionaryItemBindingSource)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboGroups;
		private System.Windows.Forms.TextBox tbNewTask;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.BindingSource taskDictionaryItemBindingSource;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem dodajToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem usunToolStripMenuItem;
		private System.Windows.Forms.DataGridViewTextBoxColumn groupNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewCheckBoxColumn isActiveDataGridViewCheckBoxColumn;
	}
}