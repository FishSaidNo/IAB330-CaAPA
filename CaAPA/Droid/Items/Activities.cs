using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.MobileServices.Query;



namespace caapa
{
    public class Activities 
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }
        [JsonProperty(PropertyName = "ActivityName")]
        public String ActivityName { get; set; }
        [JsonProperty(PropertyName = "ActivityLocation")]
        public String ActivityLocation { get; set; }
        [JsonProperty(PropertyName = "NumbeOfSteps")]
        public int NumberOfSteps { get; set; }

        [JsonProperty(PropertyName = "Complete")]
        public bool Complete { get; set; }

        public class ActivitiesWrapper
        {

            /// <summary>
            /// Initializes a new instance of the <see cref="CaaPa.Activities"/> class.
            /// </summary>
            /// <param name="promptName">promptName .</param>
            /// <param name="promptDesc">promptDesc .</param>
            /// <param name="userId">userId .</param>
            public ActivitiesWrapper(Activities activities)
            {
                Activities = activities;
            }
            public Activities Activities { get; set; }
        }

    }
}
