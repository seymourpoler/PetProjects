using NUnit.Framework;
using SimplePubSub;
using System;
using Shouldly;

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

        [Test]
        public void PublishsMessageWithOneHandler()
        {
            var result = String.Empty;
            var contentMessage = "Message";
            hub.Subscribe<Message>(x => result = x.Content);

            hub.Publish(new Message { Content = contentMessage });

            result.ShouldBe(contentMessage);
        }

        [Test]
        public void DoeSNothingWhenThereIsNoHandler()
        {
            var result = String.Empty;
            var contentMessage = "Message";

            hub.Publish(new Message { Content = contentMessage });

            result.ShouldNotBe(contentMessage);
        }

        internal class Message
        {
            public string Content { get; set; }
        }
    }
}
