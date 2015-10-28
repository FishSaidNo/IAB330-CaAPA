using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service;
using Newtonsoft.Json;

namespace caapaService.DataObjects
{
    public class Prompt: EntityData
    {
        [JsonProperty(PropertyName = "promptId")]
        public int promptId { get; set; }
        [JsonProperty(PropertyName = "promptName")]
        public String promptName { get; set; }
        [JsonProperty(PropertyName = "promptDesc")]
        public String promptDesc { get; set; }
        [JsonProperty(PropertyName = "userId")]
        public int userId { get; set; }
        

        public Prompt()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CaaPa.Prompt"/> class.
        /// </summary>
        /// <param name="promptName">promptName .</param>
        /// <param name="promptDesc">promptDesc .</param>
        /// <param name="userId">userId .</param>
        public Prompt(int promptId, int userID, String promptName = "", String promptDesc = "")
        {
            this.promptId = promptId;
            this.promptName = promptName;
            this.promptDesc = promptDesc;
            this.userId = userId;
        }
    }
}
