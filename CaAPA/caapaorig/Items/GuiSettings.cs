using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace caapaorig.Items
{
    public class GuiSettings
    {

        [JsonProperty(PropertyName = "GuiSettingsId")]
        public int GuiSettingsId { get; set; }
        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }

        public class GuiSettingsWrapper : Java.Lang.Object
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CaaPa.GuiSettings"/> class.
            /// </summary>
            /// <param name="GuiSettingsId">GuiSettingsId .</param>
            public GuiSettingsWrapper(GuiSettings guisettings)
            {
                GuiSettings = guisettings;
            }
            public GuiSettings GuiSettings { get; private set; }
        }
    }
}

