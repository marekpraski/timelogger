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

		internal void saveTaskLogs(LogType logType, Dictionary<string, List<TaskLogItem>> taskLogs)
		{
			Thread t = new Thread(() => saveFileAsynch(getLogFileName(logType), getCsvFileHeader(logType), taskLogs));
			t.Start();
		}

		private void saveFileAsynch(string logFileName, string csvFileHeader, Dictionary<string, List<TaskLogItem>> taskLogs)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(csvFileHeader);

			foreach (string date in taskLogs.Keys)
			{
				List<TaskLogItem> l = taskLogs[date];
				for (int i = 0; i < l.Count; i++)
				{
					sb.AppendLine(l[i].toStringAggregated());
				}
			}
			File.WriteAllText(logFileName, sb.ToString());
		}

		private string getCsvFileHeader(LogType logType)
		{
			if (logType == LogType.Detailed)
				return TaskLogItem.csvHeaderFull;
			else
				return TaskLogItem.csvHeaderAggregate;
		}

		private string getLogFileName(LogType logType)
		{
			if (logType == LogType.Detailed)
				return this.tasksFileName;
			if (logType == LogType.AggregatedDaily)
				return "taskLoggerDailyAggregates.csv";
			else
				return "taskLoggerMonthlyAggregates.csv";
		}

	}
}
