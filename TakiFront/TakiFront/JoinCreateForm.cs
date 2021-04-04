using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TakiFront
{
    public partial class JoinCreateForm : Form
    {
        public const int JOIN_SELECT = 1;
        public const int CRT_SELECT = 2;
        private const int JOIN_WAIT = 3;
        private const int CRT_WAIT = 4;
        private NetworkStream _stream;


        public bool isInRoom { get; set; }
        public JsonClassStartGame startGame { get; set; }
        public JoinCreateForm(int select, NetworkStream stream)
        {
            InitializeComponent();

            _stream = stream;
            isInRoom = false;
            setFormVisual(select);
        }

        private void setFormVisual(int select)
        {
            switch(select)
            {
                case JOIN_SELECT:
                    button1.Visible = true;
                    button2.Visible = true;
                    refreshTable();
                    dataGridView1.Visible = true;
                    break;

                case CRT_SELECT:
                    label1.Visible = true;
                    label2.Visible = true;
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    button3.Visible = true;
                    break;

                case JOIN_WAIT:
                    setFormVisual(0);
                    label3.Visible = true;
                    break;

                case CRT_WAIT:
                    setFormVisual(0);
                    label3.Visible = true;
                    button4.Visible = true;
                    button5.Visible = true;
                    break;

                default:
                    button1.Visible = false;
                    button2.Visible = false;
                    dataGridView1.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    button3.Visible = false;
                    label3.Visible = false;
                    button4.Visible = false;
                    button5.Visible = false;
                    break;
            }
            this.Refresh();
        }
        private void refreshTable()
        {
            GenricJson genric = new GenricJson(Global.GET_ROOM_RESPONSE);
            MessageBuffer.sendData(genric, _stream);

            MessageBuffer mbf = MessageBuffer.reciveData(_stream);
            if (mbf.Code == Global.GET_ROOM_RESPONSE)
            {
                GetRoomsResponse getRooms = mbf.GetObject<GetRoomsResponse>();
                setTable(getRooms.rooms);

            }
        }

        private void setTable(List<RoomData> rooms)
        {
            dataGridView1.Rows.Clear();
            foreach (RoomData room in rooms)
            {
                dataGridView1.Rows.Add(new object[]{ room.id.ToString(), room.name});
            }
            //dataGridView1.Rows.RemoveAt()
            dataGridView1.Refresh();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.SelectedRows.Count;
            //int index = dataGridView1.SelectedRows[0].Index;
            if (selectedRowCount == 1)
            {
                
                string idStr = (string)dataGridView1.SelectedRows[0].Cells["id"].Value;
                if (!UInt32.TryParse(idStr, out uint id))
                {
                    return;
                }
                JoinRoomRequest joinRoom = new JoinRoomRequest(id);
                MessageBuffer.sendData(joinRoom, _stream);

                MessageBuffer mbf = MessageBuffer.reciveData(_stream);
                if (mbf.Code == Global.JOIN_ROOM_RESPONSE)
                {
                    JoinRoomResponse joinResponse = mbf.GetObject<JoinRoomResponse>();
                    startGameWaitHandle(JOIN_WAIT);
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (!UInt32.TryParse(textBox2.Text, out uint max))
            {
                return;
            }
            CreateRoomRequest joinRoom = new CreateRoomRequest(textBox1.Text, max);
            MessageBuffer.sendData(joinRoom, _stream);

            MessageBuffer mbf = MessageBuffer.reciveData(_stream);
            if (mbf.Code == Global.CREATE_ROOM_RESPONSE)
            {
                JoinRoomResponse joinResponse = mbf.GetObject<JoinRoomResponse>();
                startGameWaitHandle(CRT_WAIT);
            }
        }

        private void startGameWaitHandle(int select)
        {
            setFormVisual(select);
            if (select == JOIN_WAIT)
            {
                MessageBuffer mbf = MessageBuffer.reciveData(_stream);
                if (mbf.Code == Global.SRV_START_GAME)
                {
                    startGame = mbf.GetObject<JsonClassStartGame>();
                    isInRoom = true;
                    Close();
                }
                else
                {
                    isInRoom = false;
                    Close();
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            GenricJson genric = new GenricJson(Global.START_GAME_REQUEST);
            MessageBuffer.sendData(genric, _stream);

            MessageBuffer mbf = MessageBuffer.reciveData(_stream);
            if (mbf.Code == Global.SRV_START_GAME)
            {
                startGame = mbf.GetObject<JsonClassStartGame>();
                isInRoom = true;
                Close();
            }
            else
            {
                isInRoom = false;
                Close();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            refreshTable();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            GenricJson genric = new GenricJson(Global.CLOSE_ROOM_REQUEST);
            MessageBuffer.sendData(genric, _stream);
        }
    }
}
