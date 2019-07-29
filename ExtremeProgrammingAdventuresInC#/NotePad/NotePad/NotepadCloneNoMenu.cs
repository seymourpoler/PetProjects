using System.Windows.Forms;

namespace NotePad
{
    public partial class NotePadCloneNoMenu : Form
    {
        protected TextBox txtbox;
        
        public NotePadCloneNoMenu()
        {
            InitializeComponent();
            
            Text = "Notepad Clone No Menu";
            
            txtbox = new TextBox();      
            txtbox.Parent = this;      
            txtbox.Dock = DockStyle.Fill;      
            txtbox.BorderStyle = BorderStyle.None;      
            txtbox.Multiline = true;      
            txtbox.ScrollBars = ScrollBars.Both;      
            txtbox.AcceptsTab = true;
        }
    }
}