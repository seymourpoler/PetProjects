namespace NotePad
{
    public class MockTextBox : ITestTextBox
    {
        private bool scrolled;

        public MockTextBox()
        {
            scrolled = false;
        }

        public string[] Lines
        {
            get { return new string[0]; }
            set { }

        }
        public int SelectionStart
        {
            get { return 1; }
            set{}
        }
        public bool Scrolled
        {
            get { return scrolled; }
            set{}
        }

        public void PutText(ITestTextBox textBox, string[] lines, int selectionStart)
        {
            textBox.Lines = lines;
            textBox.SelectionStart = selectionStart;
            textBox.ScrollToCaret();
        }
        
        public void ScrollToCaret()
        {
            scrolled = true;
        }
    }
}