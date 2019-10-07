namespace NotePad
{
    public interface ITestTextBox
    {
        string[] lines { get; set; }
        int SelectgionStart { get; set; }
        void ScrollToCaret();
    }
}