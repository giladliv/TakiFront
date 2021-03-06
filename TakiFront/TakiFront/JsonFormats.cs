﻿using System;
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
        public const byte SRV_START_GAME = 0x40;
        public const byte CLN_PLAY_CARD = 0x41;
        public const byte SRV_PLAYED_CARD_WELL = 0x42;
        public const byte SRV_DRAW_CARDS = 0x43;
        public const byte SRV_LAST_IN_HAND_FLAG = 0x44;
        public const byte CLN_SEND_PRESSED_LAST = 0x45;
    }


    public class JsonClass
    {
        public virtual string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}