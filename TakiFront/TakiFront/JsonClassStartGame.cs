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
        public List<int> turns { get; set; }
        public List<string> cardsDeck { get; set; }
        public string centralCard { get; set; }

        public JsonClassStartGame()
        {

        }
        public JsonClassStartGame(List<string> playerNames, List<int> trn, List<string> crdDeck, string cntrCard)
        {
            player_names = playerNames;
            turns = trn;
            cardsDeck = crdDeck;
            centralCard = cntrCard;
        }
        public JsonClassStartGame(string json)
        {
            copyOther(JsonConvert.DeserializeObject<JsonClassStartGame>(json));
        }
        public JsonClassStartGame(JsonClassStartGame other) : this(other.player_names, other.turns, other.cardsDeck, other.centralCard)
        {
            
        }

        public void copyOther(JsonClassStartGame other)
        {
            this.player_names = other.player_names;
            this.turns = other.turns;
            this.cardsDeck = other.cardsDeck;
            this.centralCard = other.centralCard;
        }

        public int getIndexThisPlayer()
        {
            int len = turns.Count + 1;
            int[] trnList = new int[len];

            for (int i = 0; i < len; i++)
            {
                if (i < len - 1 && turns[i] < len)
                {
                    trnList[turns[i]] = 1;
                }
            }

            if (trnList.Contains(0))
            {
                return Array.IndexOf(trnList, 0);
            }

            return -1;
        }

        public override string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
