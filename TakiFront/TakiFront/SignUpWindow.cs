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
    public partial class SignUpWindow : Form
    {
        public bool isOk { get; set; }
        public SignupRequest signup { get; set; }
        private NetworkStream _stream;
        public SignUpWindow(NetworkStream stream)
        {
            isOk = false;
            _stream = stream;
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            signup = new SignupRequest(username.Text, password.Text, email.Text);
            MessageBuffer.sendData(signup, _stream);

            MessageBuffer mbf = MessageBuffer.reciveData(_stream);
            switch (mbf.Code)
            {
                case Global.SIGN_UP_RESPONSE:
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

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
