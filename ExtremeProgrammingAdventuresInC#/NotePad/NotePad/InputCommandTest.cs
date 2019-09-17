using System.IO;
using System.Linq;
using NUnit.Framework;

namespace NotePad
{
    [TestFixture]
    public class InputCommandTest
    {
        InputCommand command;
        
        [Test]
        public void EmptyCommand()
        {
            command = new InputCommand(new StringReader(string.Empty));
            
            Assert.AreEqual(0, command.CleanLines().Length);
        }

        [Test]
        public void OneLineCommand()
        {
            string oneLineString = @"one line*end";
            var reader = new StringReader(oneLineString);
            
            command = new InputCommand(reader);
            
            Assert.AreEqual(1, command.CleanLines().Length);
        }

        [Test]
        public void OneDirtyLine()
        {
            command = new InputCommand(new StringReader("a|b\n*end"));
            
            Assert.AreEqual("a|b", command.CleanLines().First());
        }
    }
}