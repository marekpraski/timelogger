using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TimeLogger
{
    public partial class TaskDefinitionsForm: Form
    {
		private TaskGroupManager groupManager;
		private TaskDefinitionsManager definitionsManager;
        public TaskDefinitionsForm(TaskGroupManager groupManager, TaskDefinitionsManager definitionsManager)
        {
            InitializeComponent();
			this.groupManager = groupManager;
			this.definitionsManager = definitionsManager;
		}

		private void TaskDictionaryForm_Load(object sender, EventArgs e)
		{
			loadCombo(true);
		}

		private void TaskDefinitionsForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			dgv.EndEdit();
		}

		private void loadCombo(bool activeGroups)
		{
			comboGroups.Items.Clear();
			comboGroups.Items.Add("--All--");
			List<string> names = activeGroups ? groupManager.activeGroupsNames : groupManager.allGroupsNames;
			for (int i = 0; i < names.Count; i++)
			{
				comboGroups.Items.Add(names[i]);
			}

			if (names.Count > 0)
				comboGroups.SelectedIndex = 0;
		}

		private void loadDgv()
		{
			if (comboGroups.SelectedIndex == 0)
				loadAllGroups();
			else
				loadFilteredGroups(comboGroups.Text);
		}

		private void checkActiveGroups_CheckedChanged(object sender, EventArgs e)
		{
			loadCombo(!checkActiveGroups.Checked);
		}

		private void loadAllGroups()
		{
			if (checkActiveGroups.Checked)
				taskDictionaryItemBindingSource.DataSource = this.definitionsManager.taskDefinitionsActiveGroups;
			else
				taskDictionaryItemBindingSource.DataSource = this.definitionsManager.taskDefinitionsAll;
		}

		private void loadFilteredGroups(string groupName)
		{
			if (checkActiveGroups.Checked)
				taskDictionaryItemBindingSource.DataSource = filterGroups(this.definitionsManager.taskDefinitionsActiveGroups, groupName);
			else
				taskDictionaryItemBindingSource.DataSource = filterGroups(this.definitionsManager.taskDefinitionsAll, groupName);
		}

		private List<TaskDefinitionItem> filterGroups(List<TaskDefinitionItem> taskDefs, string groupName)
		{
			List<TaskDefinitionItem> filtered = new List<TaskDefinitionItem>();
			for (int i = 0; i < taskDefs.Count; i++)
			{
				if (taskDefs[i].groupName == groupName)
					filtered.Add(taskDefs[i]);
			}
			return filtered;
		}

		private void addToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(tbNewTask.Text))
				return;
			TaskDefinitionItem item = new TaskDefinitionItem() { description = tbNewTask.Text, groupName = comboGroups.Text, isActive = true };
			this.definitionsManager.addItem(item);
			taskDictionaryItemBindingSource.ResetBindings(true);
			tbNewTask.Clear();
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TaskDefinitionItem item = taskDictionaryItemBindingSource.Current as TaskDefinitionItem;
			this.definitionsManager.removeItem(item);
			taskDictionaryItemBindingSource.ResetBindings(true);
		}


		#region zmiana wybory w kombo grup
		private void comboGroups_SelectedIndexChanged(object sender, EventArgs e)
		{
			loadDgv();
		} 
		#endregion

		#region obsługa checkoboxa "isActive"
		//żeby wychwycić zaznaczenie/odznaczenie checkboksa za pierwszym razem trzeba użyć dwóch zdarzeń
		//CellValueChanged i CellMouseUp, bo samo CellValueChanged uruchamia się dopiero po opuszczeniu celki
		//czyli gdy datagrid "sądzi", że edycja została zakończona
		private void dgv_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex < 0 || e.ColumnIndex < 0)
				return;

			DataGridView dgv = sender as DataGridView;
			if (dgv.Columns[e.ColumnIndex].Name.Contains("isActive"))
			{
				dgv.EndEdit();
			}
		}

		private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0 || e.ColumnIndex < 0)
				return;
			if (e.ColumnIndex == 2)
			{
				bool isChecked = (bool)(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell).Value;
				TaskDefinitionItem item = taskDictionaryItemBindingSource.Current as TaskDefinitionItem;
				item.isActive = isChecked;
				taskDictionaryItemBindingSource.ResetCurrentItem();
				this.definitionsManager.saveTaskDefinitions();
			}
		}
		#endregion

		private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0 || e.ColumnIndex < 0)
				return;
			if (e.ColumnIndex == 1)
			{
				string descr = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
				TaskDefinitionItem item = taskDictionaryItemBindingSource.Current as TaskDefinitionItem;
				item.description = descr;
				taskDictionaryItemBindingSource.ResetCurrentItem();
				this.definitionsManager.saveTaskDefinitions();
			}
		}
	}
}
