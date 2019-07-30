using System.Windows.Forms;
using System;

namespace NotePad
{
    public class XMLNotePad : NotePadCloneNoMenu
    {
        private TextModel model;
        public XMLNotePad()
        {
            Text = "XML Notepad";
            txtbox.KeyDown += XMLKeyDownHandler;
            txtbox.KeyPress += XMLKeyPressHandler;
            model = new TextModel();
        }
        
        void XMLKeyDownHandler(object sender, KeyEventArgs kea)
        {
            model.Lines = txtbox.Lines;
            model.SelectionStart = model.SelectionStart;
            if (kea.KeyCode == Keys.P && kea.Modifiers == Keys.Control)
            {
                model.IntertControlP();
                kea.Handled = true;
            }

            if (kea.KeyCode == Keys.Enter) { 
                /*
                String[] lines = txtbox.Lines;
                Console.WriteLine("LineCount {0}", txtbox.Lines.Length); 
                int cursorLine = CursorLine(); 
                String[] newlines = new String[lines.Length+2]; 
                for(int i = 0; i <= cursorLine; i++)  
                { 
                    newlines[i] = lines[i]; 
                } 

                newlines[cursorLine+1] = ""; 
                newlines[cursorLine+2] = "<P></P>"; 
                for (int i = cursorLine+1; i < lines.Length; i++) 
                { 
                    newlines[i+2] = lines[i]; 
                } 
                txtbox.Lines = newlines; 
                kea.Handled = true; 
                Console.WriteLine("LineCount {0}", txtbox.Lines.Length);
                */ 
                model.Enter();
            }
            
            if (kea.KeyCode == Keys.L && kea.Modifiers == Keys.Control)
            {
                String[] lines = txtbox.Lines;
                foreach (String s in lines)
                {
                    Console.WriteLine(s);
                }   kea.Handled = true;
            }
            
            // debugging keys
            if (kea.KeyCode == Keys.L && kea.Modifiers == Keys.Control)
            {
                String[] lines = txtbox.Lines;
                foreach (String s in lines)
                {
                    Console.WriteLine(s);
                }   
                kea.Handled = true;
            }

            if (kea.KeyCode == Keys.S && kea.Modifiers == Keys.Control)
            {
                txtbox.SelectionLength = 0;        
                kea.Handled = true;
            }

            if (kea.KeyCode == Keys.Q && kea.Modifiers == Keys.Control)
            {
                Console.WriteLine("cursor: {0}", CursorLine());        
                kea.Handled = true;
            }

            txtbox.Lines = model.Lines;
            txtbox.SelectionStart = model.SelectionStart;
        }
        int CursorLine() { return 3; }

        void XMLKeyPressHandler(object sender, KeyPressEventArgs kea)
        {
            if (kea.KeyChar == (int) Keys.Enter)
            {
                kea.Handled = true;
            }
        }
    }
}