using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ProjectAnalyzier.Core
{
    public class Counting
    {
        public int countClasses { get; set; } = 0;
        public int countInterfaces { get; set; } = 0;
        public int countEnums { get; set; } = 0;
        public int countFilesAndDirectories
        {
            get
            {
                return Directory.GetFiles(path, "*", SearchOption.AllDirectories).Length;
            }

        }

        private string path = "";
        public Counting(string path)
        {
            this.path = path;
        }

        public void pathView()
        {
            var allfolders = Directory.GetDirectories(path);
            var allfile = Directory.GetFiles(path);


            foreach (var folder in allfolders)
            {
                pathView(folder);
            }

            foreach (var file in allfile)
            {
                if (file.Contains(".cs") && !file.Contains(".csproj"))
                {
                    countObject(file);
                }
            }
        }

        private void pathView(string path)
        {
            var allfolders = Directory.GetDirectories(path);
            var allfile = Directory.GetFiles(path);

            foreach (var folder in allfolders)
            {
                pathView(folder);
            }

            foreach (var file in allfile)
            {
                if (file.Contains(".cs") && !file.Contains(".csproj"))
                {
                    countObject(file);
                }
            }
        }

        public void countObject(string path)
        {
            string toSeOne = File.ReadAllText(path);
            string pattern = @"(private|private protected|protected|internal|protected internal|public|partial|^|\s)\sclass\s";
            MatchCollection matches = (Regex.Matches(toSeOne, pattern));
            var thisCountClass = matches.Count;
            countClasses += thisCountClass;

            string toSeeInterface = File.ReadAllText(path);
            string patternInterface = @"(public|^|\s)\sinterface\s";
            MatchCollection matchesInterface = (Regex.Matches(toSeeInterface, patternInterface));
            var thisCountInterface = matchesInterface.Count;
            countInterfaces += thisCountInterface;

            string toSeeEnum = File.ReadAllText(path);
            string patternEnum = @"(public|private|^|\s)\senum\s";
            MatchCollection matchesEnum = (Regex.Matches(toSeeEnum, patternEnum));
            var thisCountEnums = matchesEnum.Count;
            countEnums += thisCountEnums;
        }
    }
}
