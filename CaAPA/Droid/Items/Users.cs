﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace caapa { 
    public class Users
    {
      

        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }
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

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }

        public class UsersWrapper : Java.Lang.Object
        {

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
            public UsersWrapper(Users user)
            {
                Users = user;
            }
            public Users Users{ get; private set; }
        }

    }
}