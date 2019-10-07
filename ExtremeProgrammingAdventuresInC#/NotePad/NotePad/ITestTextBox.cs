namespace NotePad
{
    public interface ITestTextBox
    {
        string[] Lines { get; set; }
        int SelectionStart { get; set; }
        void ScrollToCaret();
    }
}