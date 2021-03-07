using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace TakiFront
{
    public class JsonClassStartGame : JsonClass
    {
        // server - 0x40
        protected override byte _id { get { return Global.SRV_START_GAME; } }

        public List<string> player_names { get; set; }
        public List<string> turns { get; set; }
        public List<string> cardsDeck { get; set; }
        public string centralCard { get; set; }

        public JsonClassStartGame(string json)
        {
            copyOther(JsonConvert.DeserializeObject<JsonClassStartGame>(json));
        }

        public void copyOther(JsonClassStartGame other)
        {
            this.player_names = other.player_names;
            this.turns = other.turns;
            this.cardsDeck = other.cardsDeck;
            this.centralCard = other.centralCard;
        }

        public override string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
