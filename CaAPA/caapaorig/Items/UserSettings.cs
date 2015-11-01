using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace caapaorig.Items
{
    public class UserSettings
    {

        [JsonProperty(PropertyName = "UserSettingsId")]
        public int UserSettingsId { get; set; }
        [JsonProperty(PropertyName = "UserId")]
        public int UserId { get; set; }
        [JsonProperty(PropertyName = "GuiSettingsId")]
        public int GuiSettingsId { get; set; }
        [JsonProperty(PropertyName = "UISettingsIdJSON")]
        public String UISettingsJSON { get; set; }

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }

        public class UserSettingsWrapper : Java.Lang.Object
        {

            /// <summary>
            /// Initializes a new instance of the <see cref="CaaPa.UserSettings"/> class.
            /// </summary>
            /// <param name="UserSettingsId ">serSettingsId .</param>
            /// <param name="UserId ">UserId .</param>
            /// /// <param name="GuiSettingsId ">GuiSettingsId .</param>
            /// /// <param name="UiSEttingsJSON ">UiSEttingsJSON  .</param>
            public UserSettingsWrapper(UserSettings usersetting)
            {
                UserSettings = usersetting;
            }

            public UserSettings UserSettings { get; private set; }
        }



    }
}
