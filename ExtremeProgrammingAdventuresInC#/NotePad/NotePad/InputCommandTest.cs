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
            command = new InputCommand();
            
            Assert.AreEqual(0, command.CleanLines().Length);
        }
    }
}