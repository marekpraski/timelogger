using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TimeLogger
{
    public partial class TaskStatisticsForm: Form
    {
		private enum FilterType
		{
			AggregatedDay,
			AggregatedDayGroup,
			AggregatedDayYearmonth,
			AggregatedDayGroupYearmonth,
			AggregatedMonth,
			AggregatedMonthGroup,
			Net,
			NetGroup,
			NetYearmonth,
			NetGroupYearmonth
		}

		/// <summary>
		/// kompletny log netto, pogrupowany ale nie zagregowany, kluczem jest pełna data rrrr-mm-dd
		/// </summary>
		private readonly Dictionary<string, List<TaskLogItem>> detailedLogsGroupedByDay;
		/// <summary>
		/// kompletny log netto, pogrupowany ale nie zagregowany, kluczem jest rok-miesiąc rrrr-mm
		/// </summary>
		private Dictionary<string, List<TaskLogItem>> detailedLogsGroupedByMonth;
		private bool isFormStarted = false;
		private FilterType activeFilter;

		public TaskStatisticsForm(Dictionary<string, List<TaskLogItem>> dailyTaskLogs)
        {
            InitializeComponent();
			this.detailedLogsGroupedByDay = dailyTaskLogs;
			detailedLogsGroupedByMonth = groupTaskLogsByMonth();
			this.activeFilter = FilterType.AggregatedDay;
		}

		#region metody na starcie
		private void TaskStatisticsForm_Load(object sender, EventArgs e)
		{
			fillComboGroup();
			fillComboYearMonth();
			fillComboDate();
			isFormStarted = true;
		}
		#endregion

		#region wypełnianie kombo dat

		private void fillComboDate()
		{
			switch (this.activeFilter)
			{
				case FilterType.Net:
				case FilterType.AggregatedDay:
					fillComboDateUnfiltered(detailedLogsGroupedByDay);
					break;
				case FilterType.AggregatedMonth:
					fillComboDateUnfiltered(detailedLogsGroupedByMonth);
					break;
				case FilterType.NetGroup:
				case FilterType.NetYearmonth:
				case FilterType.NetGroupYearmonth:
				case FilterType.AggregatedDayGroup:
				case FilterType.AggregatedDayYearmonth:
				case FilterType.AggregatedDayGroupYearmonth:
					fillComboDatesFiltered(detailedLogsGroupedByDay);
					break;
				case FilterType.AggregatedMonthGroup:
					fillComboDatesFiltered(detailedLogsGroupedByMonth);
					break;
			}
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

		private void fillComboDatesFiltered(Dictionary<string, List<TaskLogItem>> taskLog)
		{
			List<string> dates = new List<string>();
			foreach (string day in taskLog.Keys)
			{
				List<TaskLogItem> l = taskLog[day];
				for (int i = 0; i < l.Count; i++)
				{
					if (applyFilter(l[i]))
					{
						dates.Add(day);
						break;
					}
				}
			}
			loadComboDates(dates);
		}

		private bool applyFilter(TaskLogItem logItem)
		{
			switch (this.activeFilter)
			{
				case FilterType.NetGroup:
				case FilterType.AggregatedDayGroup:
				case FilterType.AggregatedMonthGroup:
					return logItem.groupName == comboGroup.Text;
				case FilterType.NetYearmonth:
				case FilterType.AggregatedDayYearmonth:
					return logItem.yearMonth == comboYearMonth.Text;
				case FilterType.NetGroupYearmonth:
				case FilterType.AggregatedDayGroupYearmonth:
					return logItem.groupName == comboGroup.Text && logItem.yearMonth == comboYearMonth.Text;
			}
			return false;
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

		private void fillComboYearMonth()
		{
			List<string> l = new List<string>(this.detailedLogsGroupedByMonth.Keys.Count + 1);
			l.Add("--All--");
			foreach (string ym in this.detailedLogsGroupedByMonth.Keys)
			{
				l.Add(ym);
			}
			List<string> ordered = l.OrderByDescending(i => i).ToList();
			comboYearMonth.DataSource = ordered;
			comboYearMonth.SelectedIndex = 0;
		}

		#endregion

		#region wypełnianie kombo grup
		private void fillComboGroup()
		{
			comboGroup.Items.Clear();
			comboGroup.Items.Add("--All--");
			List<string> groups = new TaskGroupManager().groupNames;
			for (int i = 0; i < groups.Count; i++)
			{
				comboGroup.Items.Add(groups[i]);
			}
			comboGroup.SelectedIndex = 0;
		} 
		#endregion

		#region zmiana wyboru w kombo grup
		private void comboGroup_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!isFormStarted)
				return;
			setActiveFilter();
			fillComboDate();
			loadDgv();
		}

		#endregion

		#region zmiana wyboru kombo dat
		private void comboDate_SelectedIndexChanged(object sender, EventArgs e)
		{
			loadDgv();
		}

		private void comboYearMonth_SelectedIndexChanged(object sender, EventArgs e)
		{
			setActiveFilter();
			fillComboDate();
		}
		#endregion

		#region zmiana wyboru radiobuttona
		private void radio_CheckedChanged(object sender, EventArgs e)
		{
			setActiveFilter();

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
		#endregion

		#region ładowanie danych do datagrida
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
			List<TaskLogItem> ordered = datasource.OrderBy(x => x.groupName).ToList();
			taskLogItemBindingSource.DataSource = activeFilter == FilterType.Net ? datasource : ordered;
			setDgvColumnPropeties();
		}

		private void setDgvColumnPropeties()
		{
			if (radioNet.Checked)
			{
				workDetailsDataGridViewTextBoxColumn.Width = 250;
				workDetailsDataGridViewTextBoxColumn.HeaderText = "workDetails (double click to edit)";
			}
			else
			{
				workDetailsDataGridViewTextBoxColumn.Width = 450;
				workDetailsDataGridViewTextBoxColumn.HeaderText = "workDetails";
			}
		}
		#endregion

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
		private void setActiveFilter()
		{
			if (!this.isFormStarted)
				return;
			if (radioNet.Checked && comboGroup.SelectedIndex == 0 && comboYearMonth.SelectedIndex == 0)
				this.activeFilter = FilterType.Net;
			else if (radioNet.Checked && comboGroup.SelectedIndex > 0 && comboYearMonth.SelectedIndex == 0)
				this.activeFilter = FilterType.NetGroup;
			else if (radioNet.Checked && comboGroup.SelectedIndex == 0 && comboYearMonth.SelectedIndex > 0)
				this.activeFilter = FilterType.NetYearmonth;
			else if (radioNet.Checked && comboGroup.SelectedIndex > 0 && comboYearMonth.SelectedIndex > 0)
				this.activeFilter = FilterType.NetGroupYearmonth;
			else if (radioDailyAggregates.Checked && comboGroup.SelectedIndex == 0 && comboYearMonth.SelectedIndex == 0)
				this.activeFilter = FilterType.AggregatedDay;
			else if (radioDailyAggregates.Checked && comboGroup.SelectedIndex > 0 && comboYearMonth.SelectedIndex == 0)
				this.activeFilter = FilterType.AggregatedDayGroup;
			else if (radioDailyAggregates.Checked && comboGroup.SelectedIndex == 0 && comboYearMonth.SelectedIndex > 0)
				this.activeFilter = FilterType.AggregatedDayYearmonth;
			else if (radioDailyAggregates.Checked && comboGroup.SelectedIndex > 0 && comboYearMonth.SelectedIndex > 0)
				this.activeFilter = FilterType.AggregatedDayGroupYearmonth;
			else if (radioMonthlyAggregates.Checked && comboGroup.SelectedIndex == 0)
				this.activeFilter = FilterType.AggregatedMonth;
			else if (radioMonthlyAggregates.Checked && comboGroup.SelectedIndex > 0)
				this.activeFilter = FilterType.AggregatedMonthGroup;
		}

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

		private List<Dictionary<string, List<TaskLogItem>>> getAggregatedLog(Dictionary<string, List<TaskLogItem>> detailedLogs)
		{
			List<Dictionary<string, List<TaskLogItem>>> l = new List<Dictionary<string, List<TaskLogItem>>>();
			for (int i = 0; i < comboDate.Items.Count; i++)
			{
				string d = comboDate.Items[i].ToString();
				l.Add(getAggregatedLogsPerGroup(detailedLogs, d));
			}
			return l;
		}

		/// <summary>
		/// z przekazanego słownika logów, gdzie kluczem jest data, pobiera listę logów, dla której kluczem jest data przekazana jako parametr;
		/// pracując na logach z tej listy zwraca słownik, gdzie kluczem jest nazwa grupy + nazwa zadania;
		/// </summary>
		private Dictionary<string, List<TaskLogItem>> getAggregatedLogsPerGroup(Dictionary<string, List<TaskLogItem>> detailedLogs, string date)
		{
			Dictionary<string, List<TaskLogItem>> dict = new Dictionary<string, List<TaskLogItem>>();
			foreach (string keyDate in detailedLogs.Keys)
			{
				if (keyDate == date)
					dict.Add(keyDate, getAggregatedTasks(detailedLogs, keyDate));
			}
			return dict;
		}

		/// <summary>
		/// przyjmuje słownik, gdzie kluczem jest data; data jest również przekazana jako parametr;
		/// na podstawie daty wyciąga właściwą listę logów z przekazanego słownika; z tej listy
		/// wyciąga zadania spełniające kryterium grupy wybranej z kombo; te zadania po zagregowaniu
		/// po nazwie grupy i opisie zwraca w postaci listy
		/// </summary>
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
					tryAddTaskListToAggregatedDictionary(aggregated, itemsOnSelectedDate[i]);
			}
			return splitDictionary(aggregated);
		}

		private void tryAddTaskLogToAggregatedList(List<TaskLogItem> items, TaskLogItem taskLogItem)
		{
			if (comboGroup.SelectedIndex < 1 ||
				(comboGroup.SelectedIndex > 0 && comboGroup.Text == taskLogItem.groupName))
				items.Add(taskLogItem);
		}

		private void tryAddTaskListToAggregatedDictionary(Dictionary<string, List<TaskLogItem>> aggregated, TaskLogItem taskLogItem)
		{
			if (comboGroup.SelectedIndex < 1 ||
				(comboGroup.SelectedIndex > 0 && comboGroup.Text == taskLogItem.groupName))
			{
				List<TaskLogItem> ts = new List<TaskLogItem>();
				ts.Add(taskLogItem);
				aggregated.Add(taskLogItem.groupName + taskLogItem.description, ts);
			}
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
				new TaskLogManager().saveTaskLogs(LogType.AggregatedDaily, getAggregatedLogsPerGroup(this.detailedLogsGroupedByDay, comboDate.Text));
			else if (radioMonthlyAggregates.Checked)
				new TaskLogManager().saveTaskLogs(LogType.AggregatedMonthly, getAggregatedLogsPerGroup(this.detailedLogsGroupedByMonth, comboDate.Text));

			MessageBox.Show("Saved");
		}

		private void btnToCsvAllDates_Click(object sender, EventArgs e)
		{
			if (radioDailyAggregates.Checked)
				new TaskLogManager().saveTaskLogs(LogType.AggregatedDaily, getAggregatedLog(this.detailedLogsGroupedByDay));
			else if (radioMonthlyAggregates.Checked)
				new TaskLogManager().saveTaskLogs(LogType.AggregatedMonthly, getAggregatedLog(this.detailedLogsGroupedByMonth));

			MessageBox.Show("Saved");
		}

		#endregion

		#region podwójny klik w komórce datagrida
		private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (activeFilter != FilterType.Net)
				return;
			if (dgv.Columns[e.ColumnIndex].Name == "taskDurationInHoursMinutes")
				return;
			TaskLogItem selected = taskLogItemBindingSource.Current as TaskLogItem;
			WorkDetailsEditForm editor = new WorkDetailsEditForm(selected, e.ColumnIndex);
			editor.ShowDialog();
			if (editor.DialogResult == DialogResult.OK)
			{
				taskLogItemBindingSource.ResetItem(taskLogItemBindingSource.IndexOf(taskLogItemBindingSource.Current));
				editor.Close();
			}
		} 
		#endregion

		#region pomocnicze
		private void toggleControlsEnabled(bool isEnabled)
		{
			buttonSave.Enabled = isEnabled;
			buttonDelete.Enabled = isEnabled;
			endTimeDataGridViewTextBoxColumn.Visible = isEnabled;
			startTimeDataGridViewTextBoxColumn.Visible = isEnabled;
		}
		#endregion

	}
}
