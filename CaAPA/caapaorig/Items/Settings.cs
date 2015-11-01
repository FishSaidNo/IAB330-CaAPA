using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace caapaorig.Items
{

    public class Settings
    {


     

        [JsonProperty(PropertyName = "SettingsId")]
        public int SettingsId { get; set; }

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }

        public Settings()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CaaPa.Settings"/> class.
        /// </summary>
        /// <param name="SettingsId">=SettingsId .</param>

        public Settings(int SettingsId)
        {
            this.SettingsId = SettingsId;

        }


        public class SettingsWrapper : Java.Lang.Object
        {

            /// <summary>
            /// Initializes a new instance of the <see cref="CaaPa.Settings"/> class.
            /// </summary>
            /// <param name="SettingsId">=SettingsId .</param>
            public SettingsWrapper(Settings settings)
            {
                Settings = settings;
            }
            public Settings Settings { get; private set; }
        }
    }
}
