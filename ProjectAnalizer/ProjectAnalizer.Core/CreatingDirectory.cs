using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectAnalizer.Core
{
    public class CreatingDirectory
    {
        public void Create(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
                Console.WriteLine("Директория создана. Скопируйте проект для анализа");
                Console.ReadKey(); 
            }
            else
            {
                Counting counting = new Counting();
                counting.pathView(path); 
                counting.Watch(); 
            }
        }
    }
}
