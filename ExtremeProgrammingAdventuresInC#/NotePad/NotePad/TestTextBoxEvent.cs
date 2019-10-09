using System;
using NUnit.Framework;

namespace NotePad
{
    public class TestTextBoxEvent
    {
        private bool changed;

        [SetUp]
        public void SetUp()
        {
            changed = false;
        }

        [Test]
        public void CheckEvent()
        {
            var text = new TesteableTextBox();
            text.Text = "some text";
            Assert.IsFalse(changed);
            
            text.TextChanged += new EventHandler(Text_Changed);
            text.Text = "more text";
            
            Assert.IsTrue(changed);
        }
        
        //    [Test] public void HookForm () {
        //       TestableTextBox text = new TestableTextBox();
        //      text.TextChanged += new EventHandler(Text_Changed);
        //      XMLNotepad xn = new XMLNotepad();
        //      xn.textbox = text;
        //      text.Text = "some text";
        //      xn.PutText();
        //      AssertEquals("hello", text.Lines[0]);
        //      Assert("changed flag", changed);//    }
        
        void Text_Changed(object source, EventArgs args)
        {
            changed = true;
        }
    }
}