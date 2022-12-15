using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Demo
{
    public class Processor
    {
        public bool JF { get; set; }
        public bool EF { get; set; }
        public bool SF { get; set; }

        public const long CS = 93;
        public const long DS = 256;
        public const long IP_MAX = 163;
        public long IP
        {
            get => Registers[0];
            set
            {
                JF = true;
                if (value >= 0 && value <= IP_MAX == false)
                    throw new ArgumentOutOfRangeException(nameof(value));
                Registers[0] = value;
            }
        }
        public long DP 
        {
            get => Registers[1]; 
            set {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                Registers[1] = value;
            }
        }
        public long CX
        {
            get => Registers[2]; 
            set => Registers[2] = value;
        }

        private long[] Registers;

        public enum Command_Type
        {
            ext,

            msg,
            str,
            num,

            rm,
            wm,
            rd,
            wd,

            jmp,
            je,
            jw,
            js,
            jcf,
            jcb,

            set,
            mov,
            not,
            and,
            or,
            xor,

            shl,
            shr,

            cmp,
            mor,
            les,

            neg,
            add,
            sub,
            mul,
            div,
        }

        public Processor()
        {
            Registers = new long[11];
        }

        public void Save_Registers()
        {
            byte flags = 0b_00;
            if (EF)
                flags |= 0b_10;
            if (SF)
                flags |= 0b_01;
            OS.Write_In_Memory(flags, 0);

            for (int i = 0; i < Registers.Length; i++)
            {
                OS.Write_In_Memory(Registers[i], 1 + i * 8);
            }
        }

        public void Load_Registers()
        {
            byte flags = BitConverter.GetBytes(OS.Read_From_Memory(0))[0];
            SF = (flags & 0b_01) == 1;
            flags >>= 1;
            EF = (flags & 0b_01) == 1;

            for (int i = 0; i < Registers.Length; i++)
            {
                Registers[i] = OS.Read_From_Memory(1 + i * 8);
            }
        }

        public void Execute_Command()
        {
            var command = BitConverter.GetBytes(OS.Read_From_Memory(CS + IP)).Take(2).ToArray();

            var type = command[0];
            var arg1 = command[1] >> 4;
            var arg2 = command[1] & 0x0f;
            switch ((Command_Type)type)
            {
                case Command_Type.ext:
                    OS.Close_Process((byte)arg1);
                    break;

                case Command_Type.msg:
                    SF = false;
                    OS.Show_Message(DS + Registers[arg1]);
                    break;
                case Command_Type.str:
                    SF = false;
                    OS.Show_String_Dialoge(DS + Registers[arg1], DS + Registers[arg2]);
                    break;
                case Command_Type.num:
                    SF = false;
                    OS.Show_Integer_Dialoge(DS + Registers[arg1], DS + Registers[arg2]);
                    break;

                case Command_Type.rm:
                    {
                        var data = OS.Read_From_Memory(CS + IP + 2 - 8 + arg2);
                        data >>= (8 - arg2) * 8;
                        Registers[arg1] = OS.Read_From_Memory(DS + data);
                        IP += 2 + arg2;
                    }
                    break;
                case Command_Type.wm:
                    {
                        var data = OS.Read_From_Memory(CS + IP + 2 - 8 + arg2);
                        data >>= 8 * 7;
                        OS.Write_In_Memory(Registers[arg1], data + DS);
                        IP += 2 + arg2;
                    }
                    break;
                case Command_Type.rd:
                    Registers[arg1] = OS.Read_From_Disk(arg2);
                    break;
                case Command_Type.wd:
                    OS.Write_In_Disk((ulong)Registers[arg1], Registers[arg2]);
                    break;

                case Command_Type.jmp:
                    IP = command[1];
                    break;
                case Command_Type.je:
                    if (EF)
                        IP = command[1];
                    break;
                case Command_Type.js:
                    if (SF)
                    {
                        var data = OS.Read_From_Memory(CS + IP + 2 - 8 + arg2);
                        data >>= (8 - arg2) * 8;
                        IP = data;
                    }
                    break;

                case Command_Type.jcf:
                    if (CX < Registers[arg2])
                    {
                        CX++;
                        IP = Registers[arg1];
                    }
                    else
                        CX = 0;
                    break;
                case Command_Type.jcb:
                    if (Registers[arg2] < CX)
                    {
                        CX--;
                        IP = Registers[arg1];
                    }
                    else
                        CX = 0;
                    break;

                case Command_Type.set:
                    {
                        var data = OS.Read_From_Memory(CS + IP + 2 - 8 + arg2);
                        data >>= (8 - arg2) * 8;
                        Registers[arg1] = data;
                        IP += 2 + arg2;
                    }
                    break;
                case Command_Type.mov:
                    Registers[arg1] = Registers[arg2];
                    break;
                case Command_Type.not:
                    Registers[arg1] = ~Registers[arg1];
                    break;
                case Command_Type.and:
                    Registers[arg1] = Registers[arg1] & Registers[arg2];
                    break;
                case Command_Type.or:
                    Registers[arg1] = Registers[arg1] | Registers[arg2];
                    break;
                case Command_Type.xor:
                    Registers[arg1] = Registers[arg1] ^ Registers[arg2];
                    break;

                case Command_Type.shl:
                    {
                        var data = OS.Read_From_Memory(CS + IP + 2 - 8 + arg2);
                        data >>= (8 - arg2) * 8;
                        Registers[arg1] <<= (int)data;
                        IP += 2 + arg2;
                    }
                    break;
                case Command_Type.shr:
                    {
                        var data = OS.Read_From_Memory(CS + IP + 2 - 8 + arg2);
                        data >>= (8 - arg2) * 8;
                        Registers[arg1] >>= (int)data;
                        IP += 2 + arg2;
                    }
                    break;

                case Command_Type.cmp:
                    EF = Registers[arg1] == Registers[arg2];
                    break;
                case Command_Type.mor:
                    EF = Registers[arg1] > Registers[arg2];
                    break;
                case Command_Type.les:
                    EF = Registers[arg1] < Registers[arg2];
                    break;

                case Command_Type.neg:
                    Registers[arg1] = -Registers[arg1];
                    break;
                case Command_Type.add:
                    Registers[arg1] += Registers[arg2];
                    break;
                case Command_Type.sub:
                    Registers[arg1] -= Registers[arg2];
                    break;
                case Command_Type.mul:
                    Registers[arg1] = Registers[arg1] * Registers[arg2];
                    break;
                case Command_Type.div:
                    Registers[arg1] = Registers[arg1] / Registers[arg2];
                    break;
            }
        }
    }
}
