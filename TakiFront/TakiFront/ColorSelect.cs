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
    public partial class ColorSelect : Form
    {
        private string _color;
        public ColorSelect()
        {
            InitializeComponent();
            _color = "";
            button1.Click += colorClicked;
        }

        private void colorClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            _color = button.Tag.ToString();
            this.Close();
        }

        public string getColor()
        {
            return (_color);
        }

    }
}
