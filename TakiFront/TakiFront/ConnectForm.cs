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
    public partial class ConnectForm : Form
    {
        private NetworkStream _stream;

        public ConnectForm()
        {
            InitializeComponent();
            ip.Text = "127.0.0.1";
            port.Text = "" + 33666;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (ip.Text != "" && port.Text != "")
            {
                if(!Int32.TryParse(port.Text, out int portNum))
                {
                    return;
                }
                bool closed = false;
                try
                {
                    _stream = Form1.Connect(ip.Text, portNum);
                    LoginOrSignup logSignWin = new LoginOrSignup(_stream);
                    this.Hide();
                    logSignWin.ShowDialog();
                    this.Show();
                    closed = true;
                    _stream.Close();

                }
                catch
                {
                    if (!closed)
                    {
                        ShowError("connection failed, please try again");
                    }
                    
                }
            }
        }

        public static void ShowError(string err)
        {
            MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
