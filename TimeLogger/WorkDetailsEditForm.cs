using System;
using System.Windows.Forms;

namespace TimeLogger
{
    public partial class WorkDetailsEditForm: Form
    {
		private readonly TaskLogItem edited;
		private readonly int columnIndex;

		public WorkDetailsEditForm(TaskLogItem edited, int columnIndex)
        {
            InitializeComponent();
			this.edited = edited;
			this.columnIndex = columnIndex;
			openTextInEditor();
		}

		private void openTextInEditor()
		{
			switch (columnIndex)
			{
				case 2:
					tbDetails.Text = edited.startDateTime.ToString();
					labelWarning.Visible = true;
					return;
				case 3:
					tbDetails.Text = edited.endDateTime.ToString();
					labelWarning.Visible = true;
					return;
				case 5:
					tbDetails.Text = edited.workDetails;
					labelWarning.Visible = false;
					return;
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			switch (columnIndex)
			{
				case 2:
					 edited.setStartTime(DateTime.Parse(tbDetails.Text));
					this.DialogResult = DialogResult.OK;
					return;
				case 3:
					 edited.setEndTime(DateTime.Parse(tbDetails.Text));
					this.DialogResult = DialogResult.OK;
					return;
				case 5:
					 edited.workDetailsObject.description = tbDetails.Text;
					this.DialogResult = DialogResult.OK;
					return;
			}
		}
	}
}
