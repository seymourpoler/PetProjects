using System;
using NUnit.Framework;

namespace NotePad
{
    public class TextModelTest
    {
        private TextModel model;
        
        [SetUp]
        public void CreateModel()
        {
            model = new TextModel();    
        }

        [Test]
        public void TestNoLines()
        {
            model.Lines = new String[0];

            Assert.AreEqual(0, model.Lines.Length);
        }

        [Test]
        public void TestNoProcessing()
        {
            model.Lines = new string[3] {"hi", "there", "chet"};
            
            Assert.AreEqual(3, model.Lines.Length);
        }
    }
}