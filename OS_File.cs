using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Demo
{
    public struct OS_File
    {
        public readonly string Name;
        public readonly byte Type;
        public readonly byte[] Data;

        public OS_File(string name, byte type, byte[] data)
        {
            Name = name;
            Type = type;
            Data = data;
        }
    }
}
