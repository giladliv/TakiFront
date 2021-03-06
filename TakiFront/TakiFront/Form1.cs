using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            textBox1.Text = "gilad";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            List<string> t1 = textBox1.Text.Replace(" ", "").Split(',').ToList();
            List<string> t2 = textBox2.Text.Replace(" ", "").Split(',').ToList();

            if (t1.Count >= 1 && t1.Count <= 3)
            {
                GameTable game = new GameTable(t1, t2);
                this.Hide();
                game.ShowDialog();
                this.Show();
            }
        }
    }
}
