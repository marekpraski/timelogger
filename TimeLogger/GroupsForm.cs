using System;
using System.Collections.Generic;
using System.Text;
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
			for (int i = 0; i < groupManager.groupNames.Count; i++)
			{
				dgv.Rows.Add(groupManager.groupNames[i]);
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dgv.EndEdit();
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < dgv.RowCount - 1; i++)	//ostatni wiersz jest pusty
			{
				sb.Append(dgv.Rows[i].Cells[0].Value.ToString());
				sb.Append(";");
			}
			if (groupManager.saveGroups(sb.ToString()))
				this.Close();
		}
	}
}
