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
		private TaskDefinitionsManager definitionsManager;
		private TaskLogManager logManager = new TaskLogManager();

		private int totalGroupboxHeigth = 0;
		private Button currentButton;
		private TaskLogItem currentTaskLogItem;
		private System.Windows.Forms.Timer timer;

        public MainForm()
        {
            InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			initializeProperties();
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
			this.definitionsManager = new TaskDefinitionsManager();
			this.taskDefinitions = this.definitionsManager.taskDefinitions;
			this.taskLogs = this.logManager.readTasks();
		}

		#region obliczanie wielkości groupboxów i formatki
		private void generateFormLayout()
		{
			ButtonGroup[] buttonGroups = generateButtons();
			int previousGroupboxHeigth = 0;
			for (int i = 0; i < buttonGroups.Length; i++)
			{
				GroupBox gbs = generateOneGroupbox(buttonGroups[i].buttons.Length, previousGroupboxHeigth);
				previousGroupboxHeigth += gbs.Height;
				gbs.Text = buttonGroups[i].groupName;
				addButtonsToGroupbox(gbs, buttonGroups[i].buttons);
				mainPanel.Controls.Add(gbs);
			}
			setFormSize();
		}

		private void setFormSize()
		{
			int w = 2 * Settings.horizontalGroupboxPadding + Settings.buttonWidth;
			int h = Settings.firstGroupboxVerticalLocation + this.totalGroupboxHeigth;
			if (h < Settings.minPanelHeigth)
				h = Settings.minPanelHeigth;

			mainPanel.Width = w + 40;
			mainPanel.Height = h + 80;
			tbWorkDetails.Width = Settings.buttonWidth;
			this.Size = new Size(mainPanel.Width + 10, mainPanel.Height + 50);
		}
		#endregion

		#region tworzenie groupboxów
		private GroupBox generateOneGroupbox(int numberOfButtons, int previousGroupboxHeigth)
		{
			GroupBox groupBox = new GroupBox();
			int groupboxVerticalLocation = previousGroupboxHeigth + Settings.firstGroupboxVerticalLocation + Settings.verticalGroupboxPadding;
			groupBox.Location = new System.Drawing.Point(Settings.horizontalGroupboxPadding, groupboxVerticalLocation);

			int groupboxHeight = numberOfButtons * (Settings.buttonHeigth + Settings.verticalButtonPadding) + Settings.firstButtonVerticalOffset;
			groupBox.Size = new System.Drawing.Size(Settings.buttonWidth + 2*Settings.horizontalButtonPadding, groupboxHeight);
			this.totalGroupboxHeigth += groupboxHeight;
			return groupBox;
		}
		#endregion

		#region tworzenie przycisków
		private ButtonGroup[] generateButtons()
		{
			Dictionary<string, List<Button>> btnGroups = new Dictionary<string, List<Button>>();
			List<TaskDefinitionItem> tasks = getActiveTasks();
			Button b;
			
			for (int i = 0; i < tasks.Count; i++)
			{
				b = generateOneButton(tasks[i], i);
				if (btnGroups.ContainsKey(tasks[i].groupName))
					btnGroups[tasks[i].groupName].Add(b);
				else
				{
					List<Button> bts = new List<Button>();
					bts.Add(b);
					btnGroups.Add(tasks[i].groupName, bts);
				}
			}
			ButtonGroup[] bgs = new ButtonGroup[btnGroups.Keys.Count];
			int k = 0;
			foreach(string key in btnGroups.Keys)
			{
				bgs[k] = new ButtonGroup() { buttons = btnGroups[key].ToArray(), groupName = key };
				k++;
			}
			return bgs;
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

		private Button generateOneButton(TaskDefinitionItem task, int index)
		{
			Button button = new Button();
			button.Click += new EventHandler(ButtonClick);
			button.Name = index.ToString();
			button.Tag = task;
			button.Text = task.description;
			button.Size = new Size(Settings.buttonWidth, Settings.buttonHeigth);
			button.BackColor = SystemColors.ButtonHighlight;
			return button;
		}
		#endregion

		#region dodawanie przycisków do groupboxów
		private void addButtonsToGroupbox(GroupBox gb, Button[] buttons)
		{
			for (int i = 0; i < buttons.Length; i++)
			{
				int buttonHorizontalLocation = Settings.horizontalButtonPadding;
				int buttonVerticalLocation = i * Settings.buttonHeigth + Settings.firstButtonVerticalOffset + Settings.verticalButtonPadding;

				buttons[i].Location = new Point(buttonHorizontalLocation, buttonVerticalLocation);
				gb.Controls.Add(buttons[i]);
			}
		}
		#endregion

		#region naciśnięcie przycisku
		private void ButtonClick(object sender, EventArgs e)
		{
			Button button = sender as Button;

			if (button.Equals(currentButton))
			{
				button.BackColor = SystemColors.ButtonHighlight;
				stopCurrentTask();
			}
			else
			{
				toggleButtonColour(button);
				stopCurrentTask();
				startNewTask(button);
				this.currentButton = button;
			}
			initializeTimer();
		}

		private void stopCurrentTask()
		{
			if (this.currentTaskLogItem == null)
				return;
			
			logCurrentTask();
			if (this.currentTaskLogItem.taskDurationInMinutes < 2)   //nie zapisuję tak krótkich zadań, prawdopodobnie to pomyłka
				removeTaskFromLog(this.currentTaskLogItem);
			else
				this.logManager.saveTaskLogs(LogType.Detailed, this.taskLogs);
			
			this.currentTaskLogItem = null;
			this.currentButton = null;
		}

		private void logCurrentTask()
		{
			if (this.currentTaskLogItem == null)
				return;

			this.currentTaskLogItem.setEndTime(DateTime.Now);
			this.currentTaskLogItem.setWorkDetails(tbWorkDetails.Text);
		}

		private void startNewTask(Button button)
		{
			TaskDefinitionItem taskDefinition = button.Tag as TaskDefinitionItem;
			this.currentTaskLogItem = new TaskLogItem(taskDefinition);
			tbWorkDetails.Clear();
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

		#region przyciski menu
		private void taskDictionaryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TaskGroupManager gm = new TaskGroupManager();
			if (gm.groupNames == null || gm.groupNames.Count == 0)
			{
				MessageBox.Show("You need to define groups first");
				return;
			}
			stopCurrentTask();
			TaskDefinitionsForm tdf = new TaskDefinitionsForm(gm);
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
			if (sf.DialogResult == DialogResult.OK)
				initializeProperties();
		}

		private void groupsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			stopCurrentTask();
			GroupsForm df = new GroupsForm();
			df.ShowDialog();
		} 
		#endregion

		#region pomocnicze
		private void toggleButtonColour(Button button)
		{
			Color c = button.BackColor;
			if (this.currentButton != null)
				this.currentButton.BackColor = SystemColors.ButtonHighlight;
			button.BackColor = Color.LightGreen;
		}

		private void reloadControls()
		{
			mainPanel.Controls.Clear();
			this.totalGroupboxHeigth = 0;
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
