using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TimeLogger
{
    public class TaskDefinitionsManager
    {
		private string dictFileName = "timeLoggerDefinitions.txt";
		/// <summary>
		/// zawiera definicje wszystkich zadań z wszystkich grup
		/// </summary>
		public List<TaskDefinitionItem> taskDefinitionsAll { get; }
		/// <summary>
		/// zawiera definicje wszystkich zadań wszystkich aktywnych grup
		/// </summary>
		public List<TaskDefinitionItem> taskDefinitionsActiveGroups { get; }
		private TaskGroupManager groupManager = new TaskGroupManager();

		public TaskDefinitionsManager()
		{
			taskDefinitionsAll = new List<TaskDefinitionItem>();
			taskDefinitionsActiveGroups = new List<TaskDefinitionItem>();
			readTaskDictionary();
		}

		internal void addItem(TaskDefinitionItem item)
		{
			taskDefinitionsAll.Add(item);
			if (groupManager.isTaskGroupActive(item))
				taskDefinitionsActiveGroups.Add(item);
			saveDictionary();
		}

		/// <summary>
		/// zamienia istniejący obiekt TaskDefinitionItem na liście definicji na przekazany w parametrze;
		/// ideą jest, że przekazany obiekt ma inne wpisy WorkDetails niż istniejący
		/// </summary>
		internal void modifyItem(TaskDefinitionItem item)
		{
			for (int i = 0; i < taskDefinitionsAll.Count; i++)
			{
				if (taskDefinitionsAll[i].Equals(item))
					taskDefinitionsAll[i] = item;
			}
			saveDictionary();
		}

		internal void removeItem(TaskDefinitionItem item)
		{
			taskDefinitionsAll.Remove(item);
			if (groupManager.isTaskGroupActive(item))
				taskDefinitionsActiveGroups.Remove(item);
			saveDictionary();
		}

		internal void saveDictionary()
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < taskDefinitionsAll.Count; i++)
			{
				sb.AppendLine(taskDefinitionsAll[i].toString());
			}
			File.WriteAllText(dictFileName, sb.ToString());
		}

		internal List<WorkDetailsItem> getWorkDetails(TaskDefinitionItem taskLogItem)
		{
			for (int i = 0; i < taskDefinitionsAll.Count; i++)
			{
				if (taskDefinitionsAll[i].Equals(taskLogItem))
					return taskDefinitionsAll[i].workDetails;
			}
			return null;
		}

		internal List<TaskDefinitionItem> getGroupTasks(string groupName)
		{
			List<TaskDefinitionItem> l = new List<TaskDefinitionItem>();
			for (int i = 0; i < this.taskDefinitionsActiveGroups.Count; i++)
			{
				if (this.taskDefinitionsActiveGroups[i].groupName == groupName)
					l.Add(this.taskDefinitionsActiveGroups[i]);
			}
			return l;
		}

		private void readTaskDictionary()
		{
			if (!File.Exists(dictFileName))
				return;
			string[] dict = File.ReadAllLines(dictFileName);

			for (int i = 0; i < dict.Length; i++)
			{
				TaskDefinitionItem item = new TaskDefinitionItem(dict[i]);
				taskDefinitionsAll.Add(item);
				if (groupManager.isTaskGroupActive(item))
					taskDefinitionsActiveGroups.Add(item);
			}
			taskDefinitionsAll.Sort((x, y) => x.sortCriterion.CompareTo(y.sortCriterion));
			taskDefinitionsActiveGroups.Sort((x, y) => x.sortCriterion.CompareTo(y.sortCriterion));
		}

	}
}
