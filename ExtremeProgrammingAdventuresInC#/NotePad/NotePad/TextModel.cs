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
            set { lines.AddRange(value.ToList()); }
        }

        private int selectionStart;
        public int SelectionStart
        {
            get { return selectionStart; }
            set { selectionStart = value; }
        }

        public string TestText { get; set; }

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
            //
            // On Enter, we change the TextModel lines to insert, after the line
            // containing the cursor, a blank line, and a line with <P></P>. We set the
            // new cursor location to be between the P tags: <P>|</P>.
            //
            // handle empty array special case (yucch)
            if (lines.Count == 0)
            {
                lines.Add("<P></P>");
                selectionStart = 3;
                return;
            }

//            
//            int cursorLine = LineContainingCursor();
//            String[] newlines = new String[lines.Count + 2];
//            for (int i = 0; i <= cursorLine; i++)
//            {
//                newlines[i] = lines[i];
//            }
//
//            newlines[cursorLine + 1] = "";
//            newlines[cursorLine + 2] = "<P></P>";
//            for (int i = cursorLine + 1; i < lines.Count; i++)
//            {
//                newlines[i + 2] = lines[i];
//            }
//
//            lines = newlines.ToList();
//            selectionStart = NewSelectionStart(cursorLine + 2);

//            var newLines = new List<string>();
//            newLines.AddRange(LinesThroughCursor());
//            newLines.AddRange(NewParagraph());
//            newLines.AddRange(LinesAfterCursor());
//            lines = newLines;

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
            throw new NotImplementedException();
        }
    }
}