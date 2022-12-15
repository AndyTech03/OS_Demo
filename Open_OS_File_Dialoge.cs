using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace OS_Demo
{
    public partial class Open_OS_File_Dialoge : Form
    {
        public string? File_Name { get; private set; }
        public int? File_Address { get; private set; }
        public int? File_Size { get; private set; }
        public byte? File_Type { get; private set; }

        private List<int> address_list;
        private List<int> sizes_list;
        private List<byte> types_list;
        private int _prev_index;

        public Open_OS_File_Dialoge()
        {
            InitializeComponent();
            address_list = new List<int>();
            sizes_list = new List<int>();
            types_list = new List<byte>();
            _prev_index = 0;
        }

        public new DialogResult ShowDialog()
        {
            Filename_TB.Text = "";
            var table = OS.Read_DISK(0, 256);
            Files_LV.Items.Clear();
            address_list.Clear();
            sizes_list.Clear();
            types_list.Clear();
            for (int i = 0; i < 256; i += 25)
            {
                if (table[i] == 0)
                    break;
                byte type = table[i];
                var address = BitConverter.ToUInt16(table, i + 1);
                var size = BitConverter.ToUInt16(table, i + 3);
                string name = Encoding.UTF8.GetString(table, i + 5, 20).Replace("\0", "");
                Files_LV.Items.Add(name);
                types_list.Add(type);
                address_list.Add(address);
                sizes_list.Add(size);
            }
            return base.ShowDialog();
        }

        public DialogResult ShowDialog(byte type)
        {
            Filename_TB.Text = "";
            var table = OS.Read_DISK(0, 256);
            Files_LV.Items.Clear();
            address_list.Clear();
            sizes_list.Clear();
            types_list.Clear();
            for (int i = 0; i < 256; i += 25)
            {
                byte f_type = table[i];
                if (f_type == 0)
                    break;
                if (f_type != type)
                    continue;
                var address = BitConverter.ToUInt16(table, i + 1);
                var size = BitConverter.ToUInt16(table, i + 3);
                string name = Encoding.UTF8.GetString(table, i + 5, 20).Replace("\0", "");
                Files_LV.Items.Add(name);
                types_list.Add(f_type);
                address_list.Add(address);
                sizes_list.Add(size);
            }
            return base.ShowDialog();
        }

        private void Accept_B_Click(object sender, EventArgs e)
        {
            if (Files_LV.SelectedIndices.Count == 0)
                return;
            int index = Files_LV.SelectedIndices[0];
            File_Name = Files_LV.Items[index].Text;
            File_Address = address_list[index];
            File_Size = sizes_list[index];
            File_Type = types_list[index];
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Cancel_B_Click(object sender, EventArgs e)
        {
            File_Name = null;
            File_Address = null;
            File_Size = null;
            File_Type = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Files_LV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Files_LV.SelectedIndices.Count != 0)
                Filename_TB.Text = Files_LV.SelectedItems[0].Text;
        }

        private void Filename_TB_TextChanged(object sender, EventArgs e)
        {
            int cur_pos = Filename_TB.SelectionStart;
            if (cur_pos == 0)
                return;

            Files_LV.SelectedIndices.Clear();
            for (int i = 0; i < Files_LV.Items.Count; i++)
            {
                if (Files_LV.Items[i].Text.ToLower().StartsWith(Filename_TB.Text.ToLower()))
                {
                    if (cur_pos == _prev_index)
                        cur_pos--;
                    if (cur_pos == 0)
                    {
                        _prev_index = 0;
                        Filename_TB.Text = "";
                        return;
                    }

                    Filename_TB.Text = Files_LV.Items[i].Text;
                    Filename_TB.SelectionStart = cur_pos;
                    Filename_TB.SelectionLength = Filename_TB.Text.Length - cur_pos;
                    _prev_index = cur_pos;

                    Files_LV.SelectedIndices.Add(i);
                    break;
                }
            }
        }

        private void Open_OS_File_Dialoge_Shown(object sender, EventArgs e)
        {
            Filename_TB.Focus();
        }
    }
}
