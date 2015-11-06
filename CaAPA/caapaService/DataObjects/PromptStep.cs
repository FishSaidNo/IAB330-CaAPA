using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service;
using Newtonsoft.Json;

namespace caapaService.DataObjects
{
    public class PromptStep: EntityData
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


        public PromptStep()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CaaPa.PromptStep"/> class.
        /// </summary>
        /// <param name="stepId">stepId .</param>
        /// <param name="promptId">promptId .</param>
        /// <param name="stepName">stepName .</param>
        /// <param name="steDesc">steDesc .</param>
        /// <param name="stepImageURI">stepImageURI .</param>
        /// <param name="stepMediaURI">userMediaURI .</param>
        public PromptStep(int stepId, int promptId, String stepName = "", String stepDesc = "", 
            String stepImageURI = "", String stepMediaURI = "") {

            this.stepId = stepId;
            this.promptId = promptId;
            this.stepName = stepName;
            this.stepDesc = stepDesc;
            this.stepImageURI = stepImageURI;
            this.stepMediaURI = stepMediaURI;
        }
     
    }
}
