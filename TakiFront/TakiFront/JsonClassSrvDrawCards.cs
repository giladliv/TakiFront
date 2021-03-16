using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace TakiFront
{
    class JsonClassSrvDrawCards : JsonClass
    {
        protected override byte _id { get { return Global.SRV_DRAW_CARDS; } }

        public List<string> cardsDeck { get; set; }
        public int direction { get; set; }
        public int index { get; set; }

        public JsonClassSrvDrawCards()
        {

        }

        public JsonClassSrvDrawCards(List<string> c, int d, int i)
        {
            cardsDeck = c;
            direction = d;
            index = i;
        }
    

        public JsonClassSrvDrawCards(string json)
        {
            copyOther(JsonConvert.DeserializeObject<JsonClassSrvDrawCards>(json));
        }

        public void copyOther(JsonClassSrvDrawCards other)
        {
            this.cardsDeck = other.cardsDeck;
            this.direction = other.direction;
            this.index = other.index;
        }

        public void addCardsToHend(ref List<string> other)
        {
            other.AddRange(cardsDeck);
        }

        public override string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
