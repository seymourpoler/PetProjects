using System;
using System.Linq;
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
            
            Assert.AreEqual(2, model.Lines.Length);
            Assert.AreEqual(16, model.SelectionStart);
        }

        [Test]
        public void InsertWithCursorAtLineStart()
        {
            model.Lines = new String[3] { "<P>one</P>", "", "<P>two</P>" };
            model.SelectionStart = 14;
            
            model.InsertParagraphTag();
            
            Assert.AreEqual("<P></P>", model.Lines[2]);
        }

        [Test] public void TestLineContainingCursorDirectly() 
        {      
            // todo?
        }
        
        [Test]
        public void ControlTwo()
            {
                model.SetLines(new[]{"<p>The Heading</p>"});

                model.ChangeToH2();
                
                Assert.AreEqual("<H2>The Heading</H2>", model.Lines[0]);
            }

            [Test]
            public void AltS()
            {
                model.Lines = new string[] { };
                
                model.AltS();
                
                Assert.AreEqual("<sect1><tittle></tittle>", model.Lines.First());
                Assert.AreEqual("</sect1>", model.Lines[1]);
            }

            [Test]
            public void AltSWithText()
            {
                model.SetLines(new[]{"<p></p>"});
                model.SelectionStart = 7;
                
                model.AltS();
                
                Assert.AreEqual("<sect1><tittle></tittle>", model.Lines[1]);
                Assert.AreEqual("</sect1>", model.Lines[2]);
            }

            [Test]
            public void InsertPre()
            {
                model.SetLines(new []{"<p></p>"});
                model.SelectionStart = 7;
                model.InsertPreTag();
                Assert.Equals("<pre></pre>", model.Lines[1]);
                Assert.Equals(14, model.SelectionStart);
            }

            [Test]
            public void ShiftEnter()
            {
                model.SetLines(new []{"<pre></pre>"});
                model.SelectionStart = 5;
                
                model.InsertPreTag();
                
                Assert.Equals("<pre>", model.Lines[0]);
                Assert.Equals("</pre>", model.Lines[1]);
                Assert.Equals(7, model.SelectionStart);
            }
            
            [Test] 
            [Ignore("New Para in mid-Pre Bug")]
            public void ShiftEnterMultipleLines() 
            {  
                model.SetLines (new [] {"<pre>code1", "code2","code3</pre>"});  
                model.SelectionStart = 14; // after ’co’ in ’code2’
                
                model.InsertParagraphTag(); 
                
                Assert.Equals("code3</pre>", model.Lines[2]);  
                Assert.Equals("<P></P>", model.Lines[3]);
            }
            
            [Test]
            public void CursorPosition()
            {
                model.SetLines(new []{ "<p></p>", "<pre></pre>"});
                
                model.SelectionStart = 14; //after <pre>

                Assert.Equals("<pre>", model.FrontOfCursorLine()); 

                Assert.Equals("</pre>", model.BackOfCursorLine());
        }
    }
}
