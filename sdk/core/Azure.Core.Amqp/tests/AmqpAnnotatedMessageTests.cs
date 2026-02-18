// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Azure.Core.Amqp.Tests
{
    public class AmqpAnnotatedMessageTests
    {
        private static readonly AmqpMessageBody EmptyDataBody = AmqpMessageBody.FromData(new ReadOnlyMemory<byte>[] { Array.Empty<byte>() });

        [Test]
        public void CanCreateAnnotatedMessage()
        {
            var message = new AmqpAnnotatedMessage(new AmqpMessageBody(new ReadOnlyMemory<byte>[] { Encoding.UTF8.GetBytes("some data") }));
            message.ApplicationProperties.Add("applicationKey", "applicationValue");
            message.DeliveryAnnotations.Add("deliveryKey", "deliveryValue");
            message.MessageAnnotations.Add("messageKey", "messageValue");
            message.Footer.Add("footerKey", "footerValue");
            message.Header.DeliveryCount = 1;
            message.Header.Durable = true;
            message.Header.FirstAcquirer = true;
            message.Header.Priority = 1;
            message.Header.TimeToLive = TimeSpan.FromSeconds(60);
            DateTimeOffset time = DateTimeOffset.Now.AddDays(1);
            message.Properties.AbsoluteExpiryTime = time;
            message.Properties.ContentEncoding = "compress";
            message.Properties.ContentType = "application/json";
            message.Properties.CorrelationId = new AmqpMessageId("correlationId");
            message.Properties.CreationTime = time;
            message.Properties.GroupId = "groupId";
            message.Properties.GroupSequence = 5;
            message.Properties.MessageId = new AmqpMessageId("messageId");
            message.Properties.ReplyTo = new AmqpAddress("replyTo");
            message.Properties.ReplyToGroupId = "replyToGroupId";
            message.Properties.Subject = "subject";
            message.Properties.To = new AmqpAddress("to");
            message.Properties.UserId = Encoding.UTF8.GetBytes("userId");

            Assert.That(message.Body.BodyType, Is.EqualTo(AmqpMessageBodyType.Data));
            Assert.IsTrue(message.Body.TryGetData(out IEnumerable<ReadOnlyMemory<byte>> body));
            Assert.That(Encoding.UTF8.GetString(body.First().ToArray()), Is.EqualTo("some data"));
            Assert.That(message.ApplicationProperties["applicationKey"], Is.EqualTo("applicationValue"));
            Assert.That(message.DeliveryAnnotations["deliveryKey"], Is.EqualTo("deliveryValue"));
            Assert.That(message.MessageAnnotations["messageKey"], Is.EqualTo("messageValue"));
            Assert.That(message.Footer["footerKey"], Is.EqualTo("footerValue"));
            Assert.That(message.Header.DeliveryCount, Is.EqualTo(1));
            Assert.IsTrue(message.Header.Durable);
            Assert.IsTrue(message.Header.FirstAcquirer);
            Assert.That(message.Header.Priority, Is.EqualTo(1));
            Assert.That(message.Header.TimeToLive, Is.EqualTo(TimeSpan.FromSeconds(60)));
            Assert.That(message.Properties.AbsoluteExpiryTime, Is.EqualTo(time));
            Assert.That(message.Properties.ContentEncoding, Is.EqualTo("compress"));
            Assert.That(message.Properties.ContentType, Is.EqualTo("application/json"));
            Assert.That(message.Properties.CorrelationId.ToString(), Is.EqualTo("correlationId"));
            Assert.That(message.Properties.CreationTime, Is.EqualTo(time));
            Assert.That(message.Properties.GroupId, Is.EqualTo("groupId"));
            Assert.That(message.Properties.GroupSequence, Is.EqualTo(5));
            Assert.That(message.Properties.MessageId.ToString(), Is.EqualTo("messageId"));
            Assert.That(message.Properties.ReplyTo.ToString(), Is.EqualTo("replyTo"));
            Assert.That(message.Properties.ReplyToGroupId, Is.EqualTo("replyToGroupId"));
            Assert.That(message.Properties.Subject, Is.EqualTo("subject"));
            Assert.That(message.Properties.To.ToString(), Is.EqualTo("to"));
            Assert.That(Encoding.UTF8.GetString(message.Properties.UserId.Value.ToArray()), Is.EqualTo("userId"));
        }

        [Test]
        public void HeaderIsCreatedOnDemand()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            Assert.False(message.HasSection(AmqpMessageSection.Header));

            message.Header.DeliveryCount = 99;
            Assert.True(message.HasSection(AmqpMessageSection.Header));
            Assert.NotNull(message.Header);
        }

        [Test]
        public void DeliveryAnnotationsAreCreatedOnDemand()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            Assert.False(message.HasSection(AmqpMessageSection.DeliveryAnnotations));

            message.DeliveryAnnotations.Add("test", new object());
            Assert.True(message.HasSection(AmqpMessageSection.DeliveryAnnotations));
            Assert.NotNull(message.DeliveryAnnotations);
        }

        [Test]
        public void MessageAnnotationsAreCreatedOnDemand()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            Assert.False(message.HasSection(AmqpMessageSection.MessageAnnotations));

            message.MessageAnnotations.Add("test", new object());
            Assert.True(message.HasSection(AmqpMessageSection.MessageAnnotations));
            Assert.NotNull(message.MessageAnnotations);
        }

        [Test]
        public void PropertiesAreCreatedOnDemand()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            Assert.False(message.HasSection(AmqpMessageSection.Properties));

            message.Properties.ContentType = "test/unit";
            Assert.True(message.HasSection(AmqpMessageSection.Properties));
            Assert.NotNull(message.Properties);
        }

        [Test]
        public void ApplicationPropertiesAreCreatedOnDemand()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            Assert.False(message.HasSection(AmqpMessageSection.ApplicationProperties));

            message.ApplicationProperties.Add("test", new object());
            Assert.True(message.HasSection(AmqpMessageSection.ApplicationProperties));
            Assert.NotNull(message.ApplicationProperties);
        }

        [Test]
        public void FooterIsCreatedOnDemand()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            Assert.False(message.HasSection(AmqpMessageSection.Footer));

            message.Footer.Add("test", new object());
            Assert.True(message.HasSection(AmqpMessageSection.Footer));
            Assert.NotNull(message.Footer);
        }

        [Test]
        public void BodyIsDetectedByHasSection()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);

            message.Body = null;
            Assert.False(message.HasSection(AmqpMessageSection.Body));

            message.Body = AmqpMessageBody.FromValue("this is a string value");
            Assert.True(message.HasSection(AmqpMessageSection.Body));
        }

        [Test]
        public void HasSectionValidatesTheSection()
        {
            var invalidSection = (AmqpMessageSection)int.MinValue;
            var message = new AmqpAnnotatedMessage(EmptyDataBody);

            Assert.Throws<ArgumentException>(() => message.HasSection(invalidSection));
        }
    }
}
