using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ProjectAnalyzier.Core
{
    public class Counting
    {
        private string _path = "";
        private int _classes = 0;
        private int _interfaces = 0;
        private int _enums = 0;
        private int _files = 0;
        private int _directorys = 0;

        public Counting(string path)
        {
            this._path = path;
        }

        public int Classes
        {
            get
            {
                return _classes;
            }
        }

        public int Interfaces
        {
            get
            {
                return _interfaces;
            }
        }

        public int Enums
        {
            get
            {
                return _enums;
            }
        }

        public int Directories
        {
            get
            {
                return _directorys;
            }
        }

        public int Files
        {
            get
            {
                return _files;
            }
        }

        public bool IsFilesAndDirectoriesExist
        {
            get
            {
                return Directory.GetFiles(_path, "*", SearchOption.AllDirectories).Length > 0;
            }
        }

        public void Analize()
        {
            Analize(_path);
        }

        private void Analize(string path)
        {
            var allfolders = Directory.GetDirectories(path);
            var allfile = Directory.GetFiles(path);

            foreach (var folder in allfolders)
            {
                _directorys++;
                Analize(folder);
            }

            foreach (var file in allfile)
            {
                _files++;
                if (file.Contains(".cs") && !file.Contains(".csproj"))
                {
                    ProcessPath(file);
                }
            }
        }

        private void ProcessPath(string path)
        {
            string toSeOne = File.ReadAllText(path);
            string pattern = @"(private|private protected|protected|internal|protected internal|public|partial|^|\s)\sclass\s";
            MatchCollection matches = (Regex.Matches(toSeOne, pattern));
            var thisCountClass = matches.Count;
            _classes += thisCountClass;

            string toSeeInterface = File.ReadAllText(path);
            string patternInterface = @"(public|^|\s)\sinterface\s";
            MatchCollection matchesInterface = (Regex.Matches(toSeeInterface, patternInterface));
            var thisCountInterface = matchesInterface.Count;
            _interfaces += thisCountInterface;

            string toSeeEnum = File.ReadAllText(path);
            string patternEnum = @"(public|private|^|\s)\senum\s";
            MatchCollection matchesEnum = (Regex.Matches(toSeeEnum, patternEnum));
            var thisCountEnums = matchesEnum.Count;
            _enums += thisCountEnums;
        }
    }
}
