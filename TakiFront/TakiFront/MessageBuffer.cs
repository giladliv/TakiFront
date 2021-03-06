using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TakiFront
{
    class MessageBuffer
    {
        public byte Code { get;}
        public int Length { get; }
        public byte[] Message { get; }
        public string StrMess { get; }

        public MessageBuffer(byte code, string mess)
        {
            Code = code;
            Message = Encoding.ASCII.GetBytes(mess);
            Length = Message.Length;
            StrMess = mess;
        }

        public MessageBuffer(byte[] data, FileStream file)
        {
            if (data.Length == 5) return;

            Code = data[0];
            Length = BitConverter.ToInt32(data, 1);

            int len = Length;
            byte[] temp = new byte[] { };
            List<byte> vs = new List<byte>() { };
            int i = 5;
            int read = 1;
            while (len > 0 && read > 0)
            {
                read = file.Read(temp, i, Global.MAX_LEN);
                len -= read;
                vs.AddRange(temp);
                i += read;
            }
            Message = vs.ToArray();
            StrMess = System.Text.Encoding.UTF8.GetString(Message, 0, Message.Length);
        }

        public byte[] getAsRequest()
        {
            List<byte> byteListSend = new List<byte>() { Code };
            byte[] buffer = BitConverter.GetBytes(Length);

            byteListSend.AddRange(buffer);
            byteListSend.AddRange(Message);

            return byteListSend.ToArray();
        }

    }
}
