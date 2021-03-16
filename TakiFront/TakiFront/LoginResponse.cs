using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakiFront
{
    public class LoginResponse : JsonClass
    {
        protected override byte _id { get { return Global.SIGN_UP_RESPONSE; } }
        public uint status { get; set; }

        public LoginResponse()
        {
            status = 0;
        }

        public LoginResponse(LoginResponse other)
        {
            this.status = other.status;
        }

        public LoginResponse(string json) : this(JsonConvert.DeserializeObject<LoginResponse>(json))
        {

        }

        public override string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
