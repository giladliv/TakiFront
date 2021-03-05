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
                currName = (i > 0) ? _names[i-1] : "you";
                _changableCnt[i][0].Text = currName;
            }
        }

        private void setControlsByNum(int num)
        {
            if (num == 1)
            {
                _changableCnt = new List<Control>[2] { _controls[0] , _controls[2]};
            }
            if (num == 2)
            {
                _changableCnt = new List<Control>[3] { _controls[0], _controls[1], _controls[3]};
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
            return JsonConvert.DeserializeObject< Dictionary<string, object>>(str);
        }

        private string _strTry;
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //backgroundWorker1.ReportProgress(-1);
            //for (int i = 0; i < 100; i++)
            int i = 0;
            while (true)
            {
                _strTry = File.ReadAllText(FILE_CON, Encoding.GetEncoding("windows-1255"));
                if (_strTry.Length > 0)
                {
                    backgroundWorker1.ReportProgress(i, _strTry);
                }
                Thread.Sleep(1);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //e.UserState.
            richTextBox1.Text = (string)e.UserState;
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

        }
    }
}
