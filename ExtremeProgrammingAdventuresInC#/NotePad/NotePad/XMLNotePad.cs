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
            textbox.KeyDown += XMLKeyDownHandler;
            textbox.KeyPress += XMLKeyPressHandler;
            model = new TextModel();
        }
        
        void XMLKeyDownHandler(object sender, KeyEventArgs kea)
        {
            model.SetLines(textbox.Lines);
            model.SelectionStart = textbox.SelectionStart;
            if (kea.KeyCode == Keys.Enter) { 
                model.Enter();
                kea.Handled = true;
            }

            if (kea.KeyCode == Keys.L && kea.Modifiers == Keys.Control)
            {
                String[] lines = textbox.Lines;
                foreach (String s in lines)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("model");
                kea.Handled = true;
            }

            if (kea.KeyCode == Keys.S && kea.Modifiers == Keys.Control)
            {
                textbox.SelectionLength = 0;        
                kea.Handled = true;
            }
            
            if (kea.KeyCode == Keys.P && kea.Modifiers == Keys.Control)
            {
                model.IntertControlP();
                kea.Handled = true;
            }

            if (kea.KeyCode == Keys.Q && kea.Modifiers == Keys.Control)
            {
                Console.WriteLine("cursor: {0}", CursorLine());        
                kea.Handled = true;
            }

            PutText(textbox, model.Lines, model.SelectionStart);
        }
        
        int CursorLine() { return 3; }

        public void PutText(ITestTextBox textBox, string[] lines, int selectinStart)
        {
            textBox.Lines = model.Lines;
            textBox.SelectionStart = model.SelectionStart;
            textBox.ScrollToCaret();
        }
        
        void XMLKeyPressHandler(object sender, KeyPressEventArgs kea)
        {
            if (kea.KeyChar == (int) Keys.Enter)
            {
                kea.Handled = true;
            }
        }
    }
}