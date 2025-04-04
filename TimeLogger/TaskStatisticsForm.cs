using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TimeLogger
{
    public partial class TaskStatisticsForm: Form
    {
		private readonly Dictionary<string, List<TaskLogItem>> tasks;

		public TaskStatisticsForm(Dictionary<string, List<TaskLogItem>> tasks)
        {
            InitializeComponent();
			this.tasks = tasks;
			fillCombo();
		}

		private void fillCombo()
		{
			comboDate.Items.Clear();
			if (tasks == null || tasks.Keys.Count == 0)
				return;
			if (radioMonthlyAggregates.Checked)
				fillComboMonths();
			else
				fillComboDays();
		}

		private void fillComboMonths()
		{
			fillComboDays();
		}

		private void fillComboDays()
		{
			foreach (string k in tasks.Keys)
			{
				comboDate.Items.Add(k);
			}
			comboDate.SelectedIndex = 0;
		}

		private void TaskStatisticsForm_Load(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(comboDate.Text))
				return;
			loadDgv();
		}

		private void loadDgv()
		{
			if (radioDailyAggregates.Checked)
				taskLogItemBindingSource.DataSource = getDailyAggregatedTasks(comboDate.Text);
			else if (radioMonthlyAggregates.Checked)
				taskLogItemBindingSource.DataSource = getMonthlyAggregatedTasks(comboDate.Text);
			else
				taskLogItemBindingSource.DataSource = this.tasks[comboDate.Text];
		}

		private void radio_CheckedChanged(object sender, EventArgs e)
		{
			fillCombo();
			loadDgv();
		}

		#region aggregowanie danych
		private List<TaskLogItem> getDailyAggregatedTasks(string date)
		{
			List<TaskLogItem> items = tasks[date];
			Dictionary<string, TaskLogItem> aggregated = new Dictionary<string, TaskLogItem>();
			for (int i = 0; i < items.Count; i++)
			{
				string key = items[i].groupName + items[i].description;
				if (aggregated.ContainsKey(key))
					aggregated[key].combineTimes(items[i]);
				else
				{
					TaskLogItem item = items[i].clone();
					aggregated.Add(item.groupName + item.description, item);
				}
			}

			List<TaskLogItem> l = new List<TaskLogItem>();
			foreach (string key in aggregated.Keys)
			{
				l.Add(aggregated[key]);
			}
			return l;
		}

		private List<TaskLogItem> getMonthlyAggregatedTasks(string date)
		{
			return getDailyAggregatedTasks(date);
		} 
		#endregion
	}
}
