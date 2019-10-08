using System;
using System.Collections.Generic;
using System.IO;

namespace NotePad
{
    public class InputCommand
    {
        private IList<string> _lines;
        
        public InputCommand(StringReader reader)
        {
            _lines = new List<string>();
            ReadLines(reader);
        }

        public string[] CleanLines()
        {
            var result = new List<string>();
            foreach (var line in _lines)
            {
                result.Add(CleanLine(line));
            }
            return result.ToArray();
        }

        void ReadLines(StringReader reader)
        {
            var line  = reader.ReadLine();
            while (!string.IsNullOrWhiteSpace(line)  && line != "*end")
            {
                _lines.Add(line.TrimEnd());
                line = reader.ReadLine();
            }
            reader.Close();
        }

        string CleanLine(string dirty)
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