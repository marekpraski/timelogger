using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TimeLogger
{
    public class TaskGroupManager
    {
		private readonly string groupsFileName = "timeLoggerGroups.txt";
		/// <summary>
		/// lista grup czytana z pliku txt i tworzona podczas tworzenia obiektu TaskGroupManager
		/// </summary>
		public List<string> activeGroupsNames { get; } = new List<string>();
		public List<Group> groups { get; } = new List<Group>();

		public TaskGroupManager()
		{
			readGroups();
			getGroupNames();
		}

		private void getGroupNames()
		{
			for (int i = 0; i < groups.Count; i++)
			{
				if (groups[i].isActive)
					activeGroupsNames.Add(groups[i].name);
			}
		}

		private void readGroups()
		{
			if (!File.Exists(groupsFileName))
				return;
			string[] lines = File.ReadAllLines(groupsFileName);

			for (int i = 0; i < lines.Length; i++)
			{
				groups.Add(new Group(lines[i]));
			}
		}

		internal bool saveGroups(List<string> groupLines)
		{
			try
			{
				File.WriteAllLines(groupsFileName, groupLines);
				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
				return false;				
			}
		}

		internal bool isTaskGroupActive(TaskDefinitionItem item)
		{
			if (this.activeGroupsNames.Contains(item.groupName))
				return true;
			return false;
		}
	}
}
