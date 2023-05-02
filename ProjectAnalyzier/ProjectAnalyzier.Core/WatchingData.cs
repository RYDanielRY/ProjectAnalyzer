using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectAnalyzier.Core
{
    public class WatchingData
    {
        public void OnWatch(Counting counting)
        {
            if (counting.IsFilesAndDirectoriesExist)
            {
                Console.WriteLine($"Количество классов: {counting.Classes}");
                Console.WriteLine($"Количество интерфейсов: {counting.Interfaces}");
                Console.WriteLine($"Количество enums: {counting.Enums}");
                Console.WriteLine($"Количество файлов: {counting.Files}");
                Console.WriteLine($"Количество папок: {counting.Directories}");
            }
            else
            {
                Console.WriteLine("Директория пуста");
            }
            Console.ReadKey();
        }
    }
}
