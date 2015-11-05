using System;

namespace CaAPA.Data
{
	class Reminder
	{
		public DateTime Time { get; set; }
		public string ActivityName { get; set; }
		//activity name because that is the key in the db

		public Reminder(DateTime time, string activityname)
		{
			Time = time;
			ActivityName = activityname;
		}
	}
}