
using System;

namespace TimeLogger
{
    public class Group
    {
        public string name { get; set; }
        public bool isActive { get; set; } = true;

		/// <summary>
		/// parametrem jest wiersz przeczytany z pliku timeLoggerGroups.txt
		/// </summary>
		public Group(string groupEntryLine)
		{
			string[] pars = groupEntryLine.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
			this.name = pars[0];
			this.isActive = stringToBool(pars[1]);
		}

		private bool stringToBool(string boolAsString)
		{
			if (boolAsString == "1")
				return true;
			return false;
		}
	}
}
