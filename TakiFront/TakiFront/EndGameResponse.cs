using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakiFront
{
    public class EndGameResponse : JsonClass
    {
        protected override byte _id { get { return Global.END_GAME; } }

        public uint index { get; set; }
        public string name { get; set; }
        public List<RoomData> rooms { get; set; }

        public EndGameResponse()
        {
        }

        public EndGameResponse(uint ind, string str)
        {
            index = ind;
            name = str;
        }

        public EndGameResponse(EndGameResponse other) : this(other.index, other.name)
        {
        }

        public EndGameResponse(string json) : this(JsonConvert.DeserializeObject<EndGameResponse>(json))
        {

        }

    }
}
