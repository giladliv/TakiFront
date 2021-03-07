using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace TakiFront
{
    public partial class GameTable : Form
    {
        private int _numOfPlayers;
        private List<string> _cards;
        private List<string> _names;
        private int _direction;
        private List<Control>[] _controls;
        private List<Control>[] _changableCnt;
        private const int LEN_CONT = 4;
        private const string FILE_CON = "try.txt";
        private int playerIndex;

        public GameTable(List<string> names, List<string> cards)
        {
            InitializeComponent();
            _numOfPlayers = names.Count + 1;
            _cards = cards;
            _names = names;
            _direction = 1;
            _controls = new List<Control>[LEN_CONT] { new List<Control>() { label1 },
                                               new List<Control>() { label2 },
                                               new List<Control>() { label3 },
                                               new List<Control>() { label4 } };

            _changableCnt = new List<Control>[LEN_CONT] { new List<Control>() { label1 },
                                               new List<Control>() { label2 },
                                               new List<Control>() { label3 },
                                               new List<Control>() { label4 } };
            setPlayers();
            //File.WriteAllText("try.txt", "");
            backgroundWorker1.RunWorkerAsync();
        }



        /*
         * this is function that sets the table and the players
         * 
         * 
         */
        private void setPlayers()
        {
            setControlsByNum(_names.Count);
            for (int i = 0; i < _controls.Length; i++)
            {
                setVisibleByIndex(_controls, i, false);
            }
            string currName = "";
            for (int i = 0; i < _changableCnt.Length; i++)
            {
                setVisibleByIndex(_changableCnt, i, true);
                currName = (i > 0) ? _names[i - 1] : "you";
                _changableCnt[i][0].Text = currName;
            }
        }

        //void set

        private void setControlsByNum(int num)
        {
            if (num == 1)
            {
                _changableCnt = new List<Control>[2] { _controls[0], _controls[2] };
            }
            if (num == 2)
            {
                _changableCnt = new List<Control>[3] { _controls[0], _controls[1], _controls[3] };
            }
            if (num == 3)
            {
                _changableCnt = new List<Control>[4] { _controls[0], _controls[1], _controls[2], _controls[3] };
            }
        }

        private void setVisibleByIndex(List<Control>[] controls, int index, bool isVisible)
        {
            if (0 > index || index >= controls.Length) return;

            for (int i = 0; i < controls[index].Count; i++)
            {
                controls[index][i].Visible = isVisible;
                controls[index][i].Refresh();
            }
        }

        public static string SerializeJson(Dictionary<string, object> dict)
        {
            return JsonConvert.SerializeObject(dict);
        }

        public static Dictionary<string, object> DeserializeJson(string str)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(str);
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            FileStream file = null;
            while (true)
            {

                try
                {
                    //string strTry = "";
                    if (File.Exists(FILE_CON))
                    {
                        file = File.OpenRead(FILE_CON);
                        byte[] reader = new byte[5];
                        int count = file.Read(reader, 0, 5);
                        MessageBuffer mbf = new MessageBuffer(reader, file);
                        //strTry = mbf.StrMess;
                        file.Close();
                        backgroundWorker1.ReportProgress(0, mbf.StrMess);
                    }
                    
                    File.Delete(FILE_CON);
                }
                catch (Exception)
                {
                    if (file != null)
                    {
                        file.Close();
                    }
                    
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            List<string> trnList = new List<string>(4);
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //e.UserState.
            string json = (string)e.UserState;
            JsonClassLeagelCardResponse m = new JsonClassLeagelCardResponse(json);
            richTextBox1.Text = m.card;
        }

        private void GameTable_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            JsonClassLeagelCardResponse playCard = new JsonClassLeagelCardResponse(richTextBox2.Text, 1, 1);
            byte[] n = playCard.getAsRequest();
            //File.WriteAllBytes("lama.txt", playCard.getAsRequest());
            File.WriteAllBytes(FILE_CON, playCard.getAsRequest());
        }

        private void messageHandle(MessageBuffer buffer)
        {
            switch (buffer.Code)
            {
                case Global.SRV_PLAYED_CARD_WELL:
                    handleCardPlayedAns(buffer.StrMess);
                    break;

                default:
                    break;
            }
        }

        private void handleCardPlayedAns(string json)
        {
            JsonClassLeagelCardResponse cardResponse = new JsonClassLeagelCardResponse(json);

        }

        private void tryJsonPress()
        {
            TryOnIt onIt = new TryOnIt();
            onIt.yo = 8;
            onIt.mama = new List<string>() { "dsds" };

            File.WriteAllText("yes.txt", JsonConvert.SerializeObject(onIt));

            Dictionary<string, object> me = new Dictionary<string, object>();
            me["mama"] = new List<string>() { "aleph", "bet", "gimel" };
            me["yo"] = 3;
            File.WriteAllText("me.txt", SerializeJson(me));

            TryOnIt nora = JsonConvert.DeserializeObject<TryOnIt>(File.ReadAllText("yes.txt"));
            nora = JsonConvert.DeserializeObject<TryOnIt>(File.ReadAllText("me.txt"));

            Dictionary<string, object> lama = DeserializeJson(File.ReadAllText("me.txt"));
            JArray a = JArray.FromObject(lama["mama"]);
            List<string> yo = a.ToObject<List<string>>();
            int ok = Convert.ToInt32(lama["yo"]);

            //byte
            int i = 1099;
            byte[] buffer = BitConverter.GetBytes(i);
            int j = 1;


        }
    }

    public class TryOnIt
    {
        public int yo { get; set; }
        public List<string> mama { get; set; }
    }
}
