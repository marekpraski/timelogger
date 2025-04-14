using System;
using System.Diagnostics.Eventing.Reader;
using System.Text;

namespace TimeLogger
{
    public class TaskLogItem
    {
		public static string csvHeaderFull = "id;description;date;startTime;endTime;groupName;details;timeInMinutes";
		public static string csvHeaderAggregate = "id;date;groupName;description;timeHourMinutes;timeInMinutes;details";
		public int id  = 0;
        public string description { get; set; }
		public string workDetails { get; set; }
        public string groupName { get; set; }
		/// <summary>
		/// data w formacie rrrr-mm-dd ustawiana w konstruktorze z DateTime.Now
		/// </summary>
		public string date { get; private set; }
		/// <summary>
		/// data w formacie rrrr-mm  ustawiana w konstruktorze z DateTime.Now
		/// </summary>
		public string yearMonth { get => getYearMonth(); }

		/// <summary>
		/// wykorzystuję w statystykach, nie może być dynamicznie aktualizowana w czasie życia obiektu
		/// </summary>
		private int timeInMinutes = 0;

		/// <summary>
		/// czas zadania w minutach obliczany z różnicy czasu końcowego i czasu początkowego
		/// </summary>
		public int taskDurationInMinutes { get => getTimeInMinutes(); }

		/// <summary>
		/// czas zadania w formacie hh:mm
		/// </summary>
		public string taskDurationInHoursMinutes { get => getHoursMinutes(); }
		public string startTime { get => extractTime(startDateTime) ; }
		public string endTime { get => extractTime(endDateTime); }

		private DateTime startDateTime = DateTime.Now;
        private DateTime endDateTime = DateTime.Now;

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

		/// <summary>
		/// "id;description;date;startTime;endTime;groupName;details;timeInMinutes"
		/// </summary>
		public string toStringDetailed()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(id); sb.Append(";");
            sb.Append(description); sb.Append(";");
            sb.Append(date); sb.Append(";");
            sb.Append(startDateTime.ToString()); sb.Append(";");
            sb.Append(endDateTime.ToString()); sb.Append(";");
			sb.Append(groupName); sb.Append(";");
			sb.Append(workDetails); sb.Append(";");
			sb.Append(timeInMinutes);
			return sb.ToString();
        }

		/// <summary>
		/// "id;date;groupName;description;timeHourMinutes;timeInMinutes;details"
		/// </summary>
		public string toStringAggregated(LogType logType)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(id); sb.Append(";");
			appendDate(sb, logType);			
			sb.Append(groupName); sb.Append(";");
			sb.Append(description); sb.Append(";");
			sb.Append(getHoursMinutes()); sb.Append(";");
			sb.Append(timeInMinutes); sb.Append(";");
			sb.Append(workDetails);
			return sb.ToString();
		}

		private void appendDate(StringBuilder sb, LogType logType)
		{
			if (logType == LogType.AggregatedDaily)
			{
				sb.Append(date); 
				sb.Append(";");
			}
			if (logType == LogType.AggregatedMonthly)
			{
				sb.Append(yearMonth); 
				sb.Append(";");
			}
		}

		/// <summary>
		/// czyści opis zadania oraz timeInMinutes, bo gdy klonuję kopiują się też te właściwości i
		/// podczas agregacji uzyskuję powtórzenie czasu i opisu zadania dla pierwszego wpisu;
		/// </summary>
		internal void clearTimeInMinutesAndWorkDetails()
		{
			this.workDetails = "";
			this.timeInMinutes = 0;
		}

		internal TaskLogItem clone()
		{
			return new TaskLogItem(this.toStringDetailed());
		}

		internal void aggregate(TaskLogItem other)
		{
			this.timeInMinutes += other.timeInMinutes;
			if (!String.IsNullOrEmpty(other.workDetails))
				this.workDetails += addLineBreak() + other.workDetails;
		}

		private string addLineBreak()
		{
			if (String.IsNullOrEmpty(this.workDetails))
				return "";

			return " , ";
		}

		internal void setWorkDetails(string text)
		{
			this.workDetails = text;
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
			this.timeInMinutes = getTimeInMinutes();
		}

		private int getTimeInMinutes()
		{
			return Convert.ToInt32(endDateTime.Subtract(startDateTime).TotalMinutes);
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

		private string getYearMonth()
		{
			return this.date.Substring(0, 7);
		}

		private string getDoubleDigit(int number)
		{
			if (number < 10)
				return "0" + number.ToString();
			return number.ToString();
		}
	}
}
