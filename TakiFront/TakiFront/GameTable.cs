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
using System.Resources;
using System.Net.Sockets;

namespace TakiFront
{
    public partial class GameTable : Form
    {
        private int _numOfPlayers;
        private bool _isWork;
        private List<string> _cards;
        private int _direction;
        private List<Control>[] _controls;
        private List<Control>[] _changableCnt;
        private const int LEN_CONT = 4;
        private const string FILE_CON = "try.txt";
        private int playerIndex;
        private PlayersDataList dataStart;
        private NetworkStream _stream;
        private Exception _exception;
        private ResourceManager rsrcMng;


        public GameTable(JsonClassStartGame startGame, bool isAdmin, NetworkStream stream)
        {
            InitializeComponent();

            _stream = stream;
            _isWork = true;
            dataStart = new PlayersDataList(startGame);
            rsrcMng = Properties.Resources.ResourceManager;

            _direction = 1;
            centerCardBox.Image = getCardImgByString(startGame.centralCard);
            _cards = startGame.cardsDeck;
            refreshDeck();
            _controls = new List<Control>[LEN_CONT] { new List<Control>() { label1, pictureBox1 },
                                               new List<Control>() { label2, pictureBox2 },
                                               new List<Control>() { label3, pictureBox3 },
                                               new List<Control>() { label4, pictureBox4 } };

            _changableCnt = new List<Control>[LEN_CONT] { new List<Control>() { label1, pictureBox1 },
                                               new List<Control>() { label2, pictureBox2 },
                                               new List<Control>() { label3, pictureBox3 },
                                               new List<Control>() { label4, pictureBox4 } };


            setPlayers();
            CloseButton.Visible = isAdmin;
            LeaveButton.Visible = !isAdmin;
            setDirctionBox(_direction);
            backgroundWorker1.RunWorkerAsync();

            //File.WriteAllText("try.txt", "");

        }



        /*
         * this is function that sets the table and the players
         * 
         * 
         */
        private void setPlayers()
        {
            for (int i = 0; i < _controls.Length; i++)
            {
                setVisibleByIndex(_controls, i, false);
            }
            string currName = "";
            setControlsByData();
            for (int i = 0; i < _changableCnt.Length; i++)
            {
                setVisibleByIndex(_changableCnt, i, true);
                currName = (i != dataStart.thisPlyIndex) ? dataStart.names[i] : "you";
                _changableCnt[i][0].Text = currName;
                _changableCnt[i][1].BackColor = ((i == 0) ? Global.CLR_CURR : Global.CLR_OTHER);
                
            }
        }


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

