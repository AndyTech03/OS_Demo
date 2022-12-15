using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS_Demo
{
    public partial class DISK_Controller : Form
    {

        public DISK_Controller()
        {
            InitializeComponent();
            Page_NUD.Controls[0].Hide();
            Page_NUD.Controls[1].Width = 100;
            Update_Table();
            Update_Page();
        }


        private void Next_B_Click(object sender, EventArgs e)
        {
            if (Page_NUD.Value < Page_NUD.Maximum)
                Page_NUD.Value++;
        }

        private void Prev_B_Click(object sender, EventArgs e)
        {
            if (Page_NUD.Value > Page_NUD.Minimum)
                Page_NUD.Value--;
        }

        private void Page_NUD_ValueChanged(object sender, EventArgs e)
        {
            Invoke(Update_Page);
        }

        public void Invoke_Table_Update()
        {
            if (Visible == false)
                return;
            Invoke(Update_Table);
        }

        public void InvokePages_Update(int start_address, int end_address)
        {
            if (Visible == false)
                return;
            var start_page = (int)Math.Ceiling(start_address / 256.0);
            var end_page = (int)Math.Ceiling((start_address + end_address) / 256.0);
            if (start_page <= Page_NUD.Value || Page_NUD.Value <= end_address)
                Invoke(Update_Page);
        }

        private void Update_Table()
        {
            byte[] data = OS.Read_DISK(0, 256 * 7);
            int? index = PageTable_LV.SelectedIndices.Count > 0 ? PageTable_LV.SelectedIndices[0] : null;
            PageTable_LV.Items.Clear();
            for (int i = 0; i < data.Length; i += 25)
            {
                if (data[i] == 0)
                    break;
                byte type = data[i];
                ushort address = BitConverter.ToUInt16(data[(i + 1)..(i + 3)]);
                ushort len = BitConverter.ToUInt16(data[(i + 3)..(i + 5)]);
                string name = Encoding.UTF8.GetString(data[(i + 5)..(i + 25)]);
                PageTable_LV.Items.Add(new ListViewItem(new string[] { type.ToString(), address.ToString(), len.ToString(), name.ToString() }));
            }
            if (index.HasValue && PageTable_LV.Items.Count > index.Value)
                PageTable_LV.SelectedIndices.Add(index.Value);
        }

        private void Update_Page()
        {
            byte[] data = OS.Read_DISK((int)Page_NUD.Value * 256, 256);
            var decemal_items = data.Select(b => new ListViewItem(b.ToString())).ToArray();
            var hex_items = data.Select(b => new ListViewItem(b.ToString("X2"))).ToArray();
            if (decemal_items.GetHashCode() != Decemal_LV.Items.GetHashCode())
            {
                if (decemal_items.Length != Decemal_LV.Items.Count)
                {
                    Decemal_LV.Items.Clear();
                    Decemal_LV.Items.AddRange(decemal_items);
                    Hex_LV.Items.Clear();
                    Hex_LV.Items.AddRange(hex_items);
                    return;
                }
                for (int i = 0; i < decemal_items.Length; i++)
                {
                    if (Decemal_LV.Items[i].Text != decemal_items[i].Text)
                    {
                        Decemal_LV.Items[i].Text = decemal_items[i].Text;
                        Hex_LV.Items[i].Text = hex_items[i].Text;
                    }
                }
            }
        }

        private void Decemal_LV_MouseUp(object sender, MouseEventArgs e)
        {
            if (Decemal_LV.SelectedIndices.Count == 0)
                return;
            Hex_LV.SelectedIndices.Clear();
            Hex_LV.SelectedIndices.Add(Decemal_LV.SelectedIndices[0]);
        }

        private void Hex_LV_MouseUp(object sender, MouseEventArgs e)
        {
            if (Hex_LV.SelectedIndices.Count == 0)
                return;
            Decemal_LV.SelectedIndices.Clear();
            Decemal_LV.SelectedIndices.Add(Hex_LV.SelectedIndices[0]);
        }

        private void PageTable_LV_MouseUp(object sender, MouseEventArgs e)
        {
            if (PageTable_LV.SelectedIndices.Count == 0)
                return;
            Page_NUD.Value = int.Parse(PageTable_LV.SelectedItems[0].SubItems[1].Text);
            Update_Table();
        }
    }
}
