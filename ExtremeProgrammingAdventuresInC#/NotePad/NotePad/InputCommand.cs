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
            var line = _reader.ReadLine();
            while (!string.IsNullOrWhiteSpace(line)  && line != "*end")
            {
                _lines.Add(line.TrimEnd());
                line = _reader.ReadLine();
            }

            var result = CleanTheLines();
            return result;
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
    }
}