using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace TakiFront
{
    public class JsonClassLeagelCardResponse : JsonClass
    {
        public string card { get; set; }
        public int direction { get; set; }
        public int index { get; set; }

        public JsonClassLeagelCardResponse(string json)
        {
            copyOther(JsonConvert.DeserializeObject<JsonClassLeagelCardResponse>(json));
        }

        public void copyOther(JsonClassLeagelCardResponse other)
        {
            this.card = other.card;
            this.direction = other.direction;
            this.index = other.index;
        }
        public override string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
