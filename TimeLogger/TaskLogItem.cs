using System;
using System.Text;

namespace TimeLogger
{
    public class TaskLogItem
    {
        public int id  = 0;
        public string description { get; set; }
		public string workDetails { get; set; }
        public string groupName { get; set; }
        public string date { get; private set; }

		/// <summary>
		/// wykorzystuję tylko w statystykach, więc nie musi być dynamicznie aktualizowana w czasie życia obiektu
		/// </summary>
		private int timeInMinutes = 0;

		public string timeLength { get => getHoursMinutes(); }
		public string startTime { get => extractTime(startDateTime) ; }
		public string endTime { get => extractTime(endDateTime); }

		private DateTime startDateTime = DateTime.Now;
        private DateTime endDateTime = DateTime.Now;
		public TaskLogItem()
		{
			
		}

		/// <summary>
		/// nowy na podstawie elementu słownikowego
		/// </summary>
		public TaskLogItem(TaskDefinitionItem taskDefinition)
		{
            setDate(DateTime.Now);
            this.groupName = taskDefinition.groupName;
            this.description = taskDefinition.description;
		}

		/// <summary>
		/// odczytany z pliku
		/// </summary>
		public TaskLogItem(string taskLogItemAsString)
		{
            fromString(taskLogItemAsString);
			setTimeInMinutes();
		}

		public void setEndTime(DateTime endTime)
		{
			this.endDateTime = endTime;
		}

        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(id); sb.Append(";");
            sb.Append(description); sb.Append(";");
            sb.Append(date); sb.Append(";");
            sb.Append(startDateTime.ToString()); sb.Append(";");
            sb.Append(endDateTime.ToString()); sb.Append(";");
			sb.Append(groupName); sb.Append(";");
			sb.Append(workDetails);
			return sb.ToString();
        }

		private string extractTime(DateTime dt)
		{
			int min = dt.Minute;
			int hr = dt.Hour;
			return getDoubleDigit(hr) + ":" + getDoubleDigit(min);
		}

		private void fromString(string taskLogItemAsString)
        {
            string[] s = taskLogItemAsString.Split(';');
            id = Convert.ToInt32(s[0]);
            description = s[1];
            date = s[2];
            startDateTime = DateTime.Parse(s[3]);
            endDateTime = DateTime.Parse(s[4]);
			groupName = s[5];
			workDetails = s[6];
		}

		private void setTimeInMinutes()
		{
			this.timeInMinutes = Convert.ToInt32(endDateTime.Subtract(startDateTime).TotalMinutes);
		}

		private string getHoursMinutes()
		{
			int minutesTotal;
			if (this.timeInMinutes > 0)
				minutesTotal = this.timeInMinutes;
			else
				minutesTotal = Convert.ToInt32(endDateTime.Subtract(startDateTime).TotalMinutes);
			
			int hours = minutesTotal / 60;
			if (hours == 0)
				return minutesTotal + " min";
			
			int minutes = minutesTotal - hours * 60;
			return hours + " hr  " + minutes + " min";
		}

		private void setDate(DateTime d)
		{
			this.date = d.Year + "-" + getDoubleDigit(d.Month) + "-" + getDoubleDigit(d.Day);
		}

		private string getDoubleDigit(int number)
		{
			if (number < 10)
				return "0" + number.ToString();
			return number.ToString();
		}

		internal TaskLogItem clone()
		{
			return new TaskLogItem(this.toString());
		}

		internal void combineTimes(TaskLogItem other)
		{
			this.timeInMinutes += other.timeInMinutes;
		}

		internal void setWorkDetails(string text)
		{
			this.workDetails = text; ;
		}
	}
}
