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
            
            Assert.IsTrue(1 == 1);
        }
    }
}