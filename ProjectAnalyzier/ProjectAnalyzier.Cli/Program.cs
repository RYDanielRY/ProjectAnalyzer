using ProjectAnalyzier.Core;
using System;
using System.IO;

namespace ProjectAnalyzier.Cli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                var standartPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input");

                DirectoryInfo directoryInfo = new DirectoryInfo(standartPath);

                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                    Console.WriteLine("Директория создана. Скопируйте файлы для анализа");
                    Console.ReadKey();
                }
                else
                {
                    var userPath = standartPath;
                    Counting counting = new Counting(userPath);
                    counting.Analize();
                    WatchingData watchingData = new WatchingData();
                    watchingData.OnWatch(counting);
                }
                return;
            }
            else
            {
                switch (args[0])
                {
                    case "-dir" when args.Length == 2:
                        var userPath = args[1];
                        Counting counting = new Counting(userPath);
                        counting.Analize();
                        WatchingData watchingData = new WatchingData();
                        watchingData.OnWatch(counting);
                        break;
                }
            }
        }
    }
}
