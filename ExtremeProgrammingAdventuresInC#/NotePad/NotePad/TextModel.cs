using System;

namespace NotePad
{
    public class TextModel
    {
        private String[] lines;
        public String[] Lines
        {
            get { return lines; }    
            set { lines = value; }
        }
        
        private int selectionStart;
        public int SelectionStart
        {
            get {      return selectionStart;    }    
            set {      selectionStart = value;    }
        }
        
        public void IntertControlP()
        {
            lines[lines.Length-1] += "ControlP";
        }   
    }
}
