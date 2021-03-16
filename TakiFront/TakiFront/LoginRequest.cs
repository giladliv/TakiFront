using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakiFront
{
    public class LoginRequest : JsonClass
    {
        protected override byte _id { get { return Global.LOGIN_REQUEST; } }
        public string username { get; set; }
        public string password { get; set; }

        public LoginRequest()
        {

        }

        public LoginRequest(LoginRequest other) : this(other.username, other.password)
        {
        }

        public LoginRequest(string user, string pass)
        {
            username = user;
            password = pass;
        }

        public LoginRequest(string json) : this(JsonConvert.DeserializeObject<LoginRequest>(json))
        {
        }

        public override string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
