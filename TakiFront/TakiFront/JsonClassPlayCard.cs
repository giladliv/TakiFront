using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace TakiFront
{
    public class JsonClassPlayCard : JsonClass
    {
        // Client - 0x41
        protected override byte _id { get { return Global.CLN_PLAY_CARD; } }

        public string card { get; set; }

        public JsonClassPlayCard(string otherCard)
        {
                 // 0x41
            this.card = otherCard;
        }

        public void copyOther(JsonClassPlayCard other)
        {
            this.card = other.card;
        }
        public override string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
