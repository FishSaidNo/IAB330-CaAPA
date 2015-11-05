using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace caapa
{ 

    public class Settings
    {

        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }

        public Settings()
        {

        }

        public class SettingsWrapper : Java.Lang.Object
        {

            /// <summary>
            /// Initializes a new instance of the <see cref="CaaPa.Settings"/> class.
            /// </summary>
            public SettingsWrapper(Settings settings)
            {
                Settings = settings;
            }
            public Settings Settings { get; private set; }
        }
    }
}
