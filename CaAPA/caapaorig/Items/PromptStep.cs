using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace caapaorig.Items
{
    public class PromptStep
    {

        [JsonProperty(PropertyName = "stepId")]
        public int stepId { get; set; }
        [JsonProperty(PropertyName = "promptId")]
        public int promptId { get; set; }
        [JsonProperty(PropertyName = "stepName")]
        public String stepName { get; set; }
        [JsonProperty(PropertyName = "stepDesc")]
        public String stepDesc { get; set; }
        [JsonProperty(PropertyName = "stepImageURI")]
        public String stepImageURI{ get; set; }
        [JsonProperty(PropertyName = "stepMediaURI")]
        public String stepMediaURI { get; set; }


        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }
        public class PromptStepWrapper : Java.Lang.Object
        {

            /// <summary>
            /// Initializes a new instance of the <see cref="CaaPa.PromptStep"/> class.
            /// </summary>
            /// <param name="stepId">stepId .</param>
            /// <param name="promptId">promptId .</param>
            /// <param name="stepName">stepName .</param>
            /// <param name="steDesc">steDesc .</param>
            /// <param name="stepImageURI">stepImageURI .</param>
            /// <param name="stepMediaURI">userMediaURI .</param>
            public PromptStepWrapper(PromptStep promptstep)
            {
                PromptStep = promptstep;
            }
            public PromptStep PromptStep { get; private set; }
        }

    }
}
