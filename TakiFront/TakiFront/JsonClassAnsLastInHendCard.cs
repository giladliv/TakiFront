using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace TakiFront
{
    public class JsonClassAnsLastInHendCard : JsonClass
    {
        protected override byte _id { get { return Global.CLN_SEND_PRESSED_LAST; } }
        public int status { get; set; }

        public JsonClassAnsLastInHendCard()
        {
            status = 1;
        }

        public JsonClassAnsLastInHendCard(string json)
        {
            copyOther(JsonConvert.DeserializeObject<JsonClassAnsLastInHendCard>(json));
        }

        public void copyOther(JsonClassAnsLastInHendCard other)
        {
            this.status = other.status;
        }
        public override string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
