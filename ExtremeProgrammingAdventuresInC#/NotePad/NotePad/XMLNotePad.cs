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

        void XMLKeyPressHandler(object sender, KeyPressEventArgs kea)
        {
            if (kea.KeyChar == (int) Keys.Enter)
            {
                kea.Handled = true;
            }
        }
        
        void XMLKeyDownHandler(object sender, KeyEventArgs kea)
        {
            model.SetLines(textbox.Lines);
            model.SelectionStart = textbox.SelectionStart;
            if (kea.KeyCode == Keys.Enter) { 
                model.Enter();
                kea.Handled = true;
            }

            if (kea.KeyCode == Keys.S && kea.Alt)
            {
                model.AltS();
            }
            PutText(textbox, model.Lines, model.SelectionStart);
        }
        
        public void PutText(ITestTextBox textBox, string[] lines, int selectionStart)
        {
            textBox.Lines = lines;
            textBox.SelectionStart = selectionStart;
            textBox.ScrollToCaret();
        }
    }
}