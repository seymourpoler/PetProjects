using System.Windows.Forms;

namespace NotePad
{
    public partial class NotePadCloneNoMenu : Form
    {
        protected TesteableTextBox textbox;
        
        public NotePadCloneNoMenu()
        {
            InitializeComponent();
            
            Text = "Notepad Clone No Menu";
            textbox = new TesteableTextBox();      
            textbox.Parent = this;      
            textbox.Dock = DockStyle.Fill;      
            textbox.BorderStyle = BorderStyle.None;      
            textbox.Multiline = true;      
            textbox.ScrollBars = ScrollBars.Both;      
            textbox.AcceptsTab = true;
        }
    }
}