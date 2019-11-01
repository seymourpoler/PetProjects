using System.Windows.Forms;
using System;
using System.Drawing;

namespace NotePad
{
    public class XMLNotePad : NotePadCloneNoMenu
    {
        public TesteableTextBox textbox;
        private TextModel model;
        
        public XMLNotePad()
        {
            Text = "XML Notepad";
            textbox = new TesteableTextBox();
            textbox.Parent = this;
            textbox.Dock = DockStyle.Fill;
            textbox.BorderStyle = BorderStyle.None;
            textbox.Multiline = true;
            textbox.ScrollBars = ScrollBars.Both;
            textbox.AcceptsTab = true;
            textbox.KeyDown += XMLKeyDownHandler;
            textbox.KeyPress += XMLKeyPressHandler;
            model = new TextModel();
            this.textbox.Visible = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 66);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {this.textbox});
            this.Name = "XMLNotePad";
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
            if (kea.KeyCode == Keys.X)
            {
                kea.Handled = true;
            }
            if (kea.KeyCode == Keys.S && kea.Alt)
            {
                model.AltS();
                kea.Handled = true;
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