using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace TakiFront
{
    public class LeaveRoomResponse : JsonClass
    {
        protected override byte _id { get { return Global.LOGOUT_RESPONSE; } }

        public int indexLeave { get; set; }
        public string name { get; set; }
        public int indexNext { get; set; }

        public LeaveRoomResponse()
        {
            
        }

        public LeaveRoomResponse(int ind, string str, int next)
        {
            indexLeave = ind;
            name = str;
            indexNext = next;

        }

        public LeaveRoomResponse(LeaveRoomResponse other) : this(other.indexLeave, other.name, other.indexNext)
        {

        }

        public LeaveRoomResponse(string json) : this(JsonConvert.DeserializeObject<LeaveRoomResponse>(json))
        {

        }

        public void updateDataPlayers(ref PlayersDataList dataGame)
        {
            //int index = startGame.turns.IndexOf(indexLeave);
            if (indexLeave != dataGame.thisPlyIndex && indexLeave < dataGame.names.Count)
            {
                dataGame.names.RemoveAt(indexLeave);
                dataGame.currGameIndex = indexNext;
            }
        }

        public override string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}