using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using Newtonsoft.Json.Linq;


namespace TakiFront
{
    public class Global
    {
        public const byte ERROR_RESPONSE = 0x07;

        //1.0.0

        public const byte LOGIN_REQUEST = 0x10;
        public const byte SIGN_UP_REQUEST = 0x11;

        public const byte LOGIN_RESPONSE = 0x12;
        public const byte SIGN_UP_RESPONSE = 0x13;


        //2.0.0
        public const byte PLAYERS_ROOM_REQUEST = 0x20;
        public const byte JOIN_ROOM_REQUEST = 0x21;
        public const byte CREATE_ROOM_REQUEST = 0x22;

        public const byte LOGOUT_RESPONSE = 0x23;
        public const byte GET_ROOM_RESPONSE = 0x24;
        public const byte PLAYERS_ROOM_RESPONSE = 0x25;
        public const byte HIGH_SCORE_RESPONSE = 0x26;
        public const byte PERSONAL_STATS_RESPONSE = 0x27;
        public const byte JOIN_ROOM_RESPONSE = 0x28;
        public const byte CREATE_ROOM_RESPONSE = 0x29;


        //4.0.0
        public const byte SRV_START_GAME = 0x40;
        public const byte CLN_PLAY_CARD = 0x41;
        public const byte SRV_PLAYED_CARD_WELL = 0x42;
        public const byte SRV_DRAW_CARDS = 0x43;
        public const byte SRV_LAST_IN_HAND_FLAG = 0x44;
        public const byte CLN_SEND_PRESSED_LAST = 0x45;
        public const int MAX_LEN = 2048;
        public static Color CLR_CURR = Color.LawnGreen;
        public static Color CLR_OTHER = Color.DodgerBlue;

    }


    public class JsonClass
    {
        protected virtual byte _id { get; }

        public virtual string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }

        public byte[] getAsRequest()
        {
            List<byte> byteListSend = new List<byte>() { _id };
            byte[] jsonInBytes = Encoding.ASCII.GetBytes(ToJsonFormat());
            byte[] buffer = BitConverter.GetBytes(jsonInBytes.Length);

            byteListSend.AddRange(buffer);
            byteListSend.AddRange(jsonInBytes);

            return byteListSend.ToArray();
        }
    }

    public class RoomData
    {
        public uint id { get; set; }
        public string name { get; set; }
        public uint maxPlayers { get; set; }
        public uint isActive { get; set; }

        public RoomData()
        {

        }
    }

}
