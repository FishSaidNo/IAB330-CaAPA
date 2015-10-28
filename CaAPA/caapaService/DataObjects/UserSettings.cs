using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service;
using Newtonsoft.Json;


namespace caapaService.DataObjects
{
    public class UserSettings: EntityData
    {
        [JsonProperty(PropertyName = "UserSettingsId")]
        public int UserSettingsId { get; set; }
        [JsonProperty(PropertyName = "UserId")]
        public int UserId { get; set; }
        [JsonProperty(PropertyName = "GuiSettingsId")]
        public int GuiSettingsId { get; set; }
        [JsonProperty(PropertyName = "UISettingsIdJSON")]
        public String UISettingsJSON { get; set; }

        public UserSettings() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CaaPa.UserSettings"/> class.
        /// </summary>
        /// <param name="UserSettingsId ">serSettingsId .</param>
        /// <param name="UserId ">UserId .</param>
        /// /// <param name="GuiSettingsId ">GuiSettingsId .</param>
        /// /// <param name="UiSEttingsJSON ">UiSEttingsJSON  .</param>

        public UserSettings(int UserSettingsId, int UserId, int GuiSettingsId, String UISEttingsJSON = "")
        { 

            this.UserSettingsId = UserSettingsId;
            this.UserId = UserId;
            this.GuiSettingsId = GuiSettingsId;
            this.UISettingsJSON = UISEttingsJSON;
        }



    }
}
