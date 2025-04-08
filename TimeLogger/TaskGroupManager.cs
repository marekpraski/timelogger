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
		public List<string> groupNames { get; }

		public TaskGroupManager()
		{
			groupNames = new List<string>();
			readGroups();
		}

		private void readGroups()
		{
			if (!File.Exists(groupsFileName))
				return;
			string s = File.ReadAllText(groupsFileName);
			string[] grs = s.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

			for (int i = 0; i < grs.Length; i++)
			{
				groupNames.Add(grs[i]);
			}
		}

		internal bool saveGroups(string groupNamesAsString)
		{
			try
			{
				File.WriteAllText(groupsFileName, groupNamesAsString);
				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
				return false;				
			}
		}
	}
}
