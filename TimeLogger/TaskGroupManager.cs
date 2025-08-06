using System;
using System.Collections.Generic;
using System.IO;

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
			this.activeGroupsNames.Sort();
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

		internal void saveGroups(List<string> groupLines)
		{
			File.WriteAllLines(groupsFileName, groupLines);
		}

		internal bool isTaskGroupActive(TaskDefinitionItem item)
		{
			if (this.activeGroupsNames.Contains(item.groupName))
				return true;
			return false;
		}

		internal void renameGroups(List<Group> renamed)
		{
			if (renamed.Count == 0)
				return;
			
			TaskDefinitionsManager tdm = new TaskDefinitionsManager();
			for (int i = 0; i < renamed.Count; i++)
			{
				List<TaskDefinitionItem> defs = tdm.getGroupTasks(renamed[i].name);
				for (int k = 0; k < defs.Count; k++)
				{
					defs[k].groupName = renamed[i].name;
				}
			}
			tdm.saveTaskDefinitions();
		}
	}
}
