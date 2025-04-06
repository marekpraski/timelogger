using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TimeLogger
{
    public partial class TaskStatisticsForm: Form
    {
		private readonly Dictionary<string, List<TaskLogItem>> detailedLogsGroupedByDay;    //kluczem jest pełna data rrrr-mm-dd
		private Dictionary<string, List<TaskLogItem>> detailedLogsGroupedByMonth;
		private List<string> yearMonths;

		public TaskStatisticsForm(Dictionary<string, List<TaskLogItem>> dailyTaskLogs)
        {
            InitializeComponent();
			this.detailedLogsGroupedByDay = dailyTaskLogs;
			this.yearMonths = extractYearMonths();
			detailedLogsGroupedByMonth = groupTaskLogsByMonth();
		}

		#region metody na starcie
		private void TaskStatisticsForm_Load(object sender, EventArgs e)
		{
			fillCombo();
			if (String.IsNullOrEmpty(comboDate.Text))
				return;
		}

		private List<string> extractYearMonths()
		{
			this.yearMonths = new List<string>();
			HashSet<string> hs = new HashSet<string>();
			foreach (string key in detailedLogsGroupedByDay.Keys)
			{
				List<TaskLogItem> l = detailedLogsGroupedByDay[key];
				for (int i = 0; i < l.Count; i++)
				{
					hs.Add(l[i].yearMonth);
				}
			}

			List<string> ls = new List<string>(hs.Count);
			foreach (string s in hs)
			{
				ls.Add(s);
			}
			return ls;
		}

		private void fillCombo()
		{
			comboDate.Items.Clear();
			if (detailedLogsGroupedByDay == null || detailedLogsGroupedByDay.Keys.Count == 0)
				return;
			if (radioMonthlyAggregates.Checked)
				fillComboMonths();
			else
				fillComboDays();
		}

		private void fillComboMonths()
		{
			for (int i = 0; i < this.yearMonths.Count; i++)
			{
				comboDate.Items.Add(this.yearMonths[i]);
			}
			comboDate.SelectedIndex = 0;
		}

		private void fillComboDays()
		{
			foreach (string k in detailedLogsGroupedByDay.Keys)
			{
				comboDate.Items.Add(k);
			}
			comboDate.SelectedIndex = 0;
		} 
		#endregion

		private void comboDate_SelectedIndexChanged(object sender, EventArgs e)
		{
			loadDgv();
		}

		private void loadDgv()
		{
			toggleControlsEnabled(false);

			if (radioDailyAggregates.Checked)
				taskLogItemBindingSource.DataSource = getAggregatedTasks(comboDate.Text, detailedLogsGroupedByDay);
			else if (radioMonthlyAggregates.Checked)
				taskLogItemBindingSource.DataSource = getAggregatedTasks(comboDate.Text, detailedLogsGroupedByMonth);
			else
			{
				taskLogItemBindingSource.DataSource = this.detailedLogsGroupedByDay[comboDate.Text];
				toggleControlsEnabled(true);
			}
		}

		private void toggleControlsEnabled(bool isEnabled)
		{
			buttonSave.Enabled = isEnabled;
			buttonDelete.Enabled = isEnabled;
			endTimeDataGridViewTextBoxColumn.Visible = isEnabled;
			startTimeDataGridViewTextBoxColumn.Visible = isEnabled;
		}

		private void radio_CheckedChanged(object sender, EventArgs e)
		{
			if (radioNet.Checked)
				btnToCsv.Enabled = false;
			else
				btnToCsv.Enabled = true;
				
			fillCombo();
			loadDgv();
		}

		#region tworzenie słownika TaskLogItems grupowanych po miesiącu
		private Dictionary<string, List<TaskLogItem>> groupTaskLogsByMonth()
		{
			Dictionary<string, List<TaskLogItem>> monthly = new Dictionary<string, List<TaskLogItem>>();
			foreach (string day in this.detailedLogsGroupedByDay.Keys)
			{
				List<TaskLogItem> dailyTasks = detailedLogsGroupedByDay[day];
				for (int i = 0; i < dailyTasks.Count; i++)
				{
					addTaskLogToDict(dailyTasks[i], monthly);
				}
			}
			return monthly;
		}

		private void addTaskLogToDict(TaskLogItem taskLogItem, Dictionary<string, List<TaskLogItem>> monthly)
		{
			if (monthly.ContainsKey(taskLogItem.yearMonth))
				monthly[taskLogItem.yearMonth].Add(taskLogItem);
			else
			{
				List<TaskLogItem> l = new List<TaskLogItem>();
				l.Add(taskLogItem);
				monthly.Add(taskLogItem.yearMonth, l);
			}
		}
		#endregion

		#region aggregowanie danych

		private Dictionary<string, List<TaskLogItem>> getAggregatedLog(Dictionary<string, List<TaskLogItem>> detailedLogs)
		{
			Dictionary<string, List<TaskLogItem>> dict = new Dictionary<string, List<TaskLogItem>>();
			foreach (string date in detailedLogs.Keys)
			{
				dict.Add(date, getAggregatedTasks(date, detailedLogs));
			}
			return dict;
		}

		private List<TaskLogItem> getAggregatedTasks(string date, Dictionary<string, List<TaskLogItem>> taskLogs)
		{
			List<TaskLogItem> items = taskLogs[date];
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
				t.clearWorkDetails();
				for (int i = 0; i < ls.Count; i++)
				{
					t.aggregate(ls[i]);
				}
				l.Add(t);
			}
			return l;
		}

		#endregion

		#region przyciski nawigatora
		private void buttonDelete_Click(object sender, EventArgs e)
		{
			TaskLogItem item = taskLogItemBindingSource.Current as TaskLogItem;
			int index = taskLogItemBindingSource.IndexOf(item);
			this.detailedLogsGroupedByDay[comboDate.Text].Remove(item);
			taskLogItemBindingSource.ResetBindings(true);
			setBindinsourcePosition(index);
		}

		private void setBindinsourcePosition(int index)
		{
			if (taskLogItemBindingSource.Count == 0)
				return;
			taskLogItemBindingSource.Position = index == 0 ? 0 : taskLogItemBindingSource.Position = index - 1;
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			new TaskLogManager().saveTaskLogs(LogType.Detailed, detailedLogsGroupedByDay);
			this.DialogResult = DialogResult.OK;
		}

		private void btnToCsv_Click(object sender, EventArgs e)
		{
			if (radioDailyAggregates.Checked)
				new TaskLogManager().saveTaskLogs(LogType.AggregatedDaily, getAggregatedLog(this.detailedLogsGroupedByDay));
			else if (radioMonthlyAggregates.Checked)
				new TaskLogManager().saveTaskLogs(LogType.AggregatedMonthly, getAggregatedLog(this.detailedLogsGroupedByMonth));
		}

		#endregion

	}
}
