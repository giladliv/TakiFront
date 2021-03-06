﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace TakiFront
{
    public class JsonClassPlayCard : JsonClass
    {
        // Client - 0x41

        public string card { get; set; }

        public JsonClassPlayCard(string otherCard)
        {
            this.card = otherCard;
        }

        public void copyOther(JsonClassPlayCard other)
        {
            this.card = other.card;
        }
        public override string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }
        public byte[] getAsRequest()
        {
            List<byte> byteListSend = new List<byte>() { Global.CLN_PLAY_CARD };
            byte[] jsonInBytes = Encoding.ASCII.GetBytes(ToJsonFormat());
            byte[] buffer = BitConverter.GetBytes(jsonInBytes.Length);

            byteListSend.AddRange(buffer);
            byteListSend.AddRange(jsonInBytes);

            return byteListSend.ToArray();
        }
    }
}