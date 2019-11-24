using System.Windows.Forms;
using NUnit.Framework;

namespace NotePad
{
    public class TestScroll
    {
        [Test]
        public void HookUp()
        {
            Assert.IsTrue(true, "hooked up");
        }

        [Test]
        public void ScrollHappens()
        {
            var selectionStart = 1;
            var lines = new[] {"hello", "world"};
            var mock = new MockTextBox();
            var notepad = new XMLNotePad();
            Assert.IsFalse(mock.Scrolled, "no scroll");

            notepad.PutText(mock, lines, selectionStart);

            Assert.IsTrue(mock.Scrolled, "scroll happens");
        }
    }
}