        private void setControlsByData()
        {
            setControlsByNum(dataStart.names.Count - 1);
            List<Control>[] tmpCntrl = new List<Control>[_changableCnt.Length];
            int indOffset = 0;
            for (int i = 0; i < tmpCntrl.Length; i++)
            {
                indOffset = (i + dataStart.thisPlyIndex) % tmpCntrl.Length;
                tmpCntrl[indOffset] = _changableCnt[i];
            }
            _changableCnt = tmpCntrl;
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
            while (_isWork)
            {
                try
                {
                    //string strTry = "";
                    MessageBuffer mbf = MessageBuffer.reciveData(_stream);
                    backgroundWorker1.ReportProgress(0, mbf);
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show("OMG");
                }
                catch (IOException ex)
                {
                    _exception = ex;
                    break;
                }
            }
        }

        

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MessageBuffer mbf = (MessageBuffer)e.UserState;
            messageHandle(mbf);
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_isWork)
            {
                throw _exception;
            }
            
        }

        private void GameTable_FormClosing(object sender, FormClosingEventArgs e)
        {
            Pause();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            button4.PerformClick();
            button1.Visible = false;
        }

        

        private void Button2_Click(object sender, EventArgs e)
        {
            int nxtInd = (dataStart.currGameIndex + 1) % _changableCnt.Length;
            JsonClassSrvDrawCards playCard = new JsonClassSrvDrawCards(new List<string>(){ "7y", "TT" }, 1, nxtInd);
            byte[] n = playCard.getAsRequest();
            //File.WriteAllBytes("mamamia.txt", playCard.getAsRequest());
            File.WriteAllBytes(FILE_CON, playCard.getAsRequest());
            sendDataJson(playCard);

        }
        private int testo = 0;
        private void messageHandle(MessageBuffer buffer)
        {
            switch (buffer.Code)
            {
                case Global.SRV_PLAYED_CARD_WELL:
                    handleCardPlayedAns(buffer.StrMess);
                    break;

                case Global.SRV_DRAW_CARDS:
                    handleCardsRecived(buffer.StrMess);
                    JsonClassSrvDrawCards s = buffer.GetObject<JsonClassSrvDrawCards>();
                    string ness = String.Join(", ", s.cardsDeck);
                    MessageBox.Show(ness);
                    break;

                case Global.SRV_LAST_IN_HAND_FLAG:
                    handleLastInHandFlag(buffer.StrMess);
                    break;

                case Global.CLN_PLAY_CARD:
                    //MessageBox.Show("boom", "oops..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case Global.LEAVE_GAME_RESPONSE:
                    handleLeaveGame(buffer.StrMess);
                    break;

                case Global.CLOSE_ROOM_RESPONSE:
                    this.Close();
                    break;

                case Global.END_GAME:
                    handleEndGame(buffer.StrMess);
                    break;

                case Global.ERROR_RESPONSE:
                    ErrorResponse err = buffer.GetObject<ErrorResponse>();
                    MessageBox.Show(err.message);
                    break;

                default:
                    break;
            }
        }

        /**
         * this is the function that handles the code of 0x42
         * 
         * it showes the card and then changes the enviroment
         */
        private void handleCardPlayedAns(string json)
        {
            JsonClassLeagelCardResponse cardResponse = new JsonClassLeagelCardResponse(json);
            richTextBox1.Text = cardResponse.card;
            centerCardBox.Image = getCardImgByString(cardResponse.card);
            if (dataStart.currGameIndex == dataStart.thisPlyIndex)
            {
                //remove card option
                removeCardFromDeck(cardResponse.card);
                if (cardResponse.card[0] == 't' || cardResponse.card[0] == 'T' || cardResponse.card[0] == 't')
                {
                    button1.Visible = true;
                }
                refreshDeck();
            }
            setVisualCurrentPlayer(cardResponse.index, cardResponse.direction);
        }


        /*
         * this is the function that handles the code of 0x43
         * when recived a new cards in deck
         */
        private void handleCardsRecived(string json)
        {
            JsonClassSrvDrawCards drawCards = new JsonClassSrvDrawCards(json);
            
            button3.Visible = false;
            drawCards.addCardsToHend(ref _cards);
            setVisualCurrentPlayer(drawCards.index, drawCards.direction);
            refreshDeck();

        }


        /*
         * this is the function that handles the code of 0x44
         * when recived a new cards in deck
         */
        private void handleLastInHandFlag(string json)
        {
            JsonClassServAskLastFlag askLastFlag = new JsonClassServAskLastFlag(json);
            
            button3.Visible = true;
        }

        private void handleLeaveGame(string json)
        {
            LeaveRoomResponse leaveResponse = new LeaveRoomResponse(json);
            if (leaveResponse.indexLeave == dataStart.thisPlyIndex)
            {
                Close();
            }
            else
            {
                leaveResponse.updateDataPlayers(ref dataStart);
                setPlayers();
            }


        }

        private void handleEndGame(string json)
        {
            EndGameResponse endGame = new EndGameResponse(json);
            if (endGame.index == dataStart.thisPlyIndex)
            {
                MessageBox.Show("Congratulations!! you are the winner!!", "WINNER!!");
            }
            else
            {
                MessageBox.Show("the player: \"" + endGame.name + "\" has won the game" , "End Game");
            }
            Close();
        }

        /*
         *check if the index and direction have changed, if so, it will be showed 
         * 
         */
        private void setVisualCurrentPlayer(int index, int direction)
        {
            if (index != dataStart.currGameIndex)
            {
                _changableCnt[dataStart.currGameIndex][1].BackColor = Global.CLR_OTHER;
                dataStart.currGameIndex = index;
                _changableCnt[index][1].BackColor = Global.CLR_CURR;

            }
            if (direction != _direction)
            {
                _direction = direction;
                setDirctionBox(_direction);
            }
        }

        private void setDirctionBox(int dir)
        {
            string right = "dr" + dir;
            string left = "dl" + dir;

            directionRightPic.Image = (Bitmap)rsrcMng.GetObject(right);
            directionLeftPic.Image = (Bitmap)rsrcMng.GetObject(left);
        }

        private void refreshDeck()
        {
            textBox1.Text = String.Join(", ", _cards);

            List<PictureBox> pictureBoxes = getCardPictures(_cards);

            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnCount = pictureBoxes.Count;

            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                tableLayoutPanel1.Controls.Add(pictureBoxes[i], i, 0);
            }
            TableLayoutColumnStyleCollection styles =tableLayoutPanel1.ColumnStyles;

            foreach (ColumnStyle style in styles)
            {
                style.SizeType = SizeType.Absolute;
                style.Width = 150;
            }
        }

        private List<PictureBox> getCardPictures(List<string> cardList)
        {
            List<PictureBox> picRet = new List<PictureBox>();

            foreach (string card in cardList)
            {
                PictureBox temp = new PictureBox();
                

                temp.Image = getCardImgByString(card);
                if (temp.Image != null)
                {
                    temp.Tag = card;
                    temp.Height = 170;
                    temp.Width = 170;
                    temp.SizeMode = PictureBoxSizeMode.Zoom;
                    temp.Click += CardClick;
                    picRet.Add(temp);
                }

            }

            return (picRet);
        }

        public Image getCardImgByString(string card)
        {
            string cardSource = card.Replace("=", "c").Replace("$", "p");

            return ((Bitmap)rsrcMng.GetObject(cardSource));
        }

        private void CardClick(object sender, EventArgs e)
        {
            if (dataStart.currGameIndex != dataStart.thisPlyIndex)
            {
                MessageBox.Show("not your turn", "oops..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            PictureBox temp = (PictureBox)sender;
            //MessageBox.Show("THIS IS GOOD " + temp.Tag, "This is nice..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string card = "" + temp.Tag;

            if (card == "==")
            {
                ColorSelect colorSelect = new ColorSelect();

                Pause(true);
                colorSelect.ShowDialog();
                Resume(true);

                string ans = colorSelect.getColor();
                card = (ans == "") ? "" : ("=" + ans);
            }

            if (card != "")
            {
                JsonClassPlayCard playCard = new JsonClassPlayCard(card);
                sendDataJson(playCard);
            }
            

        }

        private void removeCardFromDeck(string card)
        {
            string cardRmv = card;
            if (card.Length > 0 && card[0] == '=')
            {
                cardRmv = "==";
            }
            else if (card == "++")
            {
                cardRmv = "";
            }

            _cards.Remove(cardRmv);
            //need to add about change color
        }


        private void Button3_Click(object sender, EventArgs e)
        {
            //need to handel a writer to stream
            JsonClassAnsLastInHendCard lastInHendCall = new JsonClassAnsLastInHendCard();
            sendDataJson(lastInHendCall);
        }

        private void drawEmpty(object sender, EventArgs e)
        {
            JsonClassPlayCard playCard = new JsonClassPlayCard("++");
            sendDataJson(playCard);
        }

        private void sendDataJson(JsonClass jsonClass)
        {
            try
            {
                MessageBuffer.sendData(jsonClass, _stream);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void Pause(bool toHide = false)
        {
            if (toHide)
            {
                this.Hide();
            }

            _isWork = false;
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }

        }

        private void Resume(bool toShow = false)
        {
            _isWork = true;
            backgroundWorker1.RunWorkerAsync();

            if(toShow)
            {
                this.Show();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            GenricJson genricJson = new GenricJson(Global.CLOSE_ROOM_REQUEST);
            sendDataJson(genricJson);
        }

        private void LeaveButton_Click(object sender, EventArgs e)
        {
            GenricJson genricJson = new GenricJson(Global.LEAVE_GAME_REQUEST);
            sendDataJson(genricJson);
        }
    }

    
}
