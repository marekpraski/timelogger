namespace TimeLogger
{
	partial class TaskStatisticsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskStatisticsForm));
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.groupNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.startTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.endTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.taskDurationInHoursMinutesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.workDetailsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.taskLogItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.comboDate = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.radioDailyAggregates = new System.Windows.Forms.RadioButton();
			this.radioNet = new System.Windows.Forms.RadioButton();
			this.radioMonthlyAggregates = new System.Windows.Forms.RadioButton();
			this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
			this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
			this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
			this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonDelete = new System.Windows.Forms.ToolStripButton();
			this.buttonSave = new System.Windows.Forms.ToolStripButton();
			this.btnToCsv = new System.Windows.Forms.ToolStripButton();
			this.comboGroup = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.taskLogItemBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
			this.bindingNavigator1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.groupNameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.startTimeDataGridViewTextBoxColumn,
            this.endTimeDataGridViewTextBoxColumn,
            this.taskDurationInHoursMinutesDataGridViewTextBoxColumn,
            this.workDetailsDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.taskLogItemBindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(9, 56);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.Size = new System.Drawing.Size(920, 420);
			this.dataGridView1.TabIndex = 0;
			// 
			// groupNameDataGridViewTextBoxColumn
			// 
			this.groupNameDataGridViewTextBoxColumn.DataPropertyName = "groupName";
			this.groupNameDataGridViewTextBoxColumn.HeaderText = "groupName";
			this.groupNameDataGridViewTextBoxColumn.Name = "groupNameDataGridViewTextBoxColumn";
			this.groupNameDataGridViewTextBoxColumn.ReadOnly = true;
			this.groupNameDataGridViewTextBoxColumn.Width = 150;
			// 
			// descriptionDataGridViewTextBoxColumn
			// 
			this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
			this.descriptionDataGridViewTextBoxColumn.HeaderText = "description";
			this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
			this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
			this.descriptionDataGridViewTextBoxColumn.Width = 200;
			// 
			// startTimeDataGridViewTextBoxColumn
			// 
			this.startTimeDataGridViewTextBoxColumn.DataPropertyName = "startTime";
			this.startTimeDataGridViewTextBoxColumn.HeaderText = "startTime";
			this.startTimeDataGridViewTextBoxColumn.Name = "startTimeDataGridViewTextBoxColumn";
			this.startTimeDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// endTimeDataGridViewTextBoxColumn
			// 
			this.endTimeDataGridViewTextBoxColumn.DataPropertyName = "endTime";
			this.endTimeDataGridViewTextBoxColumn.HeaderText = "endTime";
			this.endTimeDataGridViewTextBoxColumn.Name = "endTimeDataGridViewTextBoxColumn";
			this.endTimeDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// taskDurationInHoursMinutesDataGridViewTextBoxColumn
			// 
			this.taskDurationInHoursMinutesDataGridViewTextBoxColumn.DataPropertyName = "taskDurationInHoursMinutes";
			this.taskDurationInHoursMinutesDataGridViewTextBoxColumn.HeaderText = "duration";
			this.taskDurationInHoursMinutesDataGridViewTextBoxColumn.Name = "taskDurationInHoursMinutesDataGridViewTextBoxColumn";
			this.taskDurationInHoursMinutesDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// workDetailsDataGridViewTextBoxColumn
			// 
			this.workDetailsDataGridViewTextBoxColumn.DataPropertyName = "workDetails";
			this.workDetailsDataGridViewTextBoxColumn.HeaderText = "workDetails";
			this.workDetailsDataGridViewTextBoxColumn.Name = "workDetailsDataGridViewTextBoxColumn";
			this.workDetailsDataGridViewTextBoxColumn.ReadOnly = true;
			this.workDetailsDataGridViewTextBoxColumn.Width = 250;
			// 
			// taskLogItemBindingSource
			// 
			this.taskLogItemBindingSource.DataSource = typeof(TimeLogger.TaskLogItem);
			// 
			// comboDate
			// 
			this.comboDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboDate.FormattingEnabled = true;
			this.comboDate.Location = new System.Drawing.Point(290, 29);
			this.comboDate.Name = "comboDate";
			this.comboDate.Size = new System.Drawing.Size(138, 21);
			this.comboDate.TabIndex = 1;
			this.comboDate.SelectedIndexChanged += new System.EventHandler(this.comboDate_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(256, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(28, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "date";
			// 
			// radioDailyAggregates
			// 
			this.radioDailyAggregates.AutoSize = true;
			this.radioDailyAggregates.Checked = true;
			this.radioDailyAggregates.Location = new System.Drawing.Point(496, 31);
			this.radioDailyAggregates.Name = "radioDailyAggregates";
			this.radioDailyAggregates.Size = new System.Drawing.Size(102, 17);
			this.radioDailyAggregates.TabIndex = 3;
			this.radioDailyAggregates.TabStop = true;
			this.radioDailyAggregates.Text = "daily aggregates";
			this.radioDailyAggregates.UseVisualStyleBackColor = true;
			this.radioDailyAggregates.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
			// 
			// radioNet
			// 
			this.radioNet.AutoSize = true;
			this.radioNet.Location = new System.Drawing.Point(736, 31);
			this.radioNet.Name = "radioNet";
			this.radioNet.Size = new System.Drawing.Size(40, 17);
			this.radioNet.TabIndex = 4;
			this.radioNet.Text = "net";
			this.radioNet.UseVisualStyleBackColor = true;
			this.radioNet.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
			// 
			// radioMonthlyAggregates
			// 
			this.radioMonthlyAggregates.AutoSize = true;
			this.radioMonthlyAggregates.Location = new System.Drawing.Point(604, 31);
			this.radioMonthlyAggregates.Name = "radioMonthlyAggregates";
			this.radioMonthlyAggregates.Size = new System.Drawing.Size(117, 17);
			this.radioMonthlyAggregates.TabIndex = 5;
			this.radioMonthlyAggregates.TabStop = true;
			this.radioMonthlyAggregates.Text = "monthly aggregates";
			this.radioMonthlyAggregates.UseVisualStyleBackColor = true;
			this.radioMonthlyAggregates.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
			// 
			// bindingNavigator1
			// 
			this.bindingNavigator1.AddNewItem = null;
			this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
			this.bindingNavigator1.DeleteItem = null;
			this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.buttonDelete,
            this.buttonSave,
            this.btnToCsv});
			this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
			this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
			this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
			this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
			this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
			this.bindingNavigator1.Name = "bindingNavigator1";
			this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
			this.bindingNavigator1.Size = new System.Drawing.Size(941, 27);
			this.bindingNavigator1.TabIndex = 6;
			this.bindingNavigator1.Text = "bindingNavigator1";
			// 
			// bindingNavigatorCountItem
			// 
			this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
			this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 24);
			this.bindingNavigatorCountItem.Text = "of {0}";
			this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
			// 
			// bindingNavigatorMoveFirstItem
			// 
			this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
			this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
			this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(24, 24);
			this.bindingNavigatorMoveFirstItem.Text = "Move first";
			// 
			// bindingNavigatorMovePreviousItem
			// 
			this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
			this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
			this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(24, 24);
			this.bindingNavigatorMovePreviousItem.Text = "Move previous";
			// 
			// bindingNavigatorSeparator
			// 
			this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
			this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
			// 
			// bindingNavigatorPositionItem
			// 
			this.bindingNavigatorPositionItem.AccessibleName = "Position";
			this.bindingNavigatorPositionItem.AutoSize = false;
			this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
			this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(38, 23);
			this.bindingNavigatorPositionItem.Text = "0";
			this.bindingNavigatorPositionItem.ToolTipText = "Current position";
			// 
			// bindingNavigatorSeparator1
			// 
			this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
			this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
			// 
			// bindingNavigatorMoveNextItem
			// 
			this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
			this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
			this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(24, 24);
			this.bindingNavigatorMoveNextItem.Text = "Move next";
			// 
			// bindingNavigatorMoveLastItem
			// 
			this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
			this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
			this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(24, 24);
			this.bindingNavigatorMoveLastItem.Text = "Move last";
			// 
			// bindingNavigatorSeparator2
			// 
			this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
			this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
			// 
			// buttonDelete
			// 
			this.buttonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonDelete.Image = ((System.Drawing.Image)(resources.GetObject("buttonDelete.Image")));
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.RightToLeftAutoMirrorImage = true;
			this.buttonDelete.Size = new System.Drawing.Size(24, 24);
			this.buttonDelete.Text = "Delete";
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonSave.Image = global::TimeLogger.Properties.Resources.Save_16x;
			this.buttonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(24, 24);
			this.buttonSave.Text = "Save changes";
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// btnToCsv
			// 
			this.btnToCsv.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnToCsv.Image = global::TimeLogger.Properties.Resources.ResultToCSV_16x;
			this.btnToCsv.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnToCsv.Name = "btnToCsv";
			this.btnToCsv.Size = new System.Drawing.Size(24, 24);
			this.btnToCsv.Text = "Export to csv";
			this.btnToCsv.Click += new System.EventHandler(this.btnToCsv_Click);
			// 
			// comboGroup
			// 
			this.comboGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboGroup.FormattingEnabled = true;
			this.comboGroup.Location = new System.Drawing.Point(53, 29);
			this.comboGroup.Name = "comboGroup";
			this.comboGroup.Size = new System.Drawing.Size(197, 21);
			this.comboGroup.TabIndex = 7;
			this.comboGroup.SelectedIndexChanged += new System.EventHandler(this.comboGroup_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "group";
			// 
			// TaskStatisticsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(941, 483);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.comboGroup);
			this.Controls.Add(this.bindingNavigator1);
			this.Controls.Add(this.radioMonthlyAggregates);
			this.Controls.Add(this.radioNet);
			this.Controls.Add(this.radioDailyAggregates);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboDate);
			this.Controls.Add(this.dataGridView1);
			this.Name = "TaskStatisticsForm";
			this.Text = "Task Statistics";
			this.Load += new System.EventHandler(this.TaskStatisticsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.taskLogItemBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
			this.bindingNavigator1.ResumeLayout(false);
			this.bindingNavigator1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.ComboBox comboDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton radioDailyAggregates;
		private System.Windows.Forms.RadioButton radioNet;
		private System.Windows.Forms.RadioButton radioMonthlyAggregates;
		private System.Windows.Forms.BindingNavigator bindingNavigator1;
		private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
		private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
		private System.Windows.Forms.ToolStripButton buttonDelete;
		private System.Windows.Forms.ToolStripButton buttonSave;
		private System.Windows.Forms.ToolStripButton btnToCsv;
		private System.Windows.Forms.ComboBox comboGroup;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.BindingSource taskLogItemBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn groupNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn startTimeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn endTimeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn taskDurationInHoursMinutesDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn workDetailsDataGridViewTextBoxColumn;
	}
}