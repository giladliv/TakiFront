using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace TakiFront
{
    public partial class LoginOrSignup : Form
    {
        private NetworkStream _stream;
        public LoginOrSignup()
        {
            InitializeComponent();
            _stream = Form1.Connect("127.0.0.1", 33666);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            LoginWindow loginWin = new LoginWindow(_stream);
            this.Hide();

            try
            {
                loginWin.ShowDialog();
                if (loginWin.isOk)
                {
                    Form1 starter = new Form1(loginWin.login.username, _stream);
                    starter.ShowDialog();
                }
            }
            catch
            {
                MessageBox.Show("mama mia!!");
            }

            this.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SignUpWindow signUpWin = new SignUpWindow(_stream);
            this.Hide();

            try
            {
                signUpWin.ShowDialog();
                if (signUpWin.isOk)
                {
                    Form1 starter = new Form1(signUpWin.signup.username, _stream);
                    starter.ShowDialog();
                }
            }
            catch
            {
                MessageBox.Show("mama mia!!");
            }
            
            this.Show();
        }

        private void LoginOrSignup_Load(object sender, EventArgs e)
        {
            _stream.Close();
        }
    }
}
