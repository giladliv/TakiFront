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
    public partial class GameMenu : Form
    {
        private NetworkStream _stream;
        public GameMenu(NetworkStream stream)
        {
            InitializeComponent();

            _stream = stream;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            JoinCreateForm joinCreateForm = new JoinCreateForm(JoinCreateForm.JOIN_SELECT, _stream);
            this.Hide();
            joinCreateForm.ShowDialog();
            if (joinCreateForm.isInRoom)
            {
                GameTable game = new GameTable(joinCreateForm.startGame, false, _stream);
                this.Hide();
                game.ShowDialog();
                this.Show();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            JoinCreateForm joinCreateForm = new JoinCreateForm(JoinCreateForm.CRT_SELECT, _stream);
            this.Hide();
            joinCreateForm.ShowDialog();
            if (joinCreateForm.isInRoom)
            {
                GameTable game = new GameTable(joinCreateForm.startGame, true, _stream);
                this.Hide();
                game.ShowDialog();
                this.Show();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            GenricJson logutRequest = new GenricJson(Global.LOGOUT_RESPONSE);
            MessageBuffer.sendData(logutRequest, _stream);

            MessageBuffer mbf = MessageBuffer.reciveData(_stream);
            if (mbf.Code == Global.LOGOUT_RESPONSE)
            {
                this.Close();
            }

        }
    }
}
