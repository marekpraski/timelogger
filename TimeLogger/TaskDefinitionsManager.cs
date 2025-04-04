using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace TimeLogger
{
    public class TaskDefinitionsManager
    {
		private string dictFileName = "timeLoggerDefinitions.txt";
		public List<TaskDefinitionItem> taskDefinitions { get; }

		public TaskDefinitionsManager()
		{
			taskDefinitions = new List<TaskDefinitionItem>();
			readTaskDictionary();
		}

		internal void addItem(TaskDefinitionItem item)
		{
			taskDefinitions.Add(item);
			saveDictionary();
		}

		internal void removeItem(TaskDefinitionItem item)
		{
			taskDefinitions.Remove(item);
			saveDictionary();
		}

		internal void saveDictionary()
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < taskDefinitions.Count; i++)
			{
				sb.AppendLine(taskDefinitions[i].toString());
			}
			File.WriteAllText(dictFileName, sb.ToString());
		}

		private void readTaskDictionary()
		{
			if (!File.Exists(dictFileName))
				return;
			string[] dict = File.ReadAllLines(dictFileName);

			for (int i = 0; i < dict.Length; i++)
			{
				taskDefinitions.Add(new TaskDefinitionItem(dict[i]));
			}
			taskDefinitions.Sort((x, y) => x.sortCriterion.CompareTo(y.sortCriterion));
		}
	}
}
