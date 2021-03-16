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
    public partial class LoginWindow : Form
    {
        public bool isOk { get; set; }
        public LoginRequest login { get; set; }
        private NetworkStream _stream;

        public LoginWindow(NetworkStream stream)
        {
            isOk = false;
            _stream = stream;
            InitializeComponent();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            login = new LoginRequest(username.Text, password.Text);
            MessageBuffer.sendData(login, _stream);

            MessageBuffer mbf = MessageBuffer.reciveData(_stream);
            switch (mbf.Code)
            {
                case Global.LOGIN_RESPONSE:
                    isOk = true;
                    this.Close();
                    break;

                case Global.ERROR_RESPONSE:
                    ErrorResponse err = mbf.GetObject<ErrorResponse>();
                    MessageBox.Show(err.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                default:
                    break;
            }
        }
    }
}
