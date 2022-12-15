using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace OS_Demo
{
    public static class OS
    {
        private static byte[] RAM = new byte[64 * 1024];
        private static byte[] DISK = new byte[16 * 1024 * 1024];
        private static Processor _processor = new();
        private static RAM_Controller _ram_controller = new();
        private static DISK_Controller _disk_controller = new();

        private static Message_Dialoge Message_Dialoge = new();
        private static Decimal_Dialog Decimal_Dialog = new();
        private static String_Dialog String_Dialog = new();

        private const int max_files_count = 6_400;
        private const int max_process_count = 256;
        private static int ordered_pages_count = 0;
        private static uint dialoge_time;
        private static int? curent_process_id;

        private const int rpt_row_size = 7;
        private const int dpt_row_size = 25;

        private static bool enabled;
        private static Thread? Main;


        public static void Init_Disk(OS_File[] files)
        {
            RAM = new byte[64 * 1024];
            DISK = new byte[16 * 1024 * 1024];

            int address = max_files_count;
            for (int i = 0; i < files.Length; i++)
            {
                OS_File file = files[i];
                List<byte> data = new() { file.Type };
                data.AddRange(BitConverter.GetBytes((ushort)address));
                data.AddRange(BitConverter.GetBytes((ushort)file.Data.Length));
                data.AddRange(Encoding.UTF8.GetBytes(file.Name));
                data.AddRange(new byte[20 - file.Name.Length]);
                Edit_DISK((ulong)i * dpt_row_size, data.ToArray());

                Edit_DISK((ulong)address * 256, file.Data);

                address += file.Data.Length / 256 + 1;
            }
            enabled = false;
        }

        public static void Save_File(OS_File file)
        {
            var table = Read_DISK(0, 256);
            List<int> ordered_pages = new(); 
            int index = 0;
            for (; index < 256; index+=25)
            {
                if (table[index] == 0)
                    break;

                var start_page = BitConverter.ToUInt16(table[(index + 1)..(index + 3)]);
                var size_data = table[(index + 3)..(index + 5)];
                var size = BitConverter.ToUInt16(size_data);
                var end_page = start_page + (int)Math.Ceiling(size / 256.0);
                for (int i = start_page; i < end_page; i++)
                    ordered_pages.Add(i);
            }
            ordered_pages.Sort();
            int needed_pages = (int)Math.Ceiling(file.Data.Length / 256.0);
            int address = max_files_count;
            int count = 0;
            for (int i = max_files_count; count < needed_pages && i < 65_536; i++)
            {
                if (ordered_pages.Contains(i))
                {
                    address = i + 1;
                    count = 0;
                    continue;
                }
                count++;
            }
            List<byte> data = new() { file.Type };
            data.AddRange(BitConverter.GetBytes((ushort)address));
            data.AddRange(BitConverter.GetBytes((ushort)file.Data.Length));
            data.AddRange(Encoding.UTF8.GetBytes(file.Name));
            data.AddRange(new byte[20 - file.Name.Length]);
            Edit_DISK((ulong)index, data.ToArray());

            Edit_DISK((ulong)address * 256, file.Data);
        }

        public static void Remove_File(string filename)
        {
            var table = Read_DISK(0, 256);
            for (int i = 0; i < 256; i += 25)
            {
                if (table[i] == 0)
                    throw new FileNotFoundException();
                string name = Encoding.UTF8.GetString(table, i + 5, 20).Replace("\0", "");
                if (name == filename)
                {
                    Edit_DISK((ulong)i, Read_DISK(i + 25, 256 - i + 25).Concat(new byte[25]).ToArray());
                    return;
                }
            }
        }

        public static void Start()
        {
            Main = new Thread(Process_Planer);
            enabled = true;
            Main.Start();
            _ram_controller.Show();
            _disk_controller.Show();
            _disk_controller.Invoke_Table_Update();
        }
        public static void Stop()
        {
            enabled = false;
            _ram_controller.Hide();
            _disk_controller.Hide();
        }

        private static void Process_Planer()
        {
            while (enabled)
            {
                if (curent_process_id is null)
                {
                    var pages = Get_Process_Pages().Where(p => p.number == 0);
                    if (pages.Any())
                    {
                        curent_process_id = pages.ElementAt(0).proc_id;
                        _processor.Load_Registers();
                    }
                }

                if (curent_process_id.HasValue)
                {
                    Thread.Sleep(500);
                    dialoge_time = 0;
                    DateTime start_time = DateTime.Now;
                    _processor.Execute_Command();
                    DateTime end_time = DateTime.Now;

                    if (_processor.JF == false)
                    {
                        _processor.IP += 2;
                        _processor.JF = false;
                    }
                    else
                    {
                        _processor.JF = false;
                    }

                    var pages = Get_Process_Pages().ToList();
                    if (pages.Count == 0)
                        continue;

                    var curent_page = curent_process_id is not null 
                        ? pages.First(p => p.number == 0 && p.proc_id == curent_process_id) 
                        : pages.First(p => p.number == 0);
                    int index = pages.IndexOf(curent_page);
                    if (curent_process_id is not null)
                    {
                        // Add work time
                        uint work_time = (uint)Math.Ceiling((end_time - start_time).TotalMilliseconds - dialoge_time);
                        uint total_time = BitConverter.ToUInt16(Read_RAM(index * rpt_row_size + 2, 4)) + work_time;
                        Edit_RAM(index * rpt_row_size + 2, BitConverter.GetBytes(total_time));
                        _ram_controller.Invoke_Table_Update();
                    }

                    int min_i = index;
                    uint min_time = BitConverter.ToUInt16(Read_RAM(index * rpt_row_size + 2, 4));
                    for (int i = 0; i < pages.Count; i++)
                    {
                        if (pages[i].number != 0)
                            continue;
                        if (i == index)
                            continue;

                        uint time = BitConverter.ToUInt16(Read_RAM(i * rpt_row_size + 2, 4));
                        if (time < min_time)
                        {
                            min_time = time;
                            min_i = i;
                        }    
                    }
                    var p_id = pages[min_i].proc_id;

                    if (p_id != curent_process_id)
                    {
                        if (curent_process_id is not null)
                            _processor.Save_Registers();
                        index = curent_process_id ?? 0;
                        curent_process_id = p_id;
                        _processor.Load_Registers();
                    }
                }
            }
        }

        private struct File_Data
        {
            public readonly byte Type;
            public readonly ushort Address;
            public readonly ushort Size;
            public readonly string Name;

            public File_Data(byte type, ushort address, ushort size, string name)
            {
                Type = type;
                Address = address;
                Size = size;
                Name = name;
            }
        }

        private static (byte address, byte proc_id, byte number)[] Get_Process_Pages()
        {
            var process_table = RAM.Take(max_process_count * rpt_row_size);
            IEnumerable<(byte address, byte proc_id, byte number)> process_pages = Array.Empty<(byte address, byte proc_id, byte number)>();
            for (int i = 0; i < max_process_count; i++)
            {
                // Таблица закончилась
                if (process_table.ElementAt(0) == 0)
                {
                    ordered_pages_count = i;
                    break;
                }

                process_pages = process_pages.Append((process_table.ElementAt(6), process_table.ElementAt(0), process_table.ElementAt(1)));
                
                process_table = process_table.Skip(rpt_row_size);
            }
            return process_pages.OrderBy(p => p.proc_id).ThenBy(p => p.number).ToArray();
        }

        private static (byte[] process_table, byte[] free_spases) Get_Free_RAM_Data()
        {
            var process_table = RAM.Take(max_process_count * rpt_row_size);
            var free_address = new byte[max_process_count - rpt_row_size];
            var free_spases = new byte[max_process_count-1];
            for (int i = 1; i < max_process_count; i++)
            {
                free_spases[i-1] = (byte)i;
                if (i >= rpt_row_size)
                    free_address[i - rpt_row_size] = (byte)i;
            }
            for (int i = 0; i < max_process_count; i++)
            {
                // Таблица закончилась
                if (process_table.ElementAt(0) == 0)
                {
                    ordered_pages_count = i;
                    break;
                }

                // Страница с этим адресом занята
                free_address = free_address.Where(a => a != process_table.ElementAt(6)).ToArray();
                // Это адресное пространство занято
                free_spases = free_spases.Where(a => a != process_table.ElementAt(0)).ToArray();
                // Следующая строка
                process_table = process_table.Skip(rpt_row_size);
            }
            return (free_address, free_spases);
        }

        private static File_Data? Get_File_Data(string file_name)
        {
            var file_table = DISK.Take(max_files_count * dpt_row_size);
            for (int i = 0; i < max_files_count; i++)
            {
                byte[] file_data = file_table.Take(dpt_row_size).ToArray();

                byte type = file_data[0];
                if (file_data[0] == 0)
                    return null;

                string name = Encoding.UTF8.GetString(file_data, 5, 20).Replace("\0", "");
                var address = BitConverter.ToUInt16(file_data, 1);
                var size = BitConverter.ToUInt16(file_data, 3);
                if (name == file_name)
                    return new
                    (
                        type,
                        address,
                        size,
                        name
                    );


                file_table = file_table.Skip(dpt_row_size);
            }
            return null;
        }

        public static void StartProcess(string file_name)
        {
            (byte[] free_pages, byte[] free_spaces) = Get_Free_RAM_Data();
            if (free_pages.Length == 0)
            {
                Message_Dialoge.Show_Message("Нет места!");
                return;
            }

            if (Get_File_Data(file_name) is File_Data file)
            {
                // Это точно исполняемый файл
                if (file.Type != 1)
                    throw new FileFormatException();

                // Извлекаем исходный код с диска
                int count = file.Size > Processor.IP_MAX ? (int)Processor.IP_MAX : file.Size;
                var code = DISK.Skip(file.Address * 256).Take(count);


                // Обновляем таблицу и заполняем страницу процесса
                Edit_RAM(free_pages[0] * 256, 
                    new byte[Processor.CS]
                    .Concat(code)
                    .Concat(new byte[256 - Processor.CS - code.Count()]).ToArray());
                Edit_RAM(free_pages[1] * 256, new byte[256]);

                // Добавляем в таблицу страниц новую запись
                int row_start = ordered_pages_count * rpt_row_size;
                byte[] data = new byte[7];
                data[0] = free_spaces[0];
                data[1] = 0;
                data[6] = free_pages[0];
                Edit_RAM(row_start, data);

                // Занимаем 1 страницу для данных
                row_start += rpt_row_size;
                data[0] = free_spaces[0];
                data[1] = 1;
                data[6] = free_pages[1];
                Edit_RAM(row_start, data);

                // Теперь занята ещё 2 страницы
                ordered_pages_count +=2;
            }
            else
                throw new FileNotFoundException();
        }

        public static void Close_Process(long code)
        {
            var process_table = RAM.Take(max_process_count * 5);
            IEnumerable<byte> result_table = Array.Empty<byte>();
            const int table_size = 256 * rpt_row_size;
            bool process_deleted = false;
            for (int i = 0; i < table_size; i++)
            {
                // Таблица закончилась
                if (process_table.ElementAt(i * rpt_row_size + 0) == 0)
                {
                    break;
                }

                // Чужая страница
                if (process_table.ElementAt(i * rpt_row_size + 0) != curent_process_id)
                {
                    result_table = result_table.Concat(process_table
                        .Skip(rpt_row_size * i)
                        .Take(rpt_row_size)
                        );
                    continue;
                }

                ordered_pages_count--;
                process_deleted = true;
            }
            if (process_deleted)
            {
                curent_process_id = null;
                // Обновляем таблицу
                Edit_RAM(0, result_table.Concat(new byte[table_size - result_table.Count()]).ToArray());
            }
            else
                throw new Exception("Process not found!");
        }

        public static long Read_From_Disk(long address)
        {
            return BitConverter.ToInt64(Read_DISK((int)address, 8));
        }


        public static long Read_From_Memory(long address)
        {
            var pages = Get_Process_Pages().Where(p => p.proc_id == curent_process_id);
            int page_num = (int)(address / 256);
            if (page_num > pages.Count() - 1)
                throw new Exception("Process has no access to this page!");
            var process_page_address = pages.ElementAt(page_num).address * 256;
            int start = (int)(process_page_address + address % 256);
            return BitConverter.ToInt64(Read_RAM(start, 8));
        }


        public static void Write_In_Disk(ulong register, long address)
        {
            byte[] data = BitConverter.GetBytes(register);
            Edit_DISK((ulong)address, data);
        }


        public static void Write_In_Memory(byte register, long address)
        {
            var pages = Get_Process_Pages().Where(p => p.proc_id == curent_process_id);
            int page_num = (int)(address / 256);
            if (page_num > pages.Count() - 1)
                throw new Exception("Process has no access to this page!");
            var process_page_address = pages.ElementAt(page_num).address * 256;
            int start = (int)(process_page_address + address % 256);
            Edit_RAM(start, new byte[] { register });
        }

        public static void Write_In_Memory(long register, long address)
        {
            byte[] data = BitConverter.GetBytes(register);
            var pages = Get_Process_Pages().Where(p => p.proc_id == curent_process_id);
            int page_num = (int)(address / 256);
            if (page_num > pages.Count() - 1)
                throw new Exception("Process has no access to this page!");
            var process_page_address = pages.ElementAt(page_num).address * 256;
            int start = (int)(process_page_address + address % 256);
            Edit_RAM(start, data);
        }

        private static string Get_Message(long msg_address)
        {
            var pages = Get_Process_Pages().Where(p => p.proc_id == curent_process_id);
            int page_num = (int)(msg_address / 256);
            if (page_num > pages.Count() - 1)
                throw new Exception("Process has no access to this page!");
            var process_page_address = pages.ElementAt(page_num).address * 256;
            int start = (int)(process_page_address + msg_address % 256);
            int len = RAM[start];
            if (Math.Ceiling((msg_address + len) / 256.0) > pages.Count())
                throw new Exception("Process has no access to this page!");

            List<byte> data = new();
            for (int i = ((int)msg_address + 1) % 256, page = page_num; ; i++)
            {
                if (i >= 256)
                {
                    i = 0;
                    page++;
                }
                int index = pages.First(p => p.number == page).address * 256 + i;
                data.Add(RAM[index]);
                if (data.Count >= len)
                    break;
            }
            string msg = "";
            for (int i = 0; i < len; i++)
            {
                int type = data[i++];
                int count = data[i++];
                if (type == 1)
                {
                    for (int j = 0; j < count; j++)
                    {
                        msg += ((char)data[i + j]).ToString();
                    }
                }
                else if (type == 2)
                {
                    switch (count)
                    {
                        case 1:
                            msg += data[i].ToString();
                            break;
                        case 2:
                            msg += BitConverter.ToInt16(new byte[] { data[i], data[i + 1] }).ToString();
                            break;
                        case 4:
                            msg += BitConverter.ToInt32(new byte[] { data[i], data[i + 1], data[i + 2], data[i + 3] }).ToString();
                            break;
                        case 8:
                            msg += BitConverter.ToInt64(new byte[] { data[i], data[i + 1], data[i + 2], data[i + 3], data[i + 4], data[i + 5], data[i + 6], data[i + 7] }).ToString();
                            break;
                    }
                }
                i += count - 1;

            }
            return msg;
        }

        public static void Show_Message(long msg_address)
        {
            DateTime start_time = DateTime.Now;

            string msg = Get_Message(msg_address);
            Message_Dialoge.Show_Message(msg);

            DateTime end_time = DateTime.Now;
            dialoge_time += (uint)(end_time - start_time).TotalMilliseconds;
        }

        public static void Show_String_Dialoge(long msg_address, long address_for_result)
        {
            DateTime start_time = DateTime.Now;

            string msg = Get_Message(msg_address);
            if (String_Dialog.ShowDialog("Введите строку", msg) == DialogResult.OK)
            {
                var pages = Get_Process_Pages().Where(p => p.proc_id == curent_process_id);
                int page_num = (int)(address_for_result / 256);
                if (page_num > pages.Count() - 1)
                    throw new Exception("Process has no access to this page!");
                var process_page_address = pages.ElementAt(page_num).address * 256;
                int start = (int)(process_page_address + address_for_result % 256);
                var data = Encoding.UTF8.GetBytes(String_Dialog.Result!);
                Edit_RAM(start, data);
                _processor.CX = data.Length;
                _processor.SF = true;
            }

            DateTime end_time = DateTime.Now;
            dialoge_time += (uint)(end_time - start_time).TotalMilliseconds;
        }

        public static void Show_Integer_Dialoge(long msg_address, long address_for_result)
        {
            DateTime start_time = DateTime.Now;

            string msg = Get_Message(msg_address);
            if (Decimal_Dialog.ShowDialog("Введите число", msg, 0, 256) == DialogResult.OK)
            {
                var pages = Get_Process_Pages().Where(p => p.proc_id == curent_process_id);
                int page_num = (int)(address_for_result / 256);
                if (page_num > pages.Count() - 1)
                    throw new Exception("Process has no access to this page!");
                var process_page_address = pages.ElementAt(page_num).address * 256;
                int start = (int)(process_page_address + address_for_result % 256);
                var data = BitConverter.GetBytes((long)Decimal_Dialog.Result!);
                Edit_RAM(start, data);
                _processor.CX = data.Length;
                _processor.SF = true;
            }

            DateTime end_time = DateTime.Now;
            dialoge_time += (uint)(end_time - start_time).TotalMilliseconds;
        }

        private static void Edit_RAM(int address, byte[] data)
        {
            for (int i = address, j = 0; j < data.Length; i++, j++)
            {
                RAM[i] = data[j];
            }

            DateTime start_time = DateTime.Now;

            if (address <= max_process_count)
            {
                _ram_controller.Invoke_Table_Update();
            }
            _ram_controller.InvokePages_Update(address, address + data.Length);

            DateTime end_time = DateTime.Now;
            dialoge_time += (uint)(end_time - start_time).TotalMilliseconds;
        }

        public static byte[] Read_RAM(int address, int size)
        {
            IEnumerable<byte> data = Array.Empty<byte>();
            for (int i = address; i < address + size; i++)
                data = data.Append(RAM[i]);
            return data.ToArray();
        }


        private static void Edit_DISK(ulong address, byte[] data)
        {
            for (ulong i = address, j = 0; j < (ulong)data.Length; i++, j++)
            {
                DISK[i] = data[j];
            }

            DateTime start_time = DateTime.Now;

            if (address <= max_files_count)
            {
                _disk_controller.Invoke_Table_Update();
            }
            _disk_controller.InvokePages_Update((int)address, (int)address + data.Length);

            DateTime end_time = DateTime.Now;
            dialoge_time += (uint)(end_time - start_time).TotalMilliseconds;
        }

        public static byte[] Read_DISK(int address, int size)
        {
            IEnumerable<byte> data = Array.Empty<byte>();
            for (int i = address; i < address + size; i++)
                data = data.Append(DISK[i]);
            return data.ToArray();
        }
    }
}
