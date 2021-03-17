using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace TakiFront
{
    public class JsonClassServAskLastFlag : JsonClass
    {
        protected override byte _id { get { return Global.SRV_LAST_IN_HAND_FLAG; } }

        public int status { get; set; }

        public JsonClassServAskLastFlag()
        {
            status = 1;
        }
        public JsonClassServAskLastFlag(string json)
        {
            copyOther(JsonConvert.DeserializeObject<JsonClassServAskLastFlag>(json));
        }

        public void copyOther(JsonClassServAskLastFlag other)
        {
            this.status = other.status;
        }
        public override string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
