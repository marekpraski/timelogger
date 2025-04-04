using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;

namespace TimeLogger
{
    public class TaskLogManager
    {
		private string tasksFileName = "taskLoggerLog.csv";

		internal Dictionary<string, List<TaskLogItem>> readTasks()
		{
			Dictionary<string, List<TaskLogItem>> taskLogs = new Dictionary<string, List<TaskLogItem>>();
			if (!File.Exists(tasksFileName))
				return null;
			string[] s = File.ReadAllLines(tasksFileName);
			for (int i = 1; i < s.Length; i++)	//pierwszy wiersz zawiera nagłówek
			{
				TaskLogItem item = new TaskLogItem(s[i]);
				if (taskLogs.ContainsKey(item.date))
					taskLogs[item.date].Add(item);
				else
				{
					List<TaskLogItem> l = new List<TaskLogItem>();
					l.Add(item);
					taskLogs.Add(item.date, l);
				}
			}
			return taskLogs;
		}

		internal void saveTasks(Dictionary<string, List<TaskLogItem>> taskLogs)
		{
			Thread t = new Thread(() => saveTasksAsynch(taskLogs));
			t.Start();
		}

		private void saveTasksAsynch(Dictionary<string, List<TaskLogItem>> taskLogs)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(TaskLogItem.csvHeader);
			
			foreach (string date in taskLogs.Keys)
			{
				List<TaskLogItem> l = taskLogs[date];
				for (int i = 0; i < l.Count; i++)
				{
					sb.AppendLine(l[i].toString());
				}
			}
			File.WriteAllText(tasksFileName, sb.ToString());
		}

	}
}
