using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectAnalyzier.Core
{
    public class WatchingData
    {
        public void OnWatch(Counting counting)
        {
            Console.WriteLine($"Количество классов: {counting.countClasses}");
            Console.WriteLine($"Количество интерфейсов: {counting.countInterfaces}");
            Console.WriteLine($"Количество enums: {counting.countEnums}");
            Console.WriteLine($"Количество файлов и папок: {counting.countFilesAndDirectories}");
            Console.ReadKey();
        }
    }
}
