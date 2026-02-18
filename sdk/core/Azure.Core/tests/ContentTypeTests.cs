// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ContentTypeTests
    {
        [Test]
        public void Basics()
        {
            ContentType contentType = default;
            Assert.That(contentType.ToString(), Is.Empty);
            Assert.That(contentType, Is.EqualTo(null));
            Assert.That(contentType, Is.EqualTo(new ContentType()));

            string aj = "application/json";
            contentType = ContentType.ApplicationJson;
            Assert.That(contentType.ToString(), Is.EqualTo(aj));
            Assert.That(contentType, Is.EqualTo(aj));
            Assert.That(contentType, Is.EqualTo(new ContentType(aj)));
            Assert.That(contentType, Is.EqualTo((object)aj));
            Assert.That(contentType, Is.EqualTo((object)new ContentType(aj)));
            Assert.IsFalse(contentType.Equals("text/plain"));
            Assert.IsFalse(contentType.Equals(null));

            string aos = "application/octet-stream";
            contentType = ContentType.ApplicationOctetStream;
            Assert.That(contentType.ToString(), Is.EqualTo(aos));
            Assert.That(contentType, Is.EqualTo(aos));
            Assert.That(contentType, Is.EqualTo(new ContentType(aos)));
            Assert.That(contentType, Is.EqualTo((object)aos));
            Assert.That(contentType, Is.EqualTo((object)new ContentType(aos)));
            Assert.IsFalse(contentType.Equals("text/plain"));
            Assert.IsFalse(contentType.Equals(null));

            string pt = "text/plain";
            contentType = ContentType.TextPlain;
            Assert.That(contentType.ToString(), Is.EqualTo(pt));
            Assert.That(contentType, Is.EqualTo(pt));
            Assert.That(contentType, Is.EqualTo(new ContentType(pt)));
            Assert.That(contentType, Is.EqualTo((object)pt));
            Assert.That(contentType, Is.EqualTo((object)new ContentType(pt)));
            Assert.IsFalse(contentType.Equals("application/json"));
            Assert.IsFalse(contentType.Equals(null));
        }
    }
}
