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
			AggregatedDayGroupTask,
			AggregatedDayYearmonth,
			AggregatedDayGroupYearmonth,
			AggregatedDayGroupTaskYearmonth,
			AggregatedMonth,
			AggregatedMonthGroup,
			AggregatedMonthGroupTask,
			Net,
			NetGroup,
			NetGroupTask,
			NetYearmonth,
			NetGroupYearmonth,
			NetGroupTaskYearmonth,
			Undefined
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
		private TaskDefinitionsManager TaskDefinitionsManager;

		public TaskStatisticsForm(Dictionary<string, List<TaskLogItem>> dailyTaskLogs)
        {
            InitializeComponent();
			this.detailedLogsGroupedByDay = dailyTaskLogs;
			detailedLogsGroupedByMonth = groupTaskLogsByMonth();
			this.activeFilter = FilterType.AggregatedDay;
			this.TaskDefinitionsManager = new TaskDefinitionsManager();
			comboTask.Enabled = false;
		}

		#region metody na starcie
		private void TaskStatisticsForm_Load(object sender, EventArgs e)
		{
			fillComboAggregation();
			fillComboGroup();
			fillComboYearMonth();
			fillComboDate();
			isFormStarted = true;
			loadDgv();
		}

		private void fillComboAggregation()
		{
			comboAggregationType.Items.Add("aggregated daily");
			comboAggregationType.Items.Add("aggregated monthly");
			comboAggregationType.Items.Add("net");
			comboAggregationType.SelectedIndex = 0;
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
				case FilterType.AggregatedDayGroupTask:
				case FilterType.AggregatedDayYearmonth:
				case FilterType.AggregatedDayGroupYearmonth:
				case FilterType.AggregatedDayGroupTaskYearmonth:
					fillComboDatesFiltered(detailedLogsGroupedByDay);
					break;
				case FilterType.AggregatedMonthGroup:
				case FilterType.AggregatedMonthGroupTask:
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
				case FilterType.AggregatedDayGroupTask:
				case FilterType.AggregatedMonthGroupTask:
					return logItem.groupName == comboGroup.Text && logItem.description == comboTask.Text; 
				case FilterType.NetYearmonth:
				case FilterType.AggregatedDayYearmonth:
					return logItem.yearMonth == comboYearMonth.Text;
				case FilterType.NetGroupYearmonth:
				case FilterType.AggregatedDayGroupYearmonth:
					return logItem.groupName == comboGroup.Text && logItem.yearMonth == comboYearMonth.Text;
				case FilterType.AggregatedDayGroupTaskYearmonth:
					return logItem.groupName == comboGroup.Text && logItem.description == comboTask.Text && logItem.yearMonth == comboYearMonth.Text;

			}
			return false;
		}

		/// <summary>
		/// ta metoda powoduje ładowanie datagrida dwa razy 1. gdy ustawiam źródło danych kombo dat
		/// 2. gdy wybieram konkretną datę
		/// </summary>
		private void loadComboDates(List<string> dates)
		{
			string selected = comboDate.Text;
			List<string> sorted = dates.OrderByDescending(i => i).ToList();
			if (sorted.Count == 0)
				return;
			comboDate.DataSource = sorted;	//ustawia datę na pierwszą z góry
			int index = comboDate.FindStringExact(selected);   //a ja przy zmianie grupy chcę uzyskać dane dla tej grupy przy już wybranej dacie
			comboDate.SelectedIndex = index < 0 ? 0 : index;	//chociaż powoduje to przeładowanie datagrida
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
			List<string> groups = new TaskGroupManager().activeGroupsNames;
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
			if (!tryFillComboTasks())  //gdy kombo zadań się wypełni poprawnie, filtr ustawia się w zdarzeniu SelectedIndexChanged kombo zadań
				setActiveFilter();
			fillComboDate();  //datagrida ładuje w zdarzeniu zmiany daty
		}

		#endregion

		#region wypełnianie kombo zadań
		private bool tryFillComboTasks()
		{
			if (comboGroup.SelectedIndex == 0)
			{
				comboTask.SelectedIndex = -1;
				comboTask.Text = "";
				comboTask.Enabled = false;
				return false;
			}
			else
			{
				comboTask.Enabled = true;
				List<TaskDefinitionItem> groupTasks = this.TaskDefinitionsManager.getGroupTasks(comboGroup.Text);
				fillComboTasks(groupTasks);
				return true;
			}
		}

		private void fillComboTasks(List<TaskDefinitionItem> tasks)
		{
			comboTask.Items.Clear();
			comboTask.Items.Add("--All--");
			for (int i = 0; i < tasks.Count; i++)
			{
				comboTask.Items.Add(tasks[i].description);
			}
			comboTask.SelectedIndex = 0;
		}
		#endregion

		#region zmiana wyboru kombo zadań
		private void comboTask_SelectedIndexChanged(object sender, EventArgs e)
		{
			setActiveFilter();
			if (this.activeFilter == FilterType.NetGroupTask || 
				this.activeFilter == FilterType.NetGroup || 
				this.activeFilter == FilterType.NetGroupTaskYearmonth ||
				this.activeFilter == FilterType.AggregatedDayGroup ||
				this.activeFilter == FilterType.AggregatedDayGroupTask ||
				this.activeFilter == FilterType.AggregatedDayGroupTaskYearmonth ||
				this.activeFilter == FilterType.AggregatedMonthGroupTask
				)
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
			if (this.activeFilter == FilterType.NetGroupYearmonth ||
				this.activeFilter == FilterType.NetGroupTaskYearmonth ||
				this.activeFilter == FilterType.AggregatedDayYearmonth ||
				this.activeFilter == FilterType.AggregatedDayGroupYearmonth ||
				this.activeFilter == FilterType.AggregatedDayGroupTaskYearmonth
				)
				fillComboDate();
		}
		#endregion

		#region zmiana wyboru w kombo typu agregacji
		private void comboAggregationType_SelectedIndexChanged(object sender, EventArgs e)
		{
			setActiveFilter();

			if (comboAggregationType.Text.Contains("net"))
			{
				btnToCsv.Enabled = false;
				comboGroup.SelectedIndex = 0;
			}
			else
				btnToCsv.Enabled = true;

			fillComboDate();  //datagrida ładuje w zdarzeniu zmiany daty
		}
		#endregion

		#region ładowanie danych do datagrida
		private void loadDgv()
		{
			if (!isFormStarted)	//inaczej ładuje na starcie kilka razy, przy ładowaniu każdego kombo
				return;
			toggleControlsEnabled(false);
			List<TaskLogItem> datasource;

			if (comboAggregationType.Text.Contains("daily"))
				datasource = getAggregatedTasks(detailedLogsGroupedByDay, comboDate.Text);
			else if (comboAggregationType.Text.Contains("monthly"))
				datasource = getAggregatedTasks(detailedLogsGroupedByMonth, comboDate.Text);
			else
			{
				datasource = getFilteredTaskLogs(this.detailedLogsGroupedByDay);
				toggleControlsEnabled(true);
			}			
			List<TaskLogItem> ordered = datasource.OrderBy(x => x.groupName).ToList();
			taskLogItemBindingSource.DataSource = activeFilter == FilterType.Net ? datasource : ordered;
			setDgvColumnPropeties();
			setTimeLoggedLabelText(datasource);
		}

		private void setTimeLoggedLabelText(List<TaskLogItem> datasource)
		{
			if (comboAggregationType.Text.Contains("net"))
				toolStripLabelTimeLogged.Text = getTimeFromMinutes(datasource);
			else
				toolStripLabelTimeLogged.Text = getTimeFromHoursMinutes(datasource);

		}

		private string getTimeFromHoursMinutes(List<TaskLogItem> datasource)
		{
			int time = 0;
			for (int i = 0; i < datasource.Count; i++)
			{
				time += convertToMinutes(datasource[i].taskDurationInHoursMinutes);
			}
			return getHoursMinutes(time);
		}

		private int convertToMinutes(string hoursMinutes)
		{
			//hours + " hr  " + minutes + " min"
			int endIndexHr = hoursMinutes.IndexOf(" hr");
			int endIndexMinutes = hoursMinutes.IndexOf(" min");

			if (endIndexHr == -1)
			{
				string m = hoursMinutes.Substring(0, endIndexMinutes);
				return Convert.ToInt32(hoursMinutes.Substring(0, endIndexMinutes));
			}
			
			string hr = hoursMinutes.Substring(0, endIndexHr);
			int startIndexMinutes = endIndexHr + 5;
			string min = hoursMinutes.Substring(startIndexMinutes, hoursMinutes.Length - endIndexMinutes - 2);

			return 60 * Convert.ToInt32(hr) + Convert.ToInt32(min);
		}

		private string getTimeFromMinutes(List<TaskLogItem> datasource)
		{
			int time = 0;
			for (int i = 0; i < datasource.Count; i++)
			{
				time += datasource[i].taskDurationInMinutes;
			}
			return getHoursMinutes(time);
		}

		private string getHoursMinutes(int minutesTotal)
		{
			int hours = minutesTotal / 60;
			if (hours == 0)
				return minutesTotal + " min";

			int minutes = minutesTotal - hours * 60;
			return "total time logged: " + hours + " hr  " + minutes + " min";
		}

		private void setDgvColumnPropeties()
		{
			if (comboAggregationType.Text.Contains("net"))
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
			if (comboAggregationType.Text.Contains("net"))
				setNetFilter();
			else if (comboAggregationType.Text.Contains("daily"))
				setAggregateDailyFilter();
			else if (comboAggregationType.Text.Contains("monthly"))
				setAggregateMonhtlyFilter();
		}

		private void setNetFilter()
		{
			if (comboGroup.SelectedIndex == 0)
				this.activeFilter = applyYearMonthCondition(FilterType.Net);
			else if (comboGroup.SelectedIndex > 0 && comboTask.SelectedIndex == 0)
				this.activeFilter = applyYearMonthCondition(FilterType.NetGroup);
			else if (comboGroup.SelectedIndex > 0 && comboTask.SelectedIndex > 0)
				this.activeFilter = applyYearMonthCondition(FilterType.NetGroupTask);
		}

		private void setAggregateDailyFilter()
		{
			if (comboGroup.SelectedIndex == 0)
				this.activeFilter = applyYearMonthCondition(FilterType.AggregatedDay);
			else if (comboGroup.SelectedIndex > 0 && comboTask.SelectedIndex == 0)
				this.activeFilter = applyYearMonthCondition(FilterType.AggregatedDayGroup);
			else if (comboGroup.SelectedIndex > 0 && comboTask.SelectedIndex > 0)
				this.activeFilter = applyYearMonthCondition(FilterType.AggregatedDayGroupTask);
		}

		private void setAggregateMonhtlyFilter()
		{
			if (comboGroup.SelectedIndex == 0)
				this.activeFilter = FilterType.AggregatedMonth;
			else if (comboGroup.SelectedIndex > 0 && comboTask.SelectedIndex == 0)
				this.activeFilter = FilterType.AggregatedMonthGroup;
			else if (comboGroup.SelectedIndex > 0 && comboTask.SelectedIndex > 0)
				this.activeFilter = FilterType.AggregatedMonthGroupTask;
		}

		private FilterType applyYearMonthCondition(FilterType groupTaskFilter)
		{
			if (comboYearMonth.SelectedIndex == 0)
				return groupTaskFilter;
			return getYearMonthFilter(groupTaskFilter);
		}

		private FilterType getYearMonthFilter(FilterType groupTaskFilter)
		{
			switch (groupTaskFilter)
			{
				case FilterType.Net:
					return FilterType.NetYearmonth;
				case FilterType.NetGroup:
					return FilterType.NetGroupYearmonth;
				case FilterType.NetGroupTask:
					return FilterType.NetGroupTaskYearmonth;
				case FilterType.AggregatedDay:
					return FilterType.AggregatedDayYearmonth;
				case FilterType.AggregatedDayGroup:
					return FilterType.AggregatedDayGroupYearmonth;
				case FilterType.AggregatedDayGroupTask:
					return FilterType.AggregatedDayGroupTaskYearmonth;
				default:
					return FilterType.Undefined;
			}
		}

		private List<TaskLogItem> getFilteredTaskLogs(Dictionary<string, List<TaskLogItem>> items)
		{
			if (String.IsNullOrEmpty(comboDate.Text))
				return null;
			if (comboGroup.SelectedIndex < 1)
				return items[comboDate.Text];
			
			List<TaskLogItem> raw = items[comboDate.Text];
			List<TaskLogItem> filtered = new List<TaskLogItem>();
			for (int i = 0; i < raw.Count; i++)
			{
				tryAddFiltered(filtered, raw[i]);
			}
			return filtered;
		}

		private void tryAddFiltered(List<TaskLogItem> filtered, TaskLogItem item)
		{
			if (this.activeFilter == FilterType.Net)
				filtered.Add(item);
			if (this.activeFilter == FilterType.NetGroup || this.activeFilter == FilterType.NetGroupYearmonth)
				tryAddFilteredByGroup(filtered, item);
			else if (this.activeFilter == FilterType.NetGroupTask || this.activeFilter == FilterType.NetGroupTaskYearmonth)
				tryAddFilteredByGroupTask(filtered, item);
		}

		private void tryAddFilteredByGroup(List<TaskLogItem> filtered, TaskLogItem item)
		{
			if (item.groupName == comboGroup.Text)
				filtered.Add(item);
		}

		private void tryAddFilteredByGroupTask(List<TaskLogItem> filtered, TaskLogItem item)
		{
			if (comboTask.SelectedIndex < 1)
				filtered.Add(item);
			else if (item.groupName == comboGroup.Text && item.description == comboTask.Text)
				filtered.Add(item);
		}

		#endregion

		#region aggregowanie danych

			#region agregacja w celu zapisu do csv
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
		#endregion

			#region agregacja w celu wyświetlenia w datagridzie
		/// <summary>
		/// przyjmuje słownik, gdzie kluczem jest data, która może być rrrr-mm-dd (daily aggregate) lub rrrr-mm (monhtly aggregate); 
		/// data jest również przekazana jako parametr; dla wyświetlenia w datagridzie jest to data z kombo comboDate
		/// na podstawie daty wyciąga właściwą listę logów z przekazanego słownika; z tej listy
		/// wyciąga zadania spełniające kryterium grupy wybranej z kombo; 
		/// w przypadku filtra tylko po grupie te zadania po zagregowaniu po nazwie grupy i nazwie zadania zwraca w postaci listy;
		/// dla filtra również po zadaniach agreguje zadania w grupie po opisie pracy (WorkDetails)
		/// </summary>
		private List<TaskLogItem> getAggregatedTasks(Dictionary<string, List<TaskLogItem>> itemsDict, string date)
		{
			if (String.IsNullOrEmpty(date))
				return null;

			List<TaskLogItem> itemsOnSelectedDate = itemsDict[date];
			Dictionary<string, List<TaskLogItem>> grouped = groupLogsOnGroupTask(itemsOnSelectedDate);
			return applyTaskFilter(grouped);
		}

		#region grupowanie po grupie i nazwie zadania
		/// <summary>
		///  zwracany słownik zawiera pogrupowane logi, kluczem jest nazwa grupy + nazwa zadania
		/// </summary>
		private Dictionary<string, List<TaskLogItem>> groupLogsOnGroupTask(List<TaskLogItem> itemsOnSelectedDate)
		{
			Dictionary<string, List<TaskLogItem>> grouped = new Dictionary<string, List<TaskLogItem>>();
			for (int i = 0; i < itemsOnSelectedDate.Count; i++)
			{
				string key = itemsOnSelectedDate[i].groupName + itemsOnSelectedDate[i].description;
				if (grouped.ContainsKey(key))
					tryAddTaskLogToGroupedList(grouped[key], itemsOnSelectedDate[i]);
				else
					tryAddTaskListToGroupedDictionary(grouped, itemsOnSelectedDate[i]);
			}
			return grouped;
		}

		/// <summary>
		/// dodaje pojedynczy log do istniejącej listy w słowniku
		/// </summary>
		private void tryAddTaskLogToGroupedList(List<TaskLogItem> items, TaskLogItem taskLogItem)
		{
			if (comboGroup.SelectedIndex < 1 ||
				(comboGroup.SelectedIndex > 0 && comboGroup.Text == taskLogItem.groupName))
				items.Add(taskLogItem);
		}

		/// <summary>
		/// lista w słowniku nie istnieje, więc tworzy nową listę, dodaje do niej przekazanego loga i dodaje wpis do słownika
		/// </summary>
		private void tryAddTaskListToGroupedDictionary(Dictionary<string, List<TaskLogItem>> grouped, TaskLogItem taskLogItem)
		{
			if (comboGroup.SelectedIndex < 1 ||
				(comboGroup.SelectedIndex > 0 && comboGroup.Text == taskLogItem.groupName))
			{
				List<TaskLogItem> ts = new List<TaskLogItem>();
				ts.Add(taskLogItem);
				grouped.Add(taskLogItem.groupName + taskLogItem.description, ts);
			}
		} 
		#endregion

		private List<TaskLogItem> applyTaskFilter(Dictionary<string, List<TaskLogItem>> grouped)
		{
			if (this.activeFilter == FilterType.NetGroupTask ||
				this.activeFilter == FilterType.NetGroupTaskYearmonth ||
				this.activeFilter == FilterType.AggregatedDayGroupTask ||
				this.activeFilter == FilterType.AggregatedDayGroupTaskYearmonth ||
				this.activeFilter == FilterType.AggregatedMonthGroupTask
				)
				return aggregateTasksByWorkDetails(grouped);   //stosuję filtr po szczegółach i wtedy agreguję
			else
				return aggregateDictionaryEntries(grouped, false);  //nie stosuję filtra, agreguję jak jest
		}

		#region grupowanie po grupie, nazwie zadania i szczegółach pracy
		private List<TaskLogItem> aggregateTasksByWorkDetails(Dictionary<string, List<TaskLogItem>> logsGroupedOnGroupTask)
		{
			Dictionary<string, List<TaskLogItem>> grouped = groupLogsOnGroupTaskWorkDetails(logsGroupedOnGroupTask);
			return aggregateDictionaryEntries(grouped, true);
		}

		/// <summary>
		/// w parametrze przyjmuje słownik logów pogrupowanych po mazwie grupy i nazwie zadania (taki jest klucz słownika)
		/// zwraca słownik którego kluczem jest nazwa grupy, nazwa zadania i szczegóły pracy
		/// </summary>
		private Dictionary<string, List<TaskLogItem>> groupLogsOnGroupTaskWorkDetails(Dictionary<string, List<TaskLogItem>> logsGroupedOnGroupTask)
		{
			string groupTask = comboGroup.Text + comboTask.Text;
			if (!logsGroupedOnGroupTask.ContainsKey(groupTask))
				return null;
			List<TaskLogItem> selectedGroupTaskLogs = logsGroupedOnGroupTask[groupTask];

			Dictionary<string, List<TaskLogItem>> grouped = new Dictionary<string, List<TaskLogItem>>();
			for (int i = 0; i < selectedGroupTaskLogs.Count; i++)
			{
				string key = groupTask + selectedGroupTaskLogs[i].workDetails;
				if (grouped.ContainsKey(key))
					tryAddTaskLogToGroupedTaskList(grouped[key], selectedGroupTaskLogs[i]);
				else
					tryAddTaskListToGroupedTaskDictionary(grouped, selectedGroupTaskLogs[i]);
			}
			return grouped;
		}

		private void tryAddTaskLogToGroupedTaskList(List<TaskLogItem> items, TaskLogItem taskLogItem)
		{
			if (comboTask.SelectedIndex == 0 ||
				(comboTask.SelectedIndex > 0 && comboTask.Text == taskLogItem.description))
				items.Add(taskLogItem);
		}

		private void tryAddTaskListToGroupedTaskDictionary(Dictionary<string, List<TaskLogItem>> grouped, TaskLogItem taskLogItem)
		{
			if (comboTask.SelectedIndex == 0 ||
				(comboTask.SelectedIndex > 0 && comboTask.Text == taskLogItem.description))
			{
				List<TaskLogItem> ts = new List<TaskLogItem>();
				ts.Add(taskLogItem);
				grouped.Add(taskLogItem.groupName + taskLogItem.description + taskLogItem.workDetails, ts);
			}
		}
		#endregion

		/// <summary>
		/// przekształca słownik w listę logów agregując logi w każdej liście (z każdej listy powstaje jeden log)
		/// </summary>
		private List<TaskLogItem> aggregateDictionaryEntries(Dictionary<string, List<TaskLogItem>> groupedLogs, bool isGroupedByWorkDetails)
		{
			List<TaskLogItem> l = new List<TaskLogItem>();
			if (groupedLogs != null)
				doAggregation(l, groupedLogs, isGroupedByWorkDetails);

			return l;
		}

		private void doAggregation(List<TaskLogItem> l, Dictionary<string, List<TaskLogItem>> groupedLogs, bool isGroupedByWorkDetails)
		{
			foreach (string key in groupedLogs.Keys)
			{
				List<TaskLogItem> ls = groupedLogs[key];
				TaskLogItem t = ls[0].clone();
				t.clearTimeInMinutesAndWorkDetails(!isGroupedByWorkDetails);  // gdy agreguję również po szczegółach zadania nie usuwam szczegółów
				for (int i = 0; i < ls.Count; i++)
				{
					t.aggregate(ls[i], !isGroupedByWorkDetails);  //przy grupowaniu po szczegółach nie chcę, by te same szczegóły wielokrotnie się powtarzały w zagregowanym logu
				}
				l.Add(t);
			}
		}
		#endregion

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
			if (comboAggregationType.Text.Contains("daily"))
				new TaskLogManager().saveTaskLogs(LogType.AggregatedDaily, getAggregatedLogsPerGroup(this.detailedLogsGroupedByDay, comboDate.Text));
			else if (comboAggregationType.Text.Contains("monthly"))
				new TaskLogManager().saveTaskLogs(LogType.AggregatedMonthly, getAggregatedLogsPerGroup(this.detailedLogsGroupedByMonth, comboDate.Text));

			MessageBox.Show("Saved");
		}

		private void btnToCsvAllDates_Click(object sender, EventArgs e)
		{
			if (comboAggregationType.Text.Contains("daily"))
				new TaskLogManager().saveTaskLogs(LogType.AggregatedDaily, getAggregatedLog(this.detailedLogsGroupedByDay));
			else if (comboAggregationType.Text.Contains("monthly"))
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
