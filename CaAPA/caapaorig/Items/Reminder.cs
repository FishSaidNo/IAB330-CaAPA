using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace caapaorig.Items
{
    public class Reminder
    {
       
        [JsonProperty(PropertyName = "ReminderId")]
        public int ReminderId { get; set; }
        [JsonProperty(PropertyName = "UserId")]
        public int UserId { get; set; }
        [JsonProperty(PropertyName = "ReminderName")]
        public String ReminderName { get; set; }
        [JsonProperty(PropertyName = "ReminderDesc")]
        public String ReminderDesc { get; set; }
        [JsonProperty(PropertyName = "DurationStartDateTime")]
        public DateTime DurationStartDatetime { get; set; }
        [JsonProperty(PropertyName = "DurationStartEndTime")]
        public DateTime DurationEndDatetime { get; set; }
        [JsonProperty(PropertyName = "ImageURI")]
        public String ImageURI { get; set; }
        [JsonProperty(PropertyName = "MediaURI")]
        public String MediaURI { get; set; }

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }

        public class ReminderWrapper : Java.Lang.Object
        {

            /// <summary>
            /// Initializes a new instance of the <see cref="CaaPa.Reminder"/> class.
            /// </summary>
            /// <param name="ReminderId">ReminderId .</param>
            /// <param name="UserId">UserId .</param>
            /// <param name="ReminderName">ReminderName .</param>
            /// <param name="ReminderDesc">ReminderDesc .</param>
            /// <param name="DurationStartDatetime">DurationStartDatetime .</param>
            /// <param name="DurationEndDatetime">DurationEndDatetime .</param>
            /// <param name="ImageURI">ImageURI .</param>
            /// <param name="MediaURI">MediaURI .</param>
            public ReminderWrapper(Reminder reminder)
            {
                Reminder = reminder;
            }
            public Reminder Reminder { get; private set; }
        }
    }
}
