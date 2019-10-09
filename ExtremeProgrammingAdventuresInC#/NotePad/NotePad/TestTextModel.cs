using System;
using NUnit.Framework;

namespace NotePad
{
    public class TestTextModel
    {
        private TextModel model;

        [SetUp]
        public void SetUp()
        {
            model = new TextModel();
        }

        [Test]
        public void TestNoLines()
        {
            model.Lines = new string[0];
            
            Assert.AreEqual(0, model.Lines.Length);
        }

        [Test]
        public void TestNoProcessing()
        {
            model.Lines = new string[3] { "hi", "there", "chet"};  
            
            Assert.AreEqual(3, model.Lines.Length);
        }

        [Test]
        public void TestEmptyText()
        {
            model.Lines = new String[0];
            
            model.InsertParagraphTag();  
            
            Assert.AreEqual(1, model.Lines.Length);  
            Assert.AreEqual(3, model.SelectionStart);
        }
        
        [Test]
        public void TestOneEnter()
        {
            model.Lines = new string[1] {"hello world"};
            model.SelectionStart = 5;
            
            model.InsertParagraphTag();
            
            Assert.AreEqual(3, model.Lines.Length);
            Assert.AreEqual(18, model.SelectionStart);
        }

        [Test]
        public void InsertWithCursorAtLineStart()
        {
            model.Lines = new String[3] { "<P>one</P>", "", "<P>two</P>" };
            model.SelectionStart = 14;
            
            model.InsertParagraphTag();
            
            Assert.AreEqual("", model.Lines[2]);
            Assert.AreEqual("<P></P>", model.Lines[3]);
        }
    }
}
