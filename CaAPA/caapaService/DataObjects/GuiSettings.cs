using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service;
using Newtonsoft.Json;

namespace caapaService.DataObjects
{
    public class GuiSettings: EntityData
    {
        [JsonProperty(PropertyName = "GuiSettingsId")]
        public int GuiSettingsId { get; set; }


        public GuiSettings()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CaaPa.GuiSettings"/> class.
        /// </summary>
        /// <param name="GuiSettingsId">GuiSettingsId .</param>
        public GuiSettings(int GuiSettingsId)
        {
            this.GuiSettingsId = GuiSettingsId;
        }
    }
}

