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
        // server - 0x42
        protected override byte _id { get { return Global.SRV_PLAYED_CARD_WELL; } }

        public string card { get; set; }
        public int direction { get; set; }
        public int index { get; set; }

        public JsonClassLeagelCardResponse() : this("", 1, 0)
        {
        }
        public JsonClassLeagelCardResponse(string c, int d, int i)
        {
            card = c;
            direction = d;
            index = i;
        }

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

        //public byte[] getAsRequest()
        //{
        //    List<byte> byteListSend = new List<byte>() { Global.CLN_PLAY_CARD };
        //    byte[] jsonInBytes = Encoding.ASCII.GetBytes(ToJsonFormat());
        //    byte[] buffer = BitConverter.GetBytes(jsonInBytes.Length);

        //    byteListSend.AddRange(buffer);
        //    byteListSend.AddRange(jsonInBytes);

        //    return byteListSend.ToArray();

        //}
    }
}
