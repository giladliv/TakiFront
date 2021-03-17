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
using System.IO;

namespace TakiFront
{
    public partial class LoginOrSignup : Form
    {
        private NetworkStream _stream;
        public LoginOrSignup(NetworkStream stream)
        {
            InitializeComponent();
            _stream = stream;
            
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
            catch (IOException ex)
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

        private void LoginOrSignup_FormClosing(object sender, FormClosingEventArgs e)
        {
            _stream.Close();
        }
    }
}
