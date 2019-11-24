namespace NotePad
{
    public class MockTextBox : ITestTextBox
    {
        private bool scrolled;

        public MockTextBox()
        {
            scrolled = false;
        }

        public int SelectionStart
        {
            get { return 1; }
            set{}
        }
        
        public string[] Lines
        {
            get { return new string[0]; }
            set { }
        }
        
        public bool Scrolled
        {
            get { return scrolled; }
            set{}
        }

        public void ScrollToCaret()
        {
            scrolled = true;
        }
    }
}