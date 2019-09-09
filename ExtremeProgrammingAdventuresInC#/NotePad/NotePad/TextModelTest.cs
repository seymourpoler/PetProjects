using NUnit.Framework;

namespace NotePad
{
    public class TextModelTest
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
        public void TestOneEnter()
        {
            model.Lines = new string[1] {"hello world" };  
            model.SelectionStart = 5;  
            
            model.Enter();
            
            Assert.AreEqual(3, model.Lines.Length);  
            Assert.AreEqual(18, model.SelectionStart);
        }
    }
}