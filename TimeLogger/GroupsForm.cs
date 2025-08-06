using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TimeLogger
{
    public partial class GroupsForm: Form
    {
		private TaskGroupManager groupManager;
		public List<Group> renamedGroups;

		public GroupsForm()
        {
            InitializeComponent();
		}

		private void GroupForm_Load(object sender, EventArgs e)
		{
			groupManager = new TaskGroupManager();
			loadDgv();
		}

		private void loadDgv()
		{
			groupBindingSource.DataSource = this.groupManager.groups;
			groupBindingSource.AllowNew = true;
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dgv.EndEdit();
			List<string> lines = new List<string>();
			List<Group> renamed = new List<Group>();
			for (int i = 0; i < groupBindingSource.Count; i++)
			{
				Group g = groupBindingSource[i] as Group;
				if (String.IsNullOrEmpty(g.name))
					continue;
				lines.Add(g.toString());
				if (g.name != g.oldName && !g.isNew)
					renamed.Add(g);
			}
			groupManager.renameGroups(renamed);
			groupManager.saveGroups(lines);
			if (renamed.Count > 0)
			{
				this.DialogResult = DialogResult.Yes;
				this.renamedGroups = renamed;
			}
		}

		private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
		{
			groupBindingSource.AddNew();
		}
	}
}
