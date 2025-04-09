using System;
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
			loadCombo();
			loadDgv();
		}

		private void TaskDefinitionsForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			dgv.EndEdit();
		}

		private void loadCombo()
		{
			comboGroups.Items.Clear();
			for (int i = 0; i < groupManager.groupNames.Count; i++)
			{
				comboGroups.Items.Add(groupManager.groupNames[i]);
			}

			if (groupManager.groupNames.Count > 0)
				comboGroups.SelectedIndex = 0;
		}

		private void loadDgv()
		{
			taskDictionaryItemBindingSource.DataSource = this.definitionsManager.taskDefinitions;
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
				this.definitionsManager.saveDictionary();
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
				this.definitionsManager.saveDictionary();
			}
		}

	}
}
