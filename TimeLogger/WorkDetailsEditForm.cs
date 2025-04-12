using System;
using System.Windows.Forms;

namespace TimeLogger
{
    public partial class WorkDetailsEditForm: Form
    {
		private readonly TaskLogItem edited;

		public WorkDetailsEditForm(TaskLogItem edited)
        {
            InitializeComponent();
            tbDetails.Text = edited.workDetails;
			this.edited = edited;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			edited.workDetails = tbDetails.Text;
            this.DialogResult = DialogResult.OK;
		}
	}
}
