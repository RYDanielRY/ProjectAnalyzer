using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ProjectAnalizer.Core
{
    public class Counting
    {
        public int countClasses = 0;
        public int countInterfaces = 0;
        public int countEnums = 0;

        public void Watch()
        {
            Console.WriteLine($"Количество классов: {countClasses}");
            Console.WriteLine($"Количество интерфейсов: {countInterfaces}");
            Console.WriteLine($"Количество enums: {countEnums}");
            Console.ReadKey(); 
        }

        public void pathView(string path)
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
