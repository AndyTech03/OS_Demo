using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS_Demo
{
    public partial class IDE_From : Form
    {
        string? FileName
        {
            get => filename;
            set
            {
                filename = value;
                if (value is null)
                    Text = "Новый файл";
                else
                    Text = value;
            }
        }
        string? filename;
        byte? filetype;
        String_Dialog string_dialog;
        Decimal_Dialog decimal_dialog;
        Open_OS_File_Dialoge open_file_dialoge;
        public IDE_From()
        {
            InitializeComponent();
            open_file_dialoge = new();
            string_dialog = new();
            decimal_dialog = new();
        }

        public static byte[] Compile(string text)
        {
            List<byte> code = new List<byte>();

            foreach (string line in text.Split('\n'))
            {
                if (line.Length == 0)
                    continue;

                string command = line.Substring(0, 3);
                string args = line.Substring(3).Trim();
                switch (command)
                {
                    case "ext":
                        code.Add((byte)Processor.Command_Type.ext);
                        if (args.Length == 0)
                            continue;
                        break;

                    case "msg":
                        code.Add((byte)Processor.Command_Type.msg);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 1 more argument!");
                        break;
                    case "str":
                        code.Add((byte)Processor.Command_Type.str);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 2 more argument!");
                        break;
                    case "num":
                        code.Add((byte)Processor.Command_Type.num);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 2 more argument!");
                        break;

                    case "rm ":
                        code.Add((byte)Processor.Command_Type.rm);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 2 more argument!");
                        break;
                    case "wm ":
                        code.Add((byte)Processor.Command_Type.wm);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 2 more argument!");
                        break;
                    case "rd ":
                        code.Add((byte)Processor.Command_Type.rd);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 2 more argument!");
                        break;
                    case "wd ":
                        code.Add((byte)Processor.Command_Type.wd);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 2 more argument!");
                        break;


                    case "jmp":
                        code.Add((byte)Processor.Command_Type.jmp);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 1 more argument!");
                        break;
                    case "je ":
                        code.Add((byte)Processor.Command_Type.je);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 2 more argument!");
                        break;
                    case "jw ":
                        code.Add((byte)Processor.Command_Type.jw);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 2 more argument!");
                        break;
                    case "js ":
                        code.Add((byte)Processor.Command_Type.js);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 2 more argument!");
                        break;
                    case "jcf":
                        code.Add((byte)Processor.Command_Type.jcf);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 2 more argument!");
                        break;
                    case "jcb":
                        code.Add((byte)Processor.Command_Type.jcb);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 2 more argument!");
                        break;

                    case "set":
                        code.Add((byte)Processor.Command_Type.set);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 2 more argument!");
                        break;
                    case "mov":
                        code.Add((byte)Processor.Command_Type.mov);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 2 more argument!");
                        break;
                    case "not":
                        code.Add((byte)Processor.Command_Type.not);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 1 more argument!");
                        break;
                    case "and":
                        code.Add((byte)Processor.Command_Type.and);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 2 more argument!");
                        break;
                    case "or":
                        code.Add((byte)Processor.Command_Type.or);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 2 more argument!");
                        break;
                    case "xor":
                        code.Add((byte)Processor.Command_Type.xor);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 2 more argument!");
                        break;
                    case "shl":
                        code.Add((byte)Processor.Command_Type.shl);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 2 more argument!");
                        break;
                    case "shr":
                        code.Add((byte)Processor.Command_Type.shr);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 2 more argument!");
                        break;

                    case "cmp":
                        code.Add((byte)Processor.Command_Type.cmp);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 2 more argument!");
                        break;
                    case "mor":
                        code.Add((byte)Processor.Command_Type.mor);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 2 more argument!");
                        break;
                    case "les":
                        code.Add((byte)Processor.Command_Type.les);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 2 more argument!");
                        break;

                    case "neg":
                        code.Add((byte)Processor.Command_Type.neg);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 1 more argument!");
                        break;
                    case "add":
                        code.Add((byte)Processor.Command_Type.add);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 2 more argument!");
                        break;
                    case "sub":
                        code.Add((byte)Processor.Command_Type.sub);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 2 more argument!");
                        break;
                    case "mul":
                        code.Add((byte)Processor.Command_Type.mul);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 2 more argument!");
                        break;
                    case "div":
                        code.Add((byte)Processor.Command_Type.div);
                        if (args.Length == 0)
                            throw new Exception($"{command} need 2 more argument!");
                        break;
                    default:
                        throw new Exception($"Uncnown command: {command}!");
                }

                for (int i = 0; i < 2; i++)
                {
                    // Register parsing
                    byte data = 0x00;
                    bool is_register = true;
                    if (args.Length < 2)
                    {
                        is_register = false;
                    }
                    else
                    switch (args.Substring(0, 2))
                    {
                        case "IP":
                            data = 0x00;
                            break;
                        case "DP":
                            data = 0x01;
                            break;
                        case "CX":
                            data = 0x02;
                            break;
                        case "R0":
                            data = 0x03;
                            break;
                        case "R1":
                            data = 0x04;
                            break;
                        case "R2":
                            data = 0x05;
                            break;
                        case "R3":
                            data = 0x06;
                            break;
                        case "R4":
                            data = 0x07;
                            break;
                        case "R5":
                            data = 0x08;
                            break;
                        case "R6":
                            data = 0x09;
                            break;
                        case "R7":
                            data = 0x0A;
                            break;
                        default:
                            is_register = false;
                            break;
                    }
                    if (is_register)
                    {
                        if (i == 1)
                        {
                            code[code.Count - 1] |= data;
                        }
                        else
                        {
                            code.Add((byte)(data << 4));
                            if (args.Length <= 3)
                                break;
                            args = args.Substring(3);
                        }
                        continue;
                    }

                    // Hex parsing
                    if (args.StartsWith("0x"))
                    {
                        string value = args.Split(' ')[0];
                        int len = value.Length;
                        value = value.Substring(2).Replace("_", "");

                        if (value.Length < 1)
                            throw new Exception("Hex value is to short!");
                        if (value.Length == 1)
                        {
                            data = byte.Parse(value, NumberStyles.HexNumber);
                            if (i == 1)
                                code[code.Count - 1] |= data;
                            else
                                code.Add((byte)(data << 4));
                            args = args.Substring(len + 1);
                            continue;
                        }

                        if (value.Length <= 2 * 1)
                        {
                            if (i == 1)
                                code[code.Count - 1] |= 0x01;
                            else
                                code.Add(0x01);
                            code.Add(byte.Parse(value, NumberStyles.HexNumber));
                            break;
                        }

                        if (value.Length <= 2 * 2)
                        {
                            if (i == 1)
                                code[code.Count - 1] |= 0x02;
                            else
                                code.Add(0x02);
                            code.AddRange(BitConverter.GetBytes(short.Parse(value, NumberStyles.HexNumber)));
                            break;
                        }

                        if (value.Length <= 2 * 4)
                        {
                            if (i == 1)
                                code[code.Count - 1] |= 0x04;
                            else
                                code.Add(0x04);
                            code.AddRange(BitConverter.GetBytes(int.Parse(value, NumberStyles.HexNumber)));
                            break;
                        }

                        if (value.Length <= 2 * 8)
                        {
                            if (i == 1)
                                code[code.Count - 1] |= 0x08;
                            else
                                code.Add(0x08);
                            code.AddRange(BitConverter.GetBytes(long.Parse(value, NumberStyles.HexNumber)));
                            break;
                        }

                        throw new Exception("Hex value is too long!");
                    }

                    // String parsing
                    if (args[0] == '"')
                    {
                        if (args.Last() != '"')
                            throw new Exception("Unclosed '\"' !");
                        if (args.Length > 8 + 2)
                            throw new Exception("String is too long!");
                        args = args.Replace(@"\n", "\n").Replace(@"\0", "\0").Replace(@"\t", "\t");
                        data = (byte)(args.Length - 2);
                        if (i == 1)
                            code[code.Count - 1] |= data;
                        else
                            code.Add(data);
                        code.AddRange(Encoding.UTF8.GetBytes(args[1..^1]));
                        break;
                    }

                    if (long.TryParse(args, out long long_number))
                    {
                        if (long_number > sbyte.MinValue && long_number < sbyte.MaxValue)
                        {
                            if (i == 1)
                                code[code.Count - 1] |= 0x01;
                            else
                                code.Add(0x01);
                            code.Add((byte)long_number);
                            break;
                        }

                        if (long_number > short.MinValue && long_number < short.MaxValue)
                        {
                            if (i == 1)
                                code[code.Count - 1] |= 0x02;
                            else
                                code.Add(0x02);
                            code.AddRange(BitConverter.GetBytes((short)long_number));
                            break;
                        }

                        if (long_number > int.MinValue && long_number < int.MaxValue)
                        {
                            if (i == 1)
                                code[code.Count - 1] |= 0x04;
                            else
                                code.Add(0x04);
                            code.AddRange(BitConverter.GetBytes((int)long_number));
                            break;
                        }

                        if (i == 1)
                            code[code.Count - 1] |= 0x08;
                        else
                            code.Add(0x08);
                        code.AddRange(BitConverter.GetBytes(long_number));
                        break;
                    }

                    throw new Exception($"Unknown data fromat {args}!");
                }
            }

            return code.ToArray();
        }

        private void New_TSMI_Click(object sender, EventArgs e)
        {
            Main_RTB.Clear();
            FileName = null;
        }

        private void Open_TSMI_Click(object sender, EventArgs e)
        {
            if (open_file_dialoge.ShowDialog() == DialogResult.OK)
            {
                byte[] data = OS.Read_DISK(open_file_dialoge.File_Address!.Value*256, open_file_dialoge.File_Size!.Value);
                FileName = open_file_dialoge.File_Name;
                filetype = open_file_dialoge.File_Type;
                Main_RTB.Clear();
                switch (open_file_dialoge.File_Type!.Value)
                {
                    case 1:
                        for (int i = 0; i < data.Length; i++)
                        {
                            byte value = data[i];
                            Main_RTB.Text += 
                                $"{value >> 7}{value >> 6 & 0b_1 }{value >> 5 & 0b_1}{value >> 4 & 0b_1}_" +
                                $"{value >> 3 & 0b_1}{value >> 2 & 0b_1}{value >> 1 & 0b_1}{value & 0b_1} ";
                            if ((i + 1) % 8 == 0)
                                Main_RTB.Text = Main_RTB.Text.Trim() + '\n';
                        }
                        Main_RTB.Text = Main_RTB.Text.Trim();
                        break;
                    case 2:
                        foreach (byte b in data)
                            Main_RTB.Text += ((char)b).ToString();
                        break;
                }
            }
        }

        private void SaveAs_TSMI_Click(object sender, EventArgs e)
        {
            if (sender == SaveAs_TSMI)
                FileName = null;
            if (FileName is null)
            {
                if (string_dialog.ShowDialog("Сохранить?", "Введите название файла:") == DialogResult.OK)
                    FileName = string_dialog.Result;
                else
                    return;
            }
            if (filetype is null)
            {
                if (decimal_dialog.ShowDialog("Сохранить?", "Выберите тип:", 1, 2) == DialogResult.OK)
                    filetype = (byte)decimal_dialog.Result!.Value;
                else
                    return;
            }
            List<byte> data = new();
            switch (filetype)
            {
                case 1:
                    var text = Main_RTB.Text.Replace("_", "").Split('\n', ' ');
                    foreach (string word in text)
                    {
                        byte b = word[0] == '0' ? (byte)0 : (byte)1;
                        foreach (char c in word[1..])
                        {
                            b <<= 1;
                            b |= c == '0' ? (byte)0 : (byte)1;
                        }
                        data.Add(b);
                    }
                    break;
                case 2:
                    foreach (char c in Main_RTB.Text)
                        data.Add((byte)c);
                    break;
            }
            try
            {
                OS.Remove_File(FileName!);
            }
            catch { }
            OS.Save_File(new(FileName!, filetype!.Value, data.ToArray()));
        }

        private void Build_TSMI_Click(object sender, EventArgs e)
        {
            string? filename = FileName is null ? null : FileName.Split('.')[0] + ".exe";
            if (sender == Build_TSMI)
                filename = null;
            if (filename is null)
            {
                if (string_dialog.ShowDialog("Собрать?", "Введите название файла:") == DialogResult.OK)
                    filename = string_dialog.Result;
                else
                    return;
            }
            try
            {
                byte[] data = Compile(Main_RTB.Text);
                try
                {
                    OS.Remove_File(filename!);
                }
                catch { }
                OS.Save_File(new(filename!, 1, data.ToArray()));
                MessageBox.Show("Сборка прошла успешно!");
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
                Debug.WriteLine(exception.StackTrace);
            }
        }

        private void IDE_From_Shown(object sender, EventArgs e)
        {
            FileName = null;
            Main_RTB.Clear();
        }
    }
}
