using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TimeLogger
{
    public partial class MainForm: Form
    {
		private List<TaskDefinitionItem> taskDefinitions;
		private Dictionary<string, List<TaskLogItem>> taskLogs;
		private TaskDefinitionsManager taskDefinitionsManager;
		Dictionary<string, List<Button>> taskButtonDict;
		private TaskLogManager logManager = new TaskLogManager();
		private Button[] groupButtons;

		private Button currentGroupButton;
		private Button currentTaskButton;
		private TaskLogItem currentTaskLogItem;
		private Timer timer;

        public MainForm()
        {
            InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			initializeProperties();
			this.groupButtons = generateGroupButtons();
			generateFormLayout();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.currentTaskLogItem == null)
				return;
			stopCurrentTask();
		}

		private void initializeProperties()
		{
			this.currentGroupButton = null;
			this.currentTaskButton = null;
			this.taskDefinitionsManager = new TaskDefinitionsManager();
			this.taskDefinitions = this.taskDefinitionsManager.taskDefinitionsAll;
			this.taskLogs = this.logManager.readTasks();
			this.taskButtonDict = generateTaskButtons();
		}

		#region obliczanie wielkości groupboxów i formatki
		private void generateFormLayout()
		{
			populateGroupPanel();
			Button[] taskButtons = populateTaskPanel();
			setFormLayout(groupButtons, taskButtons);
		}

		private void populateGroupPanel()
		{
			addButtonsToPanel(groupPanel, groupButtons);
			groupPanel.Width = 10 + Settings.groupButtonWidth;
		}

		private Button[] populateTaskPanel()
		{
			Button[] taskButtons = getTaskButtons();
			addButtonsToPanel(taskPanel, taskButtons);
			taskPanel.Width = 10 + Settings.taskButtonWidth;
			taskPanel.Location = new Point(groupPanel.Width + Settings.horizontalPadding, taskPanel.Location.Y);
			return taskButtons;
		}

		private Button[] getTaskButtons()
		{
			if (this.currentGroupButton == null)
				return null;
			if (this.taskButtonDict.ContainsKey(this.currentGroupButton.Tag.ToString()))
				return this.taskButtonDict[this.currentGroupButton.Tag.ToString()].ToArray();
			return null;
		}

		private void setFormLayout(Button[] groupButtons, Button[] taskButtons)
		{
			groupPanel.Height = calculatePanelHeight(groupButtons);
			taskPanel.Height = calculatePanelHeight(taskButtons);
			int ht = groupPanel.Height > taskPanel.Height ? groupPanel.Height : taskPanel.Height;
			int wt = groupPanel.Width + taskPanel.Width + 2 * Settings.horizontalPadding + 10;
			comboWorkDetails.Width = groupPanel.Width + taskPanel.Width - btnDeleteWorkDetails.Width;
			btnDeleteWorkDetails.Location = new Point(comboWorkDetails.Width + Settings.horizontalPadding, btnDeleteWorkDetails.Location.Y);
			if (ht < Settings.minMainFormHeigth)
				ht = Settings.minMainFormHeigth;
			this.Size = new Size(wt, ht + 120);
		}

		private int calculatePanelHeight(Button[] groupButtons)
		{
			if (groupButtons == null)
				return 100;
			return groupButtons.Length * (Settings.buttonHeigth + Settings.verticalButtonPadding) + 25;
		}
		#endregion

		#region tworzenie przycisków grup
		private Button[] generateGroupButtons()
		{
			TaskGroupManager gm = new TaskGroupManager();
			if (gm.activeGroupsNames.Count == 0)
				return null;
			Button[] grB = new Button[gm.activeGroupsNames.Count];
			for (int i = 0; i < gm.activeGroupsNames.Count; i++)
			{
				grB[i] = generateOneGroupButton(gm.activeGroupsNames[i], i);
			}
			return grB;
		}

		private Button generateOneGroupButton(string groupName, int index)
		{
			Button button = new Button();
			button.Click += new EventHandler(groupButtonClick);
			button.Name = "group" + index.ToString();
			button.Text = groupName;
			button.Tag = groupName;
			button.Size = new Size(Settings.groupButtonWidth, Settings.buttonHeigth);
			button.BackColor = SystemColors.ButtonHighlight;
			return button;
		}

		private void addButtonsToPanel(GroupBox panel, Button[] buttons)
		{
			panel.Controls.Clear();
			if (buttons == null)
				return;
			for (int i = 0; i < buttons.Length; i++)
			{
				buttons[i].Location = new Point(3, 20 + i * (Settings.buttonHeigth + Settings.verticalButtonPadding));
				panel.Controls.Add(buttons[i]);
			}
		}
		#endregion

		#region tworzenie przycisków zadań

		private Dictionary<string, List<Button>> generateTaskButtons()
		{
			Dictionary<string, List<Button>> taskBtnDict = new Dictionary<string, List<Button>>();
			List<TaskDefinitionItem> tasks = getActiveTasks();
			Button b;
			
			for (int i = 0; i < tasks.Count; i++)
			{
				b = generateOneTaskButton(tasks[i], i);
				if (taskBtnDict.ContainsKey(tasks[i].groupName))
					taskBtnDict[tasks[i].groupName].Add(b);
				else
				{
					List<Button> bts = new List<Button>();
					bts.Add(b);
					taskBtnDict.Add(tasks[i].groupName, bts);
				}
			}
			return taskBtnDict;
		}

		private List<TaskDefinitionItem> getActiveTasks()
		{
			List<TaskDefinitionItem> tasks = new List<TaskDefinitionItem>();
			for (int i = 0; i < this.taskDefinitions.Count; i++)
			{
				if (taskDefinitions[i].isActive)
					tasks.Add(taskDefinitions[i]);
			}
			return tasks;
		}

		private Button generateOneTaskButton(TaskDefinitionItem task, int index)
		{
			Button button = new Button();
			button.Click += new EventHandler(taskButtonClick);
			button.Name = "task" + index.ToString();
			button.Tag = task;
			button.Text = task.description;
			button.Size = new Size(Settings.taskButtonWidth, Settings.buttonHeigth);
			button.BackColor = SystemColors.ButtonHighlight;
			return button;
		}
		#endregion

		#region naciśnięcie przycisku grupy
		private void groupButtonClick(object sender, EventArgs e)
		{
			Button button = sender as Button;
			groupButtonActions(button);
			if (this.currentTaskButton != null)
				taskButtonActions(this.currentTaskButton);
		}

		private void groupButtonActions(Button button)
		{
			if (button.Equals(currentGroupButton))
			{
				button.BackColor = SystemColors.ButtonHighlight;
				this.currentGroupButton = null;
			}
			else
			{
				toggleGroupButtonColour(button, false);
				this.currentGroupButton = button;
				Button[] taskButtons = populateTaskPanel();
				setFormLayout(groupButtons, taskButtons);
			}
		}

		#endregion

		#region naciśnięcie przycisku zadania

		private void taskButtonClick(object sender, EventArgs e)
		{
			Button button = sender as Button;
			if (this.currentGroupButton == null)
				return;
			taskButtonActions(button);
		}

		private void taskButtonActions(Button button)
		{
			if (button.Equals(currentTaskButton))
			{
				button.BackColor = SystemColors.ButtonHighlight;
				toggleGroupButtonColour(this.currentGroupButton, false);
				stopCurrentTask();
			}
			else
			{
				toggleTaskButtonColour(button);
				toggleGroupButtonColour(this.currentGroupButton, true);
				stopCurrentTask();
				startNewTask(button);
				this.currentTaskButton = button;
			}
			initializeTimer();
		}

		private void stopCurrentTask()
		{
			if (this.currentTaskLogItem == null)
				return;
			
			logCurrentTask();
			int minDuration;
#if DEBUG
			minDuration = 0;
#else
			minDuration = 1;
#endif
			if (this.currentTaskLogItem.taskDurationInMinutes < minDuration)   //nie zapisuję tak krótkich zadań, prawdopodobnie to pomyłka
				removeTaskFromLog(this.currentTaskLogItem);
			else
				this.logManager.saveTaskLogs(LogType.Detailed, this.taskLogs);
			
			this.currentTaskLogItem = null;
			this.currentTaskButton = null;
		}

		private void logCurrentTask()
		{
			if (this.currentTaskLogItem == null)
				return;

			this.currentTaskLogItem.setEndTime(DateTime.Now);
			this.currentTaskLogItem.setTimeInMinutes();
			this.currentTaskLogItem.setWorkDetails(comboWorkDetails.Text);
			if (this.currentTaskLogItem.taskDefinitionItem.addWorkDetails(comboWorkDetails.Text))
				this.taskDefinitionsManager.modifyItem(this.currentTaskLogItem.taskDefinitionItem);
		}

		private void startNewTask(Button button)
		{
			TaskDefinitionItem taskDefinition = button.Tag as TaskDefinitionItem;
			this.currentTaskLogItem = new TaskLogItem(taskDefinition);
			fillComboWorkDetails();
			startLogging(this.currentTaskLogItem);
		}

		private void startLogging(TaskLogItem item)
		{
			if (this.taskLogs.ContainsKey(item.date))
				taskLogs[item.date].Add(item);
			else
			{
				List<TaskLogItem> l = new List<TaskLogItem>();
				l.Add(item);
				taskLogs.Add(item.date, l);
			}
		}

		private void removeTaskFromLog(TaskLogItem logItem)
		{
			this.taskLogs[logItem.date].Remove(logItem);
		}
		#endregion

		#region wypełnianie kombo szczegółów zadania
		private void fillComboWorkDetails()
		{
			comboWorkDetails.Items.Clear();
			List<WorkDetailsItem> workDetails = this.taskDefinitionsManager.getWorkDetails(this.currentTaskLogItem.taskDefinitionItem);
			for (int i = 0; i < workDetails.Count; i++)
			{
				comboWorkDetails.Items.Add(workDetails[i].description);
			}
			comboWorkDetails.SelectedIndex = -1;
			comboWorkDetails.Text = "";
		} 
		#endregion

		#region przyciski menu
		private void taskDictionaryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TaskGroupManager gm = new TaskGroupManager();
			if (gm.activeGroupsNames == null || gm.activeGroupsNames.Count == 0)
			{
				MessageBox.Show("You need to define groups first");
				return;
			}
			stopCurrentTask();
			TaskDefinitionsForm tdf = new TaskDefinitionsForm(gm, this.taskDefinitionsManager);
			tdf.ShowDialog();
			reloadControls();
		}

		private void taskStatsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			stopCurrentTask();
			if (taskLogs == null || taskLogs.Count == 0)
			{
				MessageBox.Show("No statistics to display");
				return;
			}
			TaskStatisticsForm sf = new TaskStatisticsForm(taskLogs);
			sf.ShowDialog();
			reloadControls();
		}

		private void groupsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			stopCurrentTask();
			GroupsForm df = new GroupsForm();
			df.ShowDialog();
			this.groupButtons = generateGroupButtons();
			reloadControls();
		}
		#endregion

		#region przycisk usuwania szczegółów zadania
		private void btnDeleteWorkDetails_Click(object sender, EventArgs e)
		{
			if (comboWorkDetails.Items.Count == 0)
				return;
			if (this.currentTaskLogItem.taskDefinitionItem.removeWorkDetails(comboWorkDetails.Text))
			{
				this.taskDefinitionsManager.modifyItem(this.currentTaskLogItem.taskDefinitionItem);
				comboWorkDetails.Items.RemoveAt(comboWorkDetails.SelectedIndex);
			}
		}
		#endregion

		#region pomocnicze

		private void toggleGroupButtonColour(Button button, bool isTaskOn)
		{
			if (button == null)
				return;
			Color c = button.BackColor;
			if (this.currentGroupButton != null)
				this.currentGroupButton.BackColor = SystemColors.ButtonHighlight;

			button.BackColor = isTaskOn ? Color.LightGreen : Color.Yellow;
		}

		private void toggleTaskButtonColour(Button button)
		{
			Color c = button.BackColor;
			if (this.currentTaskButton != null)
				this.currentTaskButton.BackColor = SystemColors.ButtonHighlight;
			button.BackColor = Color.LightGreen;
		}

		private void reloadControls()
		{
			groupPanel.Controls.Clear();
			taskPanel.Controls.Clear();
			if (this.currentGroupButton != null)
				this.currentGroupButton.BackColor = SystemColors.ButtonHighlight;   //inaczej pozostaje żółty. jeżeli był wcześniej kliknięty
			initializeProperties();
			generateFormLayout();
		}
		#endregion

		#region obsługa automatycznego zapisu
		private void initializeTimer()
		{
			if (this.timer != null)
			{
				timer.Stop();
				timer.Dispose();
			}
			if (this.currentTaskLogItem == null)
				return;

			this.timer = new System.Windows.Forms.Timer();
			timer.Interval = 3600000;
			timer.Tick += timer_Tick;
			timer.Start();
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			logCurrentTask();
			this.logManager.saveTaskLogs(LogType.Detailed, this.taskLogs);
		}
		#endregion

	}
}
