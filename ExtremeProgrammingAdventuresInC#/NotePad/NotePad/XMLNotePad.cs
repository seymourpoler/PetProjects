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
            model.SetLines(txtbox.Lines);
            model.SelectionStart = txtbox.SelectionStart;
            if (kea.KeyCode == Keys.Enter) { 
                model.Enter();
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
            
            if (kea.KeyCode == Keys.P && kea.Modifiers == Keys.Control)
            {
                model.IntertControlP();
                kea.Handled = true;
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