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
    public partial class FormInst : Form
    {
        protected int index = Program.formsCounter++;
        
        public FormInst()
        {
            this.Load += FormInst_Load;
            this.FormClosed += FormInst_FormClosed;
        }

        private void FormInst_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Program.formsMap.ContainsKey(index))
            {
                Program.formsMap.Remove(index);
            }
        }

        private void FormInst_Load(object sender, EventArgs e)
        {
            Program.addFormToMap(index, this);
        }
    }
}
