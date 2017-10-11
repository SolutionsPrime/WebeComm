using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace reqres
{
    public class UsersList
    {
        [JsonProperty("page")]
        public int page { get; set; }
        [JsonProperty("per_page")]
        public int per_page { get; set; }
        [JsonProperty("total")]
        public int total { get; set; }
        [JsonProperty("total_pages")]
        public int total_pages { get; set; }
        [JsonProperty("data")]
        public List<UserDetails> data { get; set; }       
    }
    public class UserDetails
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("first_name")]
        public string first_name { get; set; }
        [JsonProperty("last_name")]
        public string last_name { get; set; }
        [JsonProperty("avatar")]
        public string avatar { get; set; }
    }

    public class RegisterDetails
    {
        [JsonProperty("email")]
        public string email { get; set; }
        [JsonProperty("password")]
        public string password { get; set; }        
    }

    public class JobDetails
    {
        public string name { get; set; }
        public string job { get; set; }
    }

    public class UserRecord
    {
        [JsonProperty("data")]
        public UserDetails data { get; set; }        
    }

   
}
