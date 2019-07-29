using System.Windows.Forms;
using System;

namespace NotePad
{
    public class XMLNotePad : NotePadCloneNoMenu
    {
        public XMLNotePad()
        {
            Text = "XML Notepad";
            txtbox.KeyDown += XMLKeyDownHandler;
        }
        
        void XMLKeyDownHandler(object sender, KeyEventArgs kea) {
            if (kea.KeyCode == Keys.P && kea.Modifiers == Keys.Control)
            {
                txtbox.Text += "controlP";        
                kea.Handled = true;
            }

            if (kea.KeyCode == Keys.L && kea.Modifiers == Keys.Control)
            {
                String[] lines = txtbox.Lines;
                foreach (String s in lines)
                {
                    Console.WriteLine(s);
                }   kea.Handled = true;
            }

            if (kea.KeyCode == Keys.Enter)
            {
                String[] lines = txtbox.Lines;  
                int cursorLine = CursorLine();    
                String[] newlines = new String[lines.Length+2];
                for (int i = 0; i <= cursorLine; i++)
                {
                    newlines[i] = lines[i];
                }   newlines[cursorLine+1] = "";    
                newlines[cursorLine+2] = "<P></P>";
                for (int i = cursorLine + 1; i < lines.Length; i++)
                {
                    newlines[i+2] = lines[i];
                }   
                txtbox.Lines = newlines;    
                kea.Handled = true;
            }  
        }
        int CursorLine() { return 3; }
    }
}