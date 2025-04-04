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
			Dictionary<string, List<TaskLogItem>> aggregated = new Dictionary<string, List<TaskLogItem>>();
			for (int i = 0; i < items.Count; i++)
			{
				string key = items[i].groupName + items[i].description;
				if (aggregated.ContainsKey(key))
					aggregated[key].Add(items[i]);
				else
				{
					List<TaskLogItem> ts = new List<TaskLogItem>();
					ts.Add(items[i]);
					aggregated.Add(items[i].groupName + items[i].description, ts);
				}
			}
			return splitDictionary(aggregated);
		}

		private List<TaskLogItem> splitDictionary(Dictionary<string, List<TaskLogItem>> aggregated)
		{
			List<TaskLogItem> l = new List<TaskLogItem>();
			foreach (string key in aggregated.Keys)
			{
				List<TaskLogItem> ls = aggregated[key];
				TaskLogItem t = ls[0].clone();
				for (int i = 1; i < ls.Count; i++)
				{
					t.combineTimes(ls[i]);
				}
				l.Add(t);
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
