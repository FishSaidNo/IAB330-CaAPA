using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service;
using Newtonsoft.Json;

namespace caapaService.DataObjects
{
    public class Users: EntityData
    {
        [JsonProperty(PropertyName = "UserId")]
        public int UserId { get; set; }
        [JsonProperty(PropertyName = "UserName")]
        public String UserName { get; set; }
        [JsonProperty(PropertyName = "UserFirstName")]
        public String UserFirstName { get; set; }
        [JsonProperty(PropertyName = "UserLastName")]
        public String UserLastName { get; set; }
        [JsonProperty(PropertyName = "eMail")]
        public String eMail { get; set; }
        [JsonProperty(PropertyName = "Home")]
        public String Home { get; set; }
        [JsonProperty(PropertyName = "Mobile")]
        public String Mobile { get; set; }
        [JsonProperty(PropertyName = "DeviceMACDongle")]
        public String DeviceMACDongle { get; set; }

        public Users()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CaaPa.Users"/> class.
        /// </summary>
        /// <param name="UserId ">UserId .</param>
        /// <param name="UserName  ">UserName  .</param>
        /// <param name="UserFirstName  ">UserFirstName  .</param>
        /// <param name="UserLastName ">UserLastName .</param>
        /// <param name="Home">eMail .</param>
        /// <param name="Home">Home .</param>
        /// <param name="Mobile">Mobile .</param>
        /// <param name="DeviceMACDongle">DeviceMACDongle .</param>
        public Users(int UserId, String UserName = "", String UserFirstName = "", String UserLastName = "", 
            String eMail = "", String Home = "", String Mobile = "", String DeviceMACDongle = "")
        {
            this.UserId = UserId;
            this.UserName = UserName;
            this.UserFirstName = UserFirstName;
            this.UserLastName = UserLastName;
            this.eMail = eMail;
            this.Home = Home;
            this.Mobile = Mobile;
            this.DeviceMACDongle = DeviceMACDongle;

        }

    }
}