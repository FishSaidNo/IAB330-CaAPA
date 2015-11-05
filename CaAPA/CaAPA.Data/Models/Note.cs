using System;

namespace CaAPA.Data
{
	public class Note
	{
		public string titleText { get; set; }
		public string TimeStamp { get; set; }
		public string NoteDetail { get; set; }
		public string ActionRequiredFlag { get; set; }

		public Note(){
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="CaAPA.Notes"/> class.
		/// </summary>
		/// <param name="titleText">Title text.</param>
		/// <param name="timeStamp">Time stamp.</param>
		/// <param name="actionRequiredFlag">Action required flag.</param>
		public Note (string titleText, string timeStamp = "", string actionRequiredFlag = "", string noteDetail = "")
		{
			this.titleText = titleText;
			TimeStamp = timeStamp;
			ActionRequiredFlag = actionRequiredFlag;
			NoteDetail = noteDetail;
		}
	}
}

