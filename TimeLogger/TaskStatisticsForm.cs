using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TimeLogger
{
    public partial class TaskStatisticsForm: Form
    {
		private readonly Dictionary<string, List<TaskLogItem>> detailedLogsGroupedByDay;    //kluczem jest pełna data rrrr-mm-dd
		private Dictionary<string, List<TaskLogItem>> detailedLogsGroupedByMonth;    //kluczem jest miesiąc rrrr-mm
		private bool isFormStarted = false;

		public TaskStatisticsForm(Dictionary<string, List<TaskLogItem>> dailyTaskLogs)
        {
            InitializeComponent();
			this.detailedLogsGroupedByDay = dailyTaskLogs;
			detailedLogsGroupedByMonth = groupTaskLogsByMonth();
		}

		#region metody na starcie
		private void TaskStatisticsForm_Load(object sender, EventArgs e)
		{
			fillComboGroup();
			fillComboDate();
			isFormStarted = true;
		}
		#endregion

		#region wypełnianie kombo dat
		private void fillComboDate()
		{
			if (radioMonthlyAggregates.Checked)
				fillComboMonths();
			else
				fillComboDays();
		}

		private void fillComboMonths()
		{
			if (comboGroup.SelectedIndex < 1)
				fillComboDateUnfiltered(detailedLogsGroupedByMonth);
			else
				fillComboDateFilteredByGroup(comboGroup.Text, detailedLogsGroupedByMonth);
		}

		private void fillComboDays()
		{
			if (comboGroup.SelectedIndex < 1)
				fillComboDateUnfiltered(detailedLogsGroupedByDay);
			else
				fillComboDateFilteredByGroup(comboGroup.Text, detailedLogsGroupedByDay);
		}

		private void fillComboDateUnfiltered(Dictionary<string, List<TaskLogItem>> taskLogs)
		{
			List<string> dates = new List<string>();
			foreach (string k in taskLogs.Keys)
			{
				dates.Add(k);
			}
			loadComboDates(dates);
		}

		private void loadComboDates(List<string> dates)
		{
			string selected = comboDate.Text;
			List<string> sorted = dates.OrderByDescending(i => i).ToList();
			comboDate.DataSource = sorted;
			if (sorted.Count == 0)
				return;
			int index = comboDate.FindStringExact(selected);
			comboDate.SelectedIndex = index < 0 ? 0 : index;
		}

		private void fillComboDateFilteredByGroup(string groupName, Dictionary<string, List<TaskLogItem>> taskLog)
		{
			List<string> dates = new List<string>();
			foreach (string day in taskLog.Keys)
			{
				List<TaskLogItem> l = taskLog[day];
				for (int i = 0; i < l.Count; i++)
				{
					if (l[i].groupName == groupName)
					{
						dates.Add(day);
						break;
					}
				}
			}
			loadComboDates(dates);
		}

		#endregion

		#region wypełnianie kombo grup
		private void fillComboGroup()
		{
			comboGroup.Items.Clear();
			comboGroup.Items.Add("All");
			List<string> groups = new TaskGroupManager().groupNames;
			for (int i = 0; i < groups.Count; i++)
			{
				comboGroup.Items.Add(groups[i]);
			}
			comboGroup.SelectedIndex = 0;
		} 
		#endregion

		#region zmiana wyboru w kombo
		private void comboGroup_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!isFormStarted)
				return;
			fillComboDate();
			loadDgv();
		}

		private void comboDate_SelectedIndexChanged(object sender, EventArgs e)
		{
			loadDgv();
		} 
		#endregion

		private void loadDgv()
		{
			toggleControlsEnabled(false);
			List<TaskLogItem> datasource;

			if (radioDailyAggregates.Checked)
				datasource = getAggregatedTasks(detailedLogsGroupedByDay, comboDate.Text);
			else if (radioMonthlyAggregates.Checked)
				datasource = getAggregatedTasks(detailedLogsGroupedByMonth, comboDate.Text);
			else
			{
				datasource = filterTaskLogsByGroup(this.detailedLogsGroupedByDay);
				toggleControlsEnabled(true);
			}
			taskLogItemBindingSource.DataSource = datasource;
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
			{
				btnToCsv.Enabled = false;
				comboGroup.SelectedIndex = 0;
			}
			else
				btnToCsv.Enabled = true;
				
			fillComboDate();
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

		#region filtrowanie danych
		private List<TaskLogItem> filterTaskLogsByGroup(Dictionary<string, List<TaskLogItem>> items)
		{
			if (String.IsNullOrEmpty(comboDate.Text))
				return null;
			if (comboGroup.SelectedIndex < 1)
				return items[comboDate.Text];
			
			List<TaskLogItem> raw = items[comboDate.Text];
			List<TaskLogItem> filtered = new List<TaskLogItem>();
			for (int i = 0; i < raw.Count; i++)
			{
				if (raw[i].groupName == comboGroup.Text)
					filtered.Add(raw[i]);
			}
			return filtered;
		} 
		#endregion

		#region aggregowanie danych

		private Dictionary<string, List<TaskLogItem>> getAggregatedLog(Dictionary<string, List<TaskLogItem>> detailedLogs)
		{
			Dictionary<string, List<TaskLogItem>> dict = new Dictionary<string, List<TaskLogItem>>();
			foreach (string date in detailedLogs.Keys)
			{
				if (date == comboDate.Text)
					dict.Add(date, getAggregatedTasks(detailedLogs, date));
			}
			return dict;
		}

		private List<TaskLogItem> getAggregatedTasks(Dictionary<string, List<TaskLogItem>> itemsDict, string date)
		{
			if (String.IsNullOrEmpty(date))
				return null;

			List<TaskLogItem> itemsOnSelectedDate = itemsDict[date];
			Dictionary<string, List<TaskLogItem>> aggregated = new Dictionary<string, List<TaskLogItem>>(); //kluczem jest nazwa grupy + nazwa zadania
			for (int i = 0; i < itemsOnSelectedDate.Count; i++)
			{
				string key = itemsOnSelectedDate[i].groupName + itemsOnSelectedDate[i].description;
				if (aggregated.ContainsKey(key))
					tryAddTaskLogToAggregatedList(aggregated[key], itemsOnSelectedDate[i]);
				else
					tryAddTaskToAggregatedDictionary(aggregated, itemsOnSelectedDate[i]);
			}
			return splitDictionary(aggregated);
		}

		private void tryAddTaskToAggregatedDictionary(Dictionary<string, List<TaskLogItem>> aggregated, TaskLogItem taskLogItem)
		{
			if (comboGroup.SelectedIndex < 1 ||
				(comboGroup.SelectedIndex > 0 && comboGroup.Text == taskLogItem.groupName))
			{
				List<TaskLogItem> ts = new List<TaskLogItem>();
				ts.Add(taskLogItem);
				aggregated.Add(taskLogItem.groupName + taskLogItem.description, ts);
			}
		}

		private void tryAddTaskLogToAggregatedList(List<TaskLogItem> items, TaskLogItem taskLogItem)
		{
			if (comboGroup.SelectedIndex < 1 || 
				(comboGroup.SelectedIndex > 0 && comboGroup.Text == taskLogItem.groupName))
				items.Add(taskLogItem);
		}

		private List<TaskLogItem> splitDictionary(Dictionary<string, List<TaskLogItem>> aggregated)
		{
			List<TaskLogItem> l = new List<TaskLogItem>();
			foreach (string key in aggregated.Keys)
			{
				List<TaskLogItem> ls = aggregated[key];
				TaskLogItem t = ls[0].clone();
				t.clearTimeInMinutesAndWorkDetails();
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
