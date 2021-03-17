using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace TakiFront
{
    public class LogoutResponse : JsonClass
    {
        protected override byte _id { get { return Global.LOGOUT_RESPONSE; } }

        public uint status { get; set; }

        public LogoutResponse()
        {
            status = 0;
        }

        public LogoutResponse(uint id)
        {
            status = id;
        }

        public LogoutResponse(LogoutResponse other) : this(other.status)
        {
        }

        public LogoutResponse(string json) : this(JsonConvert.DeserializeObject<LogoutResponse>(json))
        {

        }

        public override string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }
    }



    //joinRomm class

    public class GetRoomsResponse : JsonClass
    {
        protected override byte _id { get { return Global.GET_ROOM_RESPONSE; } }

        public uint status { get; set; }
        public List<RoomData> rooms { get; set; }

        public GetRoomsResponse()
        {
            status = 0;
        }

        public GetRoomsResponse(uint id, List<RoomData> r)
        {
            status = id;
            rooms = r;
        }

        public GetRoomsResponse(GetRoomsResponse other) : this(other.status, other.rooms)
        {
        }

        public GetRoomsResponse(string json) : this(JsonConvert.DeserializeObject<GetRoomsResponse>(json))
        {

        }

        public override string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }
    }



    //create room request class

    public class GetPlayersInRoomResponse : JsonClass
    {
        protected override byte _id { get { return Global.PLAYERS_ROOM_RESPONSE; } }

        public List<string> rooms { get; set; }

        public GetPlayersInRoomResponse()
        {

        }

        public GetPlayersInRoomResponse(List<string> name)
        {
            rooms = name;
        }

        public GetPlayersInRoomResponse(GetPlayersInRoomResponse other) : this(other.rooms)
        {
        }

        public GetPlayersInRoomResponse(string json) : this(JsonConvert.DeserializeObject<GetPlayersInRoomResponse>(json))
        {

        }

        public override string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }
    }


    public class getHighScoreResponse : JsonClass
    {
        protected override byte _id { get { return Global.HIGH_SCORE_RESPONSE; } }

        public uint status { get; set; }
        public List<string> statistics { get; set; }

        public getHighScoreResponse()
        {
            status = 0;
        }

        public getHighScoreResponse(uint id, List<string> s)
        {
            status = id;
            statistics = s;
        }

        public getHighScoreResponse(getHighScoreResponse other) : this(other.status, other.statistics)
        {
        }

        public getHighScoreResponse(string json) : this(JsonConvert.DeserializeObject<getHighScoreResponse>(json))
        {

        }

        public override string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }
    }



    //joinRomm class

    public class getPersonalStatsResponse : JsonClass
    {
        protected override byte _id { get { return Global.PERSONAL_STATS_RESPONSE; } }

        public uint status { get; set; }
        public List<string> statistics { get; set; }

        public getPersonalStatsResponse()
        {
            status = 0;
        }

        public getPersonalStatsResponse(uint id, List<string> s)
        {
            status = id;
            statistics = s;
        }

        public getPersonalStatsResponse(getPersonalStatsResponse other) : this(other.status, other.statistics)
        {
        }

        public getPersonalStatsResponse(string json) : this(JsonConvert.DeserializeObject<getPersonalStatsResponse>(json))
        {

        }

        public override string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }
    }



    //create room request class

    public class JoinRoomResponse : JsonClass
    {
        protected override byte _id { get { return Global.JOIN_ROOM_RESPONSE; } }

        public uint status { get; set; }

        public JoinRoomResponse()
        {

        }

        public JoinRoomResponse(uint id)
        {
            status = id;
        }

        public JoinRoomResponse(JoinRoomResponse other) : this(other.status)
        {
        }

        public JoinRoomResponse(string json) : this(JsonConvert.DeserializeObject<JoinRoomResponse>(json))
        {

        }

        public override string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }
    }


    //joinRomm class

    public class CreateRoomResponse : JsonClass
    {
        protected override byte _id { get { return Global.HIGH_SCORE_RESPONSE; } }

        public uint status { get; set; }

        public CreateRoomResponse()
        {
            status = 0;
        }

        public CreateRoomResponse(uint id)
        {
            status = id;
        }

        public CreateRoomResponse(CreateRoomResponse other) : this(other.status)
        {

        }

        public CreateRoomResponse(string json) : this(JsonConvert.DeserializeObject<CreateRoomResponse>(json))
        {

        }

        public override string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}