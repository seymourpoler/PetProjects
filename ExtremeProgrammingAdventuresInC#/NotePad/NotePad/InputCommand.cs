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

            return _lines.ToArray();
        }
    }
}