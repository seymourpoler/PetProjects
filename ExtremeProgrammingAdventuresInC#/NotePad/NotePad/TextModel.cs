using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NotePad
{
    public class TextModel
    {
        private List<string> lines;
        public String[] Lines
        {
            get { return lines.ToArray(); }
            set { lines.AddRange(value.ToList()); }
        }

        private int selectionStart;
        public int SelectionStart
        {
            get { return selectionStart; }
            set { selectionStart = value; }
        }

        public string TestText
        {
            get
            {
                var b = new StringBuilder();
                foreach (var s in lines)
                {
                    b.Append(s);
                    b.Append((System.Environment.NewLine));
                }

                b.Insert(SelectionStart, "|");
                return b.ToString();
            } 
        }

        public TextModel()
        {
            lines = new List<string>();
        }

        public void InsertParagraphTag()
        {
            var cursorLine = LineContainingCursor();
            lines.InsertRange(cursorLine + 1, NewParagraph());
            selectionStart = NewSelectionStart(cursorLine + 1, "<P>");
        }

        private int LineContainingCursor()
        {
            if (lines.Count == 0)
            {
                return -1;
            }
            int length = 0;
            int lineNr = 0;
            foreach (String line in lines)
            {
                if (length <= selectionStart && 
                    selectionStart <= length + line.Length + Environment.NewLine.Length)
                {
                    break;
                }

                length += line.Length + Environment.NewLine.Length;
                lineNr++;
            }

            return lineNr;
        }

        private List<string> NewParagraph()
        {
            return new List<string>
            {
                "<P></P>"
            };
        }

        public void Enter()
        {
            InsertParagraphTag();
        }

        public void SetLines(string[] lines)
        {
            Lines = lines;
        }

        public void ChangeToH2()
        {
            var oldLine = lines[LineContainingCursor()];    
            var r = new Regex("<(?<prefix>.*)>(?<body>.*)</(?<suffix>.*)>");    
            var m = r.Match(oldLine);    
            var newLine = "<H2>" + m.Groups["body"] + "</H2>";    
            lines[LineContainingCursor()] = newLine;
        }

        public void ControlS()
        {
            InsertSectionTags();
        }

        private void InsertSectionTags()
        {
            IEnumerable<string> NewSection = new[] {"<sect1><tittle></tittle>", "</sect1>" };
            
            int cursorLine = LineContainingCursor();
            lines.InsertRange(cursorLine + 1, NewSection);
            selectionStart = NewSelectionStart(cursorLine + 1, "<sect1><title>");
        }

        private int NewSelectionStart(int cursorLine, string tags)
        {
            var result = SumLineLengths(cursorLine) + tags.Length;
            return result;
        }
        
        private int SumLineLengths(int cursorLine)
        {
            var length = 0;
            for (var i = 0; i < cursorLine; i++)
            {
                length += lines[i].Length + Environment.NewLine.Length;
            }
            return length;
        }
        
        public void AltS()
        {
            InsertSectionTags();
        }
    }
}