using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TakiFront
{
    public class SignupRequest : JsonClass
    {
        protected override byte _id { get { return Global.SIGN_UP_REQUEST; } }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        public SignupRequest()
        {

        }

        public SignupRequest(SignupRequest other) : this(other.username, other.password, other.email)
        {
        }

        public SignupRequest(string user, string pass, string em)
        {
            username = user;
            password = pass;
            email = em;
        }

        public SignupRequest(string json) : this(JsonConvert.DeserializeObject<SignupRequest>(json))
        {
        }

        public override string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
