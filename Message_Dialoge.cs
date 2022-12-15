using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS_Demo
{
    public partial class Message_Dialoge : Form
    {
        public Message_Dialoge()
        {
            InitializeComponent();
        }

        public DialogResult Show_Message(string text)
        {
            Text_L.Text = text;
            return ShowDialog();
        }

        private void OK_B_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
