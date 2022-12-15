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
    public partial class String_Dialog : Form
    {
        public string? Result { get; private set; }
        public String_Dialog()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(string title, string message)
        {
            Input_TB.Text = "";
            Input_TB.Focus();
            Text = title;
            Message_L.Text = message;
            return ShowDialog();
        }

        private void Accept_B_Click(object sender, EventArgs e)
        {
            Result = Input_TB.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Cancel_B_Click(object sender, EventArgs e)
        {
            Result = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
