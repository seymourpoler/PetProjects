namespace NotePad
{
    public class TesteableTextBox : System.Windows.Forms.TextBox, ITestTextBox
    {
        public string[] Lines { get; set; }
        public int SelectionStart { get; set; }
        public void ScrollToCaret()
        {
            throw new System.NotImplementedException();
        }
    }
}