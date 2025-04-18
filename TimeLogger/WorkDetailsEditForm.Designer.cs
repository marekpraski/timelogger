namespace TimeLogger
{
	partial class WorkDetailsEditForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tbDetails = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.labelWarning = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// tbDetails
			// 
			this.tbDetails.Location = new System.Drawing.Point(12, 33);
			this.tbDetails.Name = "tbDetails";
			this.tbDetails.Size = new System.Drawing.Size(400, 20);
			this.tbDetails.TabIndex = 0;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(418, 30);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(45, 23);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// labelWarning
			// 
			this.labelWarning.AutoSize = true;
			this.labelWarning.ForeColor = System.Drawing.Color.Red;
			this.labelWarning.Location = new System.Drawing.Point(13, 14);
			this.labelWarning.Name = "labelWarning";
			this.labelWarning.Size = new System.Drawing.Size(323, 13);
			this.labelWarning.TabIndex = 2;
			this.labelWarning.Text = "WARNING: changing into usupported value will crash the program!";
			// 
			// WorkDetailsEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(483, 65);
			this.Controls.Add(this.labelWarning);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.tbDetails);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "WorkDetailsEditForm";
			this.Text = "Work Details Editor";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbDetails;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label labelWarning;
	}
}