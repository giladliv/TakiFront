using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace TakiFront
{
    public class GetPlayersInRoomRequest : JsonClass
    {
        protected override byte _id { get { return Global.PLAYERS_ROOM_REQUEST; } }

        public uint roomId { get; set; }

        public GetPlayersInRoomRequest()
        {
            roomId = 0;
        }

        public GetPlayersInRoomRequest(uint id)
        {
            roomId = id;
        }

        public GetPlayersInRoomRequest(GetPlayersInRoomRequest other) : this(other.roomId)
        {
        }

        public GetPlayersInRoomRequest(string json) : this(JsonConvert.DeserializeObject<GetPlayersInRoomRequest>(json))
        {
            
        }

        public override string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }
    }



    //joinRomm class

    public class JoinRoomRequest : JsonClass
    {
        protected override byte _id { get { return Global.JOIN_ROOM_REQUEST; } }

        public uint roomId { get; set; }

        public JoinRoomRequest()
        {
            roomId = 0;
        }

        public JoinRoomRequest(uint id)
        {
            roomId = id;
        }

        public JoinRoomRequest(JoinRoomRequest other) : this(other.roomId)
        {
        }

        public JoinRoomRequest(string json) : this(JsonConvert.DeserializeObject<JoinRoomRequest>(json))
        {

        }

        public override string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }
    }



    //create room request class

    public class CreateRoomRequest : JsonClass
    {
        protected override byte _id { get { return Global.CREATE_ROOM_REQUEST; } }

        public string roomName { get; set; }
        public uint maxUsers { get; set; }

        public CreateRoomRequest()
        {

        }

        public CreateRoomRequest(string name, uint max)
        {
            roomName = name;
            maxUsers = max;
        }

        public CreateRoomRequest(CreateRoomRequest other) : this(other.roomName, other.maxUsers)
        {
        }

        public CreateRoomRequest(string json) : this(JsonConvert.DeserializeObject<CreateRoomRequest>(json))
        {

        }

        public override string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}