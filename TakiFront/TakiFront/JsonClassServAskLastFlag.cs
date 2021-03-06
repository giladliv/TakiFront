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
