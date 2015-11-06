using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace caapa
{
    public class Prompt
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }
        [JsonProperty(PropertyName = "promptName")]
        public String promptName { get; set; }
        [JsonProperty(PropertyName = "promptDesc")]
        public String promptDesc { get; set; }
        [JsonProperty(PropertyName = "userId")]
        public int userId { get; set; }

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }

        public class PromptWrapper
        {

            /// <summary>
            /// Initializes a new instance of the <see cref="CaaPa.Prompt"/> class.
            /// </summary>
            /// <param name="promptName">promptName .</param>
            /// <param name="promptDesc">promptDesc .</param>
            /// <param name="userId">userId .</param>
            public PromptWrapper(Prompt prompt)
            {
                Prompt = prompt;
            }
            public Prompt Prompt { get; set; }
        }

    }
}
