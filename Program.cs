using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions; 

namespace ConsoleApp61
{
    class Program
    {
        static void Main(string[] args)
        {
            //Classes
            string toSeOne = File.ReadAllText(@"C:\Users\Daniil\source\repos\ConsoleApp61\Program.cs");
            string pattern = @"(private|private protected|protected|internal|protected internal|public|partial|\s)\sclass\s"; 
            MatchCollection matches = (Regex.Matches(toSeOne, pattern));
            var a = matches.Count;           
            Console.WriteLine($"Найдено классов: {a}");

            //Interfaces
            string toSeeInterface = File.ReadAllText(@"C:\Users\Daniil\source\repos\ConsoleApp61\Program.cs");
            string patternInterface = @"(public|\s)\sinterface\s";
            MatchCollection matchesInterface = (Regex.Matches(toSeeInterface, patternInterface));
            var countInterface = matchesInterface.Count;
            Console.WriteLine($"Найдено интерфейсов: {countInterface}");

            //Enums
            string toSeeEnum = File.ReadAllText(@"C:\Users\Daniil\source\repos\ConsoleApp61\Program.cs");
            string patternEnum = @"(public|private|\s)\senum\s";
            MatchCollection matchesEnum = (Regex.Matches(toSeeEnum, patternEnum));
            var countEnums = matchesEnum.Count;
            Console.WriteLine($"Найдено enums: {countEnums}");
        }
    }
}
