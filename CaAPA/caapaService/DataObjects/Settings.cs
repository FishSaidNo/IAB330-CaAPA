using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service;
using Newtonsoft.Json;

namespace caapaService.DataObjects
{

    public class Settings : EntityData
    {

        [JsonProperty(PropertyName = "SettingsId")]
        public int SettingsId { get; set; }

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
    }
}
