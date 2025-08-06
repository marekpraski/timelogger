using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeLogger
{
    public partial class TaskEditorForm: Form
    {
		private TaskLogItem selected;
		private TaskDefinitionsManager taskDefinitionsManager;
		private TaskGroupManager groupManager;

		public TaskEditorForm()
        {
            InitializeComponent();
        }

		public TaskEditorForm(TaskLogItem selected, TaskDefinitionsManager taskDefinitionsManager) : this()
		{
			this.selected = selected;
			this.taskDefinitionsManager = taskDefinitionsManager;
			this.groupManager = new TaskGroupManager();
		}

		private void TaskEditorForm_Load(object sender, EventArgs e)
		{
			if (groupManager.activeGroupsNames.Count == 0)
				btnSave.Enabled = false;
			else
				loadComboGroups();
		}

		private void loadComboGroups()
		{
			cbGroups.Items.AddRange(this.groupManager.activeGroupsNames.ToArray());
			cbGroups.SelectedIndex = cbGroups.FindStringExact(selected.groupName);
		}

		private void cbGroups_SelectedIndexChanged(object sender, EventArgs e)
		{
			cbTaskDefinitions.Items.Clear();
			loadComboTaskDefs();
		}

		private void loadComboTaskDefs()
		{
			List<TaskDefinitionItem> tasks = taskDefinitionsManager.getGroupTasks(cbGroups.Text);
			for (int i = 0; i < tasks.Count; i++)
			{
				cbTaskDefinitions.Items.Add(tasks[i].description);
			}
			if (cbTaskDefinitions.Items.Count > 0)
				cbTaskDefinitions.SelectedIndex = cbTaskDefinitions.FindStringExact(selected.description);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(cbGroups.Text) || String.IsNullOrEmpty(cbTaskDefinitions.Text))
				return;
			
			selected.taskDefinitionItem.groupName = cbGroups.Text;
			selected.taskDefinitionItem.description = cbTaskDefinitions.Text;
			this.DialogResult = DialogResult.OK;
		}
	}
}
