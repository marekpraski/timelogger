
using System;

namespace TimeLogger
{
    public class Group
    {
        public string name { get; set; }
		public string oldName { get; }
        public bool isActive { get; set; } = true;
		public bool isNew { get; } = false;

		/// <summary>
		/// parametrem jest wiersz przeczytany z pliku timeLoggerGroups.txt
		/// </summary>
		public Group(string groupEntryLine)
		{
			string[] pars = groupEntryLine.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
			this.name = pars[0];
			this.isActive = stringToBool(pars[1]);
			this.oldName = name;
		}

		/// <summary>
		/// konstruktor wykorzystywany podczas dodawania nowych grup
		/// </summary>
		public Group()
		{
			this.name = "";
			this.isActive = true;
			this.isNew = true;
		}

		public string toString()
		{
			return this.name + ";" + boolToString(this.isActive);
		}

		private bool stringToBool(string boolAsString)
		{
			if (boolAsString == "1")
				return true;
			return false;
		}
		private string boolToString(bool isActive)
		{
			if (isActive)
				return "1";
			return "0";
		}
	}
}
