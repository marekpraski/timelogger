using System;
using System.Text;
using System.Collections.Generic;

namespace TimeLogger
{
    public class TaskDefinitionItem
    {
		public int id = 0;
		public string description { get; set; }
		public string groupName { get; set; }
		public bool isActive { get; set; }
		public List<WorkDetailsItem> workDetails { get; set; }
		public string sortCriterion { get => groupName + this.description; }

		public TaskDefinitionItem()
		{
			this.workDetails = new List<WorkDetailsItem>();
		}

		public TaskDefinitionItem(string taskDictItemAsString) : this()
		{
			string[] s = taskDictItemAsString.Split(';');
			id = Convert.ToInt32(s[0]);
			description = s[1];
			isActive = s[2] == "0" ? false : true;
			groupName = s[3];
			if (s.Length > 4)
				setWorkDetails(s);
		}

		private void setWorkDetails(string[] taskDetailsLine)
		{
			for (int i = 4; i < taskDetailsLine.Length; i++)
			{
				this.workDetails.Add(new WorkDetailsItem() { description = taskDetailsLine[i] });
			}
		}

		public string toString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(id); sb.Append(";");
			sb.Append(description); sb.Append(";");
			sb.Append(isActive ? "1" : "0"); sb.Append(";");
			sb.Append(groupName);
			sb.Append(getWorkDetails());
			return sb.ToString();
		}

		private string getWorkDetails()
		{
			if (this.workDetails.Count == 0)
				return "";
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < this.workDetails.Count; i++)
			{
				sb.Append(";"); sb.Append(this.workDetails[i].description);
			}
			return sb.ToString();
		}

		public bool Equals(TaskDefinitionItem other)
		{
			return this.description == other.description && this.groupName == other.groupName;
		}

		/// <summary>
		/// dodaje nowy wpis szczegółów do listy istniejących; jeżeli taki wpis już istnieje, nie dodaje
		/// </summary>
		internal bool addWorkDetails(string text)
		{
			for (int i = 0; i < workDetails.Count; i++)
			{
				if (workDetails[i].description.ToLower().Trim() == text.ToLower().Trim())	//taki opis już jest, nic nie robię
					return false;
			}
			WorkDetailsItem item = new WorkDetailsItem() { description = text };
			workDetails.Add(item);
			return true;
		}

		/// <summary>
		/// usuwa wpis szczegółów z listy istniejących
		/// </summary>
		internal bool removeWorkDetails(string text)
		{
			if (String.IsNullOrEmpty(text))
				return false;
			for (int i = 0; i < workDetails.Count; i++)
			{
				if (workDetails[i].description.ToLower().Trim() == text.ToLower().Trim())
				{
					workDetails.Remove(workDetails[i]);
					return true;
				}
			}
			return false;
		}
	}
}
