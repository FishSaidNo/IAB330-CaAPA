using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service;
using Newtonsoft.Json;

namespace caapaService.DataObjects
{
    public class Reminder: EntityData
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

        public Reminder() {

        }

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
        public Reminder(int ReminderId, int UserId, DateTime DurationStartDatetime, DateTime DurationEndDatetime, 
            String ReminderName = "", String ReminderDesc = "", String ImageURI = "", String MediaURI = "")
        {
            this.ReminderId = ReminderId;
            this.UserId = UserId;
            this.ReminderName = ReminderName;
            this.ReminderDesc = ReminderDesc;
            this.DurationStartDatetime = DurationStartDatetime;
            this.DurationEndDatetime = DurationEndDatetime;
            this.ImageURI = ImageURI;
            this.MediaURI = MediaURI;

        }
    }
}
