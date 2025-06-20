using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TimeLogger
{
    public partial class GroupsForm: Form
    {
		private TaskGroupManager groupManager;

		public GroupsForm()
        {
            InitializeComponent();
		}

		private void TaskDictionaryForm_Load(object sender, EventArgs e)
		{
			groupManager = new TaskGroupManager();
			loadDgv();
		}

		private void loadDgv()
		{
			for (int i = 0; i < groupManager.groups.Count; i++)
			{
				dgv.Rows.Add(
					groupManager.groups[i].name,
					groupManager.groups[i].isActive);
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dgv.EndEdit();
			List<string> lines = new List<string>();
			for (int i = 0; i < dgv.RowCount - 1; i++)	//ostatni wiersz jest pusty
			{
				if (dgv.Rows[i].Cells[0].Value == null || String.IsNullOrEmpty(dgv.Rows[i].Cells[0].Value.ToString()))
					continue;
				lines.Add(dgv.Rows[i].Cells[0].Value.ToString() + ";" + boolToString((bool)(dgv.Rows[i].Cells[1] as DataGridViewCheckBoxCell).Value));
			}
			if (groupManager.saveGroups(lines))
				this.Close();
		}

		private string boolToString(bool isActive)
		{
			if (isActive)
				return "1";
			return "0";
		}
	}
}
