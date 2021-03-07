using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace TakiFront
{
    class JsonClassServAskLastFlag : JsonClass
    {
        protected override byte _id { get { return Global.SRV_LAST_IN_HAND_FLAG; } }

        public bool called { get; set; }

        public JsonClassServAskLastFlag(string json)
        {
            copyOther(JsonConvert.DeserializeObject<JsonClassServAskLastFlag>(json));
        }

        public void copyOther(JsonClassServAskLastFlag other)
        {
            this.called = other.called;
        }
        public override string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
