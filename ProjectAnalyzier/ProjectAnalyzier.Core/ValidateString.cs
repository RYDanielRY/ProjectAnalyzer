using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectAnalyzier.Core
{
    public class ValidateString
    {
        public string userPath { get; set; }

        public ValidateString(string userPath)
        {
            this.userPath = userPath;
        }

        public void OnValidate()
        {

            int countFilesAndDirectories = Directory.GetFiles(userPath, "*", SearchOption.AllDirectories).Length;
            if (countFilesAndDirectories == 0)
            {
                Console.WriteLine("Директория пустая");
                Console.ReadKey();
            }
            else
            {
                Counting counting = new Counting();
                counting.CountingFilesAndDirectories(userPath);
                counting.pathView(userPath);
                WatchingData watchingData = new WatchingData();
                watchingData.OnWatch(counting);
            }
        }
    }
}
