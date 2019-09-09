<<<<<<< HEAD
=======
using System;
>>>>>>> af0cef57160e1f2a443448ac54cabafbd628e47d
using NUnit.Framework;

namespace NotePad
{
    public class TextModelTest
    {
        private TextModel model;
<<<<<<< HEAD

        [SetUp]
        public void SetUp()
        {
            model = new TextModel();
        }
        
        [Test] 
        public void TestNoLines() 
        {  
            model.Lines = new string[0];  
        
=======
        
        [SetUp]
        public void CreateModel()
        {
            model = new TextModel();    
        }

        [Test]
        public void TestNoLines()
        {
            model.Lines = new String[0];

>>>>>>> af0cef57160e1f2a443448ac54cabafbd628e47d
            Assert.AreEqual(0, model.Lines.Length);
        }

        [Test]
        public void TestNoProcessing()
        {
<<<<<<< HEAD
            model.Lines = new string[3] { "hi", "there", "chet"};  
            Assert.AreEqual(3, model.Lines.Length);
        }
        
        [Test]
        public void TestOneEnter()
        {
            model.Lines = new string[1] {"hello world" };  
            model.SelectionStart = 5;  
            
            model.Enter();
            
            Assert.AreEqual(3, model.Lines.Length);  
            Assert.AreEqual(18, model.SelectionStart);
        }
=======
            model.Lines = new string[3] {"hi", "there", "chet"};
            
            Assert.AreEqual(3, model.Lines.Length);
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
        public void TestEmptyText()
        {
            model.Lines = new String[0];
            
            model.InsertParagraphTag();
            
            Assert.AreEqual(1, model.Lines.Length);
            Assert.AreEqual(3, model.SelectionStart);
        }

        [Test]
        public void InsertWithCursorAtLineStart()
        {
            model.Lines = new String[3] { "<P>one</P>", "", "<P>two</P>" };
            model.SelectionStart = 14;
            model.InsertParagraphTag();
            Assert.AreEqual("<P>two</P>", model.Lines[2]);

        }
>>>>>>> af0cef57160e1f2a443448ac54cabafbd628e47d
    }
}