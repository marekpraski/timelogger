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
			this.dgv = new System.Windows.Forms.DataGridView();
			this.comboDate = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
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
			this.btnToCsvAllDates = new System.Windows.Forms.ToolStripButton();
			this.btnToCsv = new System.Windows.Forms.ToolStripButton();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.comboAggregationType = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripLabelTimeLogged = new System.Windows.Forms.ToolStripLabel();
			this.comboGroup = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.comboYearMonth = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.comboTask = new System.Windows.Forms.ComboBox();
			this.taskLogItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.groupNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.startTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.endTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.taskDurationInHoursMinutesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.workDetailsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
			this.bindingNavigator1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.taskLogItemBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// dgv
			// 
			this.dgv.AllowUserToAddRows = false;
			this.dgv.AllowUserToDeleteRows = false;
			this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgv.AutoGenerateColumns = false;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.groupNameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.startTimeDataGridViewTextBoxColumn,
            this.endTimeDataGridViewTextBoxColumn,
            this.taskDurationInHoursMinutesDataGridViewTextBoxColumn,
            this.workDetailsDataGridViewTextBoxColumn});
			this.dgv.DataSource = this.taskLogItemBindingSource;
			this.dgv.Location = new System.Drawing.Point(9, 56);
			this.dgv.Name = "dgv";
			this.dgv.ReadOnly = true;
			this.dgv.RowHeadersVisible = false;
			this.dgv.RowHeadersWidth = 51;
			this.dgv.Size = new System.Drawing.Size(918, 420);
			this.dgv.TabIndex = 0;
			this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
			// 
			// comboDate
			// 
			this.comboDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboDate.FormattingEnabled = true;
			this.comboDate.Location = new System.Drawing.Point(46, 32);
			this.comboDate.Name = "comboDate";
			this.comboDate.Size = new System.Drawing.Size(91, 21);
			this.comboDate.TabIndex = 1;
			this.comboDate.SelectedIndexChanged += new System.EventHandler(this.comboDate_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(28, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "date";
			// 
			// bindingNavigator1
			// 
			this.bindingNavigator1.AddNewItem = null;
			this.bindingNavigator1.BindingSource = this.taskLogItemBindingSource;
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
            this.btnToCsvAllDates,
            this.btnToCsv,
            this.toolStripLabel1,
            this.comboAggregationType,
            this.toolStripLabel2,
            this.toolStripLabelTimeLogged});
			this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
			this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
			this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
			this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
			this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
			this.bindingNavigator1.Name = "bindingNavigator1";
			this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
			this.bindingNavigator1.Size = new System.Drawing.Size(939, 27);
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
			// btnToCsvAllDates
			// 
			this.btnToCsvAllDates.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnToCsvAllDates.Image = global::TimeLogger.Properties.Resources.ResultToCSVAggregate_16x;
			this.btnToCsvAllDates.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnToCsvAllDates.Name = "btnToCsvAllDates";
			this.btnToCsvAllDates.Size = new System.Drawing.Size(24, 24);
			this.btnToCsvAllDates.Text = "Export to csv all dates";
			this.btnToCsvAllDates.Click += new System.EventHandler(this.btnToCsvAllDates_Click);
			// 
			// btnToCsv
			// 
			this.btnToCsv.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnToCsv.Image = global::TimeLogger.Properties.Resources.ResultToCSV_16x;
			this.btnToCsv.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnToCsv.Name = "btnToCsv";
			this.btnToCsv.Size = new System.Drawing.Size(24, 24);
			this.btnToCsv.Text = "Export to csv selected date";
			this.btnToCsv.Click += new System.EventHandler(this.btnToCsv_Click);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(19, 24);
			this.toolStripLabel1.Text = "    ";
			// 
			// comboAggregationType
			// 
			this.comboAggregationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboAggregationType.Name = "comboAggregationType";
			this.comboAggregationType.Size = new System.Drawing.Size(140, 27);
			this.comboAggregationType.SelectedIndexChanged += new System.EventHandler(this.comboAggregationType_SelectedIndexChanged);
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(19, 24);
			this.toolStripLabel2.Text = "    ";
			// 
			// toolStripLabelTimeLogged
			// 
			this.toolStripLabelTimeLogged.Name = "toolStripLabelTimeLogged";
			this.toolStripLabelTimeLogged.Size = new System.Drawing.Size(71, 24);
			this.toolStripLabelTimeLogged.Text = "time logged";
			// 
			// comboGroup
			// 
			this.comboGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboGroup.FormattingEnabled = true;
			this.comboGroup.Location = new System.Drawing.Point(268, 31);
			this.comboGroup.Name = "comboGroup";
			this.comboGroup.Size = new System.Drawing.Size(188, 21);
			this.comboGroup.TabIndex = 7;
			this.comboGroup.SelectedIndexChanged += new System.EventHandler(this.comboGroup_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(230, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "group";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(778, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "year-month";
			// 
			// comboYearMonth
			// 
			this.comboYearMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboYearMonth.FormattingEnabled = true;
			this.comboYearMonth.Location = new System.Drawing.Point(840, 31);
			this.comboYearMonth.Name = "comboYearMonth";
			this.comboYearMonth.Size = new System.Drawing.Size(76, 21);
			this.comboYearMonth.TabIndex = 9;
			this.comboYearMonth.SelectedIndexChanged += new System.EventHandler(this.comboYearMonth_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(182, 36);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Filter by:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(461, 36);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(27, 13);
			this.label5.TabIndex = 13;
			this.label5.Text = "task";
			// 
			// comboTask
			// 
			this.comboTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboTask.FormattingEnabled = true;
			this.comboTask.Location = new System.Drawing.Point(491, 31);
			this.comboTask.Name = "comboTask";
			this.comboTask.Size = new System.Drawing.Size(264, 21);
			this.comboTask.TabIndex = 12;
			this.comboTask.SelectedIndexChanged += new System.EventHandler(this.comboTask_SelectedIndexChanged);
			// 
			// taskLogItemBindingSource
			// 
			this.taskLogItemBindingSource.DataSource = typeof(TimeLogger.TaskLogItem);
			// 
			// groupNameDataGridViewTextBoxColumn
			// 
			this.groupNameDataGridViewTextBoxColumn.DataPropertyName = "groupName";
			this.groupNameDataGridViewTextBoxColumn.HeaderText = "groupName";
			this.groupNameDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.groupNameDataGridViewTextBoxColumn.Name = "groupNameDataGridViewTextBoxColumn";
			this.groupNameDataGridViewTextBoxColumn.ReadOnly = true;
			this.groupNameDataGridViewTextBoxColumn.Width = 150;
			// 
			// descriptionDataGridViewTextBoxColumn
			// 
			this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
			this.descriptionDataGridViewTextBoxColumn.HeaderText = "description";
			this.descriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
			this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
			this.descriptionDataGridViewTextBoxColumn.Width = 200;
			// 
			// startTimeDataGridViewTextBoxColumn
			// 
			this.startTimeDataGridViewTextBoxColumn.DataPropertyName = "startTime";
			this.startTimeDataGridViewTextBoxColumn.HeaderText = "startTime";
			this.startTimeDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.startTimeDataGridViewTextBoxColumn.Name = "startTimeDataGridViewTextBoxColumn";
			this.startTimeDataGridViewTextBoxColumn.ReadOnly = true;
			this.startTimeDataGridViewTextBoxColumn.Width = 125;
			// 
			// endTimeDataGridViewTextBoxColumn
			// 
			this.endTimeDataGridViewTextBoxColumn.DataPropertyName = "endTime";
			this.endTimeDataGridViewTextBoxColumn.HeaderText = "endTime";
			this.endTimeDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.endTimeDataGridViewTextBoxColumn.Name = "endTimeDataGridViewTextBoxColumn";
			this.endTimeDataGridViewTextBoxColumn.ReadOnly = true;
			this.endTimeDataGridViewTextBoxColumn.Width = 125;
			// 
			// taskDurationInHoursMinutesDataGridViewTextBoxColumn
			// 
			this.taskDurationInHoursMinutesDataGridViewTextBoxColumn.DataPropertyName = "taskDurationInHoursMinutes";
			this.taskDurationInHoursMinutesDataGridViewTextBoxColumn.HeaderText = "duration";
			this.taskDurationInHoursMinutesDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.taskDurationInHoursMinutesDataGridViewTextBoxColumn.Name = "taskDurationInHoursMinutesDataGridViewTextBoxColumn";
			this.taskDurationInHoursMinutesDataGridViewTextBoxColumn.ReadOnly = true;
			this.taskDurationInHoursMinutesDataGridViewTextBoxColumn.Width = 125;
			// 
			// workDetailsDataGridViewTextBoxColumn
			// 
			this.workDetailsDataGridViewTextBoxColumn.DataPropertyName = "workDetails";
			this.workDetailsDataGridViewTextBoxColumn.HeaderText = "workDetails (double click to edit)";
			this.workDetailsDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.workDetailsDataGridViewTextBoxColumn.Name = "workDetailsDataGridViewTextBoxColumn";
			this.workDetailsDataGridViewTextBoxColumn.ReadOnly = true;
			this.workDetailsDataGridViewTextBoxColumn.Width = 250;
			// 
			// TaskStatisticsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(939, 483);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.comboTask);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.comboYearMonth);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.comboGroup);
			this.Controls.Add(this.bindingNavigator1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboDate);
			this.Controls.Add(this.dgv);
			this.Name = "TaskStatisticsForm";
			this.Text = "Task Statistics";
			this.Load += new System.EventHandler(this.TaskStatisticsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
			this.bindingNavigator1.ResumeLayout(false);
			this.bindingNavigator1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.taskLogItemBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.ComboBox comboDate;
		private System.Windows.Forms.Label label1;
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
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboYearMonth;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGridViewTextBoxColumn groupNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn startTimeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn endTimeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn taskDurationInHoursMinutesDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn workDetailsDataGridViewTextBoxColumn;
		private System.Windows.Forms.ToolStripButton btnToCsvAllDates;
		private System.Windows.Forms.ToolStripLabel toolStripLabelTimeLogged;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox comboTask;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripComboBox comboAggregationType;
		private System.Windows.Forms.ToolStripLabel toolStripLabel2;
	}
}