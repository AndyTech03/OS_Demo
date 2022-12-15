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
    public partial class Decimal_Dialog : Form
    {
        public decimal? Result { get; private set; }
        public Decimal_Dialog()
        {
            InitializeComponent();
            Input_NUD.Controls[0].Hide();
            Input_NUD.Controls[1].Width += 4;
        }

        public DialogResult ShowDialog(string title, string message, int min, int max)
        {
            Input_NUD.Value = min;
            Input_NUD.Minimum = min;
            Input_NUD.Maximum = max;
            Input_NUD.Select(0, 1);
            Text = title;
            Message_L.Text = message;
            return ShowDialog();
        }

        private void Accept_B_Click(object sender, EventArgs e)
        {
            Result = Input_NUD.Value;
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
