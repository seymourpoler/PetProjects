using System;
using System.Collections.Generic;
using System.Linq;

namespace NotePad
{
    public class TextModel
    {
        private List<string> lines;

        public String[] Lines
        {
            get { return lines.ToArray(); }
            set { lines = value.ToList(); }
        }

        private int selectionStart;

        public int SelectionStart
        {
            get { return selectionStart; }
            set { selectionStart = value; }
        }

        public TextModel()
        {
            lines = new List<string>();
        }

        public void IntertControlP()
        {
            lines[lines.Count - 1] += "ControlP";
        }

        public void InsertParagraphTag()
        {
            if (lines.Count == 0)
            {
                lines.Add("<P></P>");
                selectionStart = 3;
                return;
            }

            int cursorLine = LineContainingCursor();
            String[] newlines = new String[lines.Count + 2];
            for (int i = 0; i <= cursorLine; i++)
            {
                newlines[i] = lines[i];
            }

            newlines[cursorLine + 1] = "";
            newlines[cursorLine + 2] = "<P></P>";
            for (int i = cursorLine + 1; i < lines.Count; i++)
            {
                newlines[i + 2] = lines[i];
            }

            lines = newlines.ToList();
            selectionStart = NewSelectionStart(cursorLine + 2);
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

        private int NewSelectionStart(int cursorLine)
        {
            int length = 0;
            for (int i = 0; i < cursorLine; i++)
            {
                length += lines[i].Length + Environment.NewLine.Length;
            }

            return length + 3;
        }
    }
}