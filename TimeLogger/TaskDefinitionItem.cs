using System;
using System.Text;

namespace TimeLogger
{
    public class TaskDefinitionItem
    {
		public int id = 0;
		public string description { get; set; }
		public string groupName { get; set; }
		public bool isActive { get; set; }
		public string sortCriterion { get => groupName + description; }

		public TaskDefinitionItem()
		{
			
		}

		public TaskDefinitionItem(string taskDictItemAsString)
		{
			string[] s = taskDictItemAsString.Split(';');
			id = Convert.ToInt32(s[0]);
			description = s[1];
			isActive = s[2] == "0" ? false : true;
			groupName = s[3];
		}

		public string toString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(id); sb.Append(";");
			sb.Append(description); sb.Append(";");
			sb.Append(isActive ? "1" : "0"); sb.Append(";");
			sb.Append(groupName);
			return sb.ToString();
		}
	}
}
