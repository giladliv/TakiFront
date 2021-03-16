﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "gilad, tomer, ariel";
            int[] ints = { 3, 1, 0 };
            textBox2.Text = String.Join(", ", ints);
        }

        static NetworkStream Connect(String server, int port)
        {
            TcpClient client = new TcpClient(server, port);
            return client.GetStream();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            List<string> t1 = textBox1.Text.Replace(" ", "").Split(',').ToList();
            List<string> t2 = textBox2.Text.Replace(" ", "").Split(',').ToList();
            int[] ints = Array.ConvertAll(t2.ToArray(), int.Parse);
            List<string> t3 = new List<string>() { "3b", "4g" };

            JsonClassStartGame startGame = new JsonClassStartGame(t1, ints.ToList(), t3, "3y");
            if (t1.Count >= 1 && t1.Count <= 3)
            {
                try
                {
                    NetworkStream stream = Connect("127.0.01", 33666);
                    GameTable game = new GameTable(startGame, stream);
                    this.Hide();
                    game.ShowDialog();
                    this.Show();
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (SocketException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
