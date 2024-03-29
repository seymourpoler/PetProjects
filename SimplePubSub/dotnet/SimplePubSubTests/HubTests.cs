﻿using System;
using NUnit.Framework;
using Shouldly;
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
        public void DoesNothingWhenThereIsNoHandler()
        {
            var result = String.Empty;
            var contentMessage = "Message";

            hub.Publish(new Message { Content = contentMessage });

            result.ShouldNotBe(contentMessage);
        }

		[Test]
		public void PublishsMessageWithSomeHandlers()
		{
			var result = String.Empty;
			var contentMessage = "Message";
			hub.Subscribe<Message>(x => result = x.Content);
            hub.Subscribe<AnotherMessage>(x => result = x.Id);


			hub.Publish(new Message { Content = contentMessage });

			result.ShouldBe(contentMessage);
		}

        [Test]
        public void UnSubscribeWhenThereIsNoHandler()
        {
			var result = String.Empty;
			var contentMessage = "Message";
            hub.Subscribe<AnotherMessage>(x => result = x.Id);
            hub.UnSubscribe<Message>();

            hub.Publish(new  Message{ Content = contentMessage });

            result.ShouldNotBe(contentMessage);
        }

		[Test]
		public void UnSubscribeWhenThereIsOneHandler()
		{
			var result = String.Empty;
			var contentMessage = "Message";
            hub.Subscribe<Message>(x => result = x.Content);
			hub.UnSubscribe<Message>();

			hub.Publish(new Message { Content = contentMessage });

			result.ShouldNotBe(contentMessage);
		}

		[Test]
		public void UnSubscribeWhenThereAreHandlers()
		{
			var result = String.Empty;
			var contentMessage = "Message";
			hub.Subscribe<Message>(x => result = x.Content);
            hub.Subscribe<AnotherMessage>(x => result = x.Id);
			hub.UnSubscribe<Message>();

			hub.Publish(new Message { Content = contentMessage });

			result.ShouldNotBe(contentMessage);
		}

		[Test]
		public void UnSubscribeOneHandler()
		{
			var result = String.Empty;
			var contentMessage = "Message";
			hub.Subscribe<Message>(x => result = x.Content);
			hub.Subscribe<AnotherMessage>(x => result = x.Id);
			hub.UnSubscribe<Message>();

			hub.Publish(new AnotherMessage { Id = contentMessage });

			result.ShouldBe(contentMessage);
		}

        internal class Message
        {
            public string Content { get; set; }
        }

        internal class AnotherMessage
        {
            public string Id { get; set; }
        }
    }
}
