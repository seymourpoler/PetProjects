using NUnit.Framework;
using SimplePubSub;

namespace SimplePubSubTests
{
    [TestFixture]
    public class HubTests
    {
        private Hub hub;
        [SetUp]
        public void SetUp()
        {
            hub = new Hub();
        }
    }
}
