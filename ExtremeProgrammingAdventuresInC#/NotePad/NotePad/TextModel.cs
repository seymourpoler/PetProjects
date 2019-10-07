using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public void IntertControlP()
        {
            lines[lines.Count - 1] += "ControlP";
        }

        //TODO: rename?
        public void InsertParagraphTag()
        {
            if (lines.Count == 0)
            {
                lines.Add("<P></P>");
                selectionStart = 3;
                return;
            }

            lines.InsertRange(LineContainingCursor()+1, NewParagraph());
            selectionStart = NewSelectionStart(LineContainingCursor() + 2);
        }

        private int NewSelectionStart(int cursorLine)
        {
            int length = 0;
            for (int i = 0; i < cursorLine; i++)
            {
                length += lines[i].Length + Environment.NewLine.Length;
            }

            return length + 3;
        }

        private int LineContainingCursor()
        {
            int length = 0;
            int lineNr = 0;
            foreach (String line in lines)
            {
                if (length <= selectionStart && selectionStart <= length + line.Length + 2)
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
                "",
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
    }
}