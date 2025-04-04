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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.groupNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.timeLengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.startTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.endTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.taskLogItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.comboDate = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.radioDailyAggregates = new System.Windows.Forms.RadioButton();
			this.radioNet = new System.Windows.Forms.RadioButton();
			this.radioMonthlyAggregates = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.taskLogItemBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.groupNameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.timeLengthDataGridViewTextBoxColumn,
            this.startTimeDataGridViewTextBoxColumn,
            this.endTimeDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.taskLogItemBindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(12, 43);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.Size = new System.Drawing.Size(781, 275);
			this.dataGridView1.TabIndex = 0;
			// 
			// groupNameDataGridViewTextBoxColumn
			// 
			this.groupNameDataGridViewTextBoxColumn.DataPropertyName = "groupName";
			this.groupNameDataGridViewTextBoxColumn.HeaderText = "groupName";
			this.groupNameDataGridViewTextBoxColumn.Name = "groupNameDataGridViewTextBoxColumn";
			this.groupNameDataGridViewTextBoxColumn.ReadOnly = true;
			this.groupNameDataGridViewTextBoxColumn.Width = 200;
			// 
			// descriptionDataGridViewTextBoxColumn
			// 
			this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
			this.descriptionDataGridViewTextBoxColumn.HeaderText = "description";
			this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
			this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
			this.descriptionDataGridViewTextBoxColumn.Width = 250;
			// 
			// timeLengthDataGridViewTextBoxColumn
			// 
			this.timeLengthDataGridViewTextBoxColumn.DataPropertyName = "timeLength";
			this.timeLengthDataGridViewTextBoxColumn.HeaderText = "timeLength";
			this.timeLengthDataGridViewTextBoxColumn.Name = "timeLengthDataGridViewTextBoxColumn";
			this.timeLengthDataGridViewTextBoxColumn.ReadOnly = true;
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
			// taskLogItemBindingSource
			// 
			this.taskLogItemBindingSource.DataSource = typeof(TimeLogger.TaskLogItem);
			// 
			// comboDate
			// 
			this.comboDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboDate.FormattingEnabled = true;
			this.comboDate.Location = new System.Drawing.Point(47, 16);
			this.comboDate.Name = "comboDate";
			this.comboDate.Size = new System.Drawing.Size(138, 21);
			this.comboDate.Sorted = true;
			this.comboDate.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(28, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "date";
			// 
			// radioDailyAggregates
			// 
			this.radioDailyAggregates.AutoSize = true;
			this.radioDailyAggregates.Checked = true;
			this.radioDailyAggregates.Location = new System.Drawing.Point(226, 19);
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
			this.radioNet.Location = new System.Drawing.Point(466, 19);
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
			this.radioMonthlyAggregates.Location = new System.Drawing.Point(343, 20);
			this.radioMonthlyAggregates.Name = "radioMonthlyAggregates";
			this.radioMonthlyAggregates.Size = new System.Drawing.Size(117, 17);
			this.radioMonthlyAggregates.TabIndex = 5;
			this.radioMonthlyAggregates.TabStop = true;
			this.radioMonthlyAggregates.Text = "monthly aggregates";
			this.radioMonthlyAggregates.UseVisualStyleBackColor = true;
			this.radioMonthlyAggregates.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
			// 
			// TaskStatisticsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(805, 332);
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
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.ComboBox comboDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.BindingSource taskLogItemBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn groupNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn timeLengthDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn startTimeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn endTimeDataGridViewTextBoxColumn;
		private System.Windows.Forms.RadioButton radioDailyAggregates;
		private System.Windows.Forms.RadioButton radioNet;
		private System.Windows.Forms.RadioButton radioMonthlyAggregates;
	}
}