namespace OS_Demo
{
    public static class Extentions
    {
        public static (byte[] before, byte[] target, byte[] after) Get_Block(this byte[] source, int address, int size)
        {
            return (source.Take(address).ToArray(), source.Skip(address).Take(size).ToArray(), source.Skip(address + size).ToArray());
        }
    }
    
}
