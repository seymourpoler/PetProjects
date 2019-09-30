using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NotePad
{
    public class InputCommand
    {
        private readonly StringReader _reader;
        private IList<string> _lines;
        
        public InputCommand(StringReader reader)
        {
            _reader = reader;
            _lines = new List<string>();
        }

        public string[] CleanLines()
        {
            ReadLines(_reader);
            var result = CleanTheLines();
            return result;
        }

        void ReadLines(StringReader reader)
        {
            var line  = _reader.ReadLine();
            while (!string.IsNullOrWhiteSpace(line)  && line != "*end")
            {
                _lines.Add(line.TrimEnd());
                line = _reader.ReadLine();
            }
            reader.Close();
        }
        
        string[] CleanTheLines()
        {
            IList<string> result = new List<string>();
            foreach (var line in _lines)
            {
                result.Add(CleanTheLine(line));
            }

            return result.ToArray();
        }

        string CleanTheLine(string dirty)
        {
            var result = dirty.Replace("|", "");
            return result;
        }

        public int SelectionStart()
        {
            int charactersSoFar = 0;
            foreach (var line in _lines)
            {
                var index = line.IndexOf("|");
                if (index != -1)
                {
                    return charactersSoFar + index;
                }
                charactersSoFar += line.Length + Environment.NewLine.Length;
            }

            return charactersSoFar;
            var result = charactersSoFar - Environment.NewLine.Length;
            return result;
        }
    }
}