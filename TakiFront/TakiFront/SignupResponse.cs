using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakiFront
{
    public class SignupResponse : JsonClass
    {
        protected override byte _id { get { return Global.SIGN_UP_RESPONSE; } }
        public uint status { get; set; }

        public SignupResponse()
        {
            status = 0;
        }

        public SignupResponse(SignupResponse other)
        {
            this.status = other.status;
        }

        public SignupResponse(string json) : this(JsonConvert.DeserializeObject<SignupResponse>(json))
        {
        }

        public override string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
