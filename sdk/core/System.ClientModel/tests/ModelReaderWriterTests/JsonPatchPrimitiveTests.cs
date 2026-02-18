// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    internal class JsonPatchPrimitiveTests
    {
        [Test]
        public void GetBoolean_Success()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, true);
            jp.Set("$.property2"u8, false);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.property2"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.That(jp.GetBoolean("$.property"u8), Is.EqualTo(true));
            Assert.That(jp.GetBoolean("$.property2"u8), Is.EqualTo(false));
            Assert.That(jp.GetNullableValue<bool>("$.property"u8), Is.EqualTo(true));
            Assert.That(jp.GetNullableValue<bool>("$.property2"u8), Is.EqualTo(false));
            Assert.That(jp.GetNullableValue<bool>("$.nullProperty"u8), Is.EqualTo(null));
            Assert.IsTrue(jp.TryGetValue("$.property"u8, out bool property));
            Assert.That(property, Is.EqualTo(true));
            Assert.IsTrue(jp.TryGetValue("$.property2"u8, out bool property2));
            Assert.That(property2, Is.EqualTo(false));
            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out bool? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(true));
            Assert.IsTrue(jp.TryGetNullableValue("$.property2"u8, out bool? nullableProperty2));
            Assert.That(nullableProperty2, Is.EqualTo(false));
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out bool? nullablePropertyNull));
            Assert.That(nullablePropertyNull, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":true,\"property2\":false,\"nullProperty\":null}"));
        }

        [Test]
        public void GetBoolean_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetBoolean("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Boolean."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetBoolean("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetBoolean("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.Boolean."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<bool>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.Boolean]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<bool>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out bool property));
            Assert.That(property, Is.EqualTo(default(bool)));
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out bool notPresent));
            Assert.That(property, Is.EqualTo(default(bool)));
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out bool nullProperty));
            Assert.That(property, Is.EqualTo(default(bool)));

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out bool? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(default(bool?)));
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out bool? nullableNotPresent));
            Assert.That(nullableNotPresent, Is.EqualTo(default(bool?)));
        }

        [Test]
        public void GetByte_Success()
        {
            JsonPatch jp = new();
            byte value = 5;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.That(jp.GetByte("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<byte>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<byte>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out byte property));
            Assert.That(property, Is.EqualTo(value));

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out byte? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out byte? nullProperty));
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":5,\"nullProperty\":null}"));
        }

        [Test]
        public void GetByte_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetByte("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Byte."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetByte("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetByte("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.Byte."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<byte>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.Byte]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<byte>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out byte property));
            Assert.That(property, Is.EqualTo(default(byte)));
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out byte notPresent));
            Assert.That(property, Is.EqualTo(default(byte)));
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out byte nullProperty));
            Assert.That(property, Is.EqualTo(default(byte)));

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out byte? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out byte? nullableNotPresent));
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetDateTime_Success()
        {
            JsonPatch jp = new();
            DateTime value = new(2025, 12, 25, 6, 7, 8);

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.That(jp.GetDateTime("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<DateTime>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<DateTime>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out DateTime property));
            Assert.That(property, Is.EqualTo(value));

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out DateTime? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out DateTime? nullProperty));
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":\"12/25/2025 06:07:08\",\"nullProperty\":null}"));
        }

        [Test]
        public void GetDateTime_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetDateTime("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.DateTime."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetDateTime("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetDateTime("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.DateTime."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<DateTime>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.DateTime]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<DateTime>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out DateTime property));
            Assert.That(property, Is.EqualTo(default(DateTime)));
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out DateTime notPresent));
            Assert.That(property, Is.EqualTo(default(DateTime)));
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out DateTime nullProperty));
            Assert.That(property, Is.EqualTo(default(DateTime)));

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out DateTime? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out DateTime? nullableNotPresent));
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetDateTimeOffset_Success()
        {
            JsonPatch jp = new();
            DateTimeOffset value = new(2025, 12, 25, 6, 7, 8, new TimeSpan(2, 0, 0));

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.That(jp.GetDateTimeOffset("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<DateTimeOffset>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<DateTimeOffset>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out DateTimeOffset property));
            Assert.That(property, Is.EqualTo(value));

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out DateTimeOffset? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out DateTimeOffset? nullProperty));
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":\"12/25/2025 06:07:08 \\u002B02:00\",\"nullProperty\":null}"));
        }

        [Test]
        public void GetDateTimeOffset_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetDateTimeOffset("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.DateTimeOffset."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetDateTimeOffset("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetDateTimeOffset("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.DateTimeOffset."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<DateTimeOffset>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.DateTimeOffset]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<DateTimeOffset>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out DateTimeOffset property));
            Assert.That(property, Is.EqualTo(default(DateTimeOffset)));
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out DateTimeOffset notPresent));
            Assert.That(property, Is.EqualTo(default(DateTimeOffset)));
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out DateTimeOffset nullProperty));
            Assert.That(property, Is.EqualTo(default(DateTimeOffset)));

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out DateTimeOffset? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out DateTimeOffset? nullableNotPresent));
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetDecimal_Success()
        {
            JsonPatch jp = new();
            decimal value = (decimal)24.56;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.That(jp.GetDecimal("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<decimal>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<decimal>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out decimal property));
            Assert.That(property, Is.EqualTo(value));

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out decimal? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out decimal? nullProperty));
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":24.56,\"nullProperty\":null}"));
        }

        [Test]
        public void GetDecimal_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetDecimal("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Decimal."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetDecimal("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetDecimal("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.Decimal."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<decimal>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.Decimal]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<decimal>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out decimal property));
            Assert.That(property, Is.EqualTo(default(decimal)));
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out decimal notPresent));
            Assert.That(property, Is.EqualTo(default(decimal)));
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out decimal nullProperty));
            Assert.That(property, Is.EqualTo(default(decimal)));

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out decimal? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out decimal? nullableNotPresent));
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetDouble_Success()
        {
            JsonPatch jp = new();
            double value = 24.56;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.That(jp.GetDouble("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<double>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<double>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out double property));
            Assert.That(property, Is.EqualTo(value));

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out double? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out double? nullProperty));
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":24.56,\"nullProperty\":null}"));
        }

        [Test]
        public void GetDouble_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetDouble("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Double."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetDouble("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetDouble("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.Double."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<double>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.Double]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<double>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out double property));
            Assert.That(property, Is.EqualTo(default(double)));
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out double notPresent));
            Assert.That(property, Is.EqualTo(default(double)));
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out double nullProperty));
            Assert.That(property, Is.EqualTo(default(double)));

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out double? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out double? nullableNotPresent));
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetFloat_Success()
        {
            JsonPatch jp = new();
            float value = (float)24.5;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.That(jp.GetFloat("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<float>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<float>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out float property));
            Assert.That(property, Is.EqualTo(value));

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out float? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out float? nullProperty));
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":24.5,\"nullProperty\":null}"));
        }

        [Test]
        public void GetFloat_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetFloat("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Single."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetFloat("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetFloat("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.Single."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<float>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.Single]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<float>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out float property));
            Assert.That(property, Is.EqualTo(default(float)));
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out float notPresent));
            Assert.That(property, Is.EqualTo(default(float)));
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out float nullProperty));
            Assert.That(property, Is.EqualTo(default(float)));

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out float? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out float? nullableNotPresent));
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetGuid_Success()
        {
            JsonPatch jp = new();
            Guid value = new("12345678-1234-1234-1234-1234567890ab");

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.That(jp.GetGuid("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<Guid>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<Guid>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out Guid property));
            Assert.That(property, Is.EqualTo(value));

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out Guid? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out Guid? nullProperty));
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":\"12345678-1234-1234-1234-1234567890ab\",\"nullProperty\":null}"));
        }

        [Test]
        public void GetGuid_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetGuid("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Guid."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetGuid("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetGuid("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.Guid."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<Guid>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.Guid]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<Guid>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out Guid property));
            Assert.That(property, Is.EqualTo(default(Guid)));
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out Guid notPresent));
            Assert.That(property, Is.EqualTo(default(Guid)));
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out Guid nullProperty));
            Assert.That(property, Is.EqualTo(default(Guid)));

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out Guid? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out Guid? nullableNotPresent));
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetInt32_Success()
        {
            JsonPatch jp = new();
            int value = 123;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.That(jp.GetInt32("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<int>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<int>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out int property));
            Assert.That(property, Is.EqualTo(value));

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out int? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out int? nullProperty));
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":123,\"nullProperty\":null}"));
        }

        [Test]
        public void GetInt32_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetInt32("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Int32."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetInt32("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetInt32("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.Int32."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<int>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.Int32]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<int>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out int property));
            Assert.That(property, Is.EqualTo(default(int)));
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out int notPresent));
            Assert.That(property, Is.EqualTo(default(int)));
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out int nullProperty));
            Assert.That(property, Is.EqualTo(default(int)));

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out int? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out int? nullableNotPresent));
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetInt64_Success()
        {
            JsonPatch jp = new();
            long value = (long)int.MaxValue + 1;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.That(jp.GetInt64("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<long>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<long>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out long property));
            Assert.That(property, Is.EqualTo(value));

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out long? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out long? nullProperty));
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":2147483648,\"nullProperty\":null}"));
        }

        [Test]
        public void GetInt64_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetInt64("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Int64."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetInt64("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetInt64("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.Int64."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<long>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.Int64]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<long>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out long property));
            Assert.That(property, Is.EqualTo(default(long)));
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out long notPresent));
            Assert.That(property, Is.EqualTo(default(long)));
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out long nullProperty));
            Assert.That(property, Is.EqualTo(default(long)));

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out long? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out long? nullableNotPresent));
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetInt8_Success()
        {
            JsonPatch jp = new();
            sbyte value = 64;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.That(jp.GetInt8("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<sbyte>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<sbyte>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out sbyte property));
            Assert.That(property, Is.EqualTo(value));

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out sbyte? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out sbyte? nullProperty));
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":64,\"nullProperty\":null}"));
        }

        [Test]
        public void GetInt8_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetInt8("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.SByte."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetInt8("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetInt8("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.SByte."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<sbyte>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.SByte]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<sbyte>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out sbyte property));
            Assert.That(property, Is.EqualTo(default(sbyte)));
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out sbyte notPresent));
            Assert.That(property, Is.EqualTo(default(sbyte)));
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out sbyte nullProperty));
            Assert.That(property, Is.EqualTo(default(sbyte)));

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out sbyte? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out sbyte? nullableNotPresent));
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetInt16_Success()
        {
            JsonPatch jp = new();
            short value = sbyte.MaxValue + 1;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.That(jp.GetInt16("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<short>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<short>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out short property));
            Assert.That(property, Is.EqualTo(value));

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out short? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out short? nullProperty));
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":128,\"nullProperty\":null}"));
        }

        [Test]
        public void GetInt16_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetInt16("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Int16."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetInt16("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetInt16("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.Int16."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<short>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.Int16]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<short>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out short property));
            Assert.That(property, Is.EqualTo(default(short)));
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out short notPresent));
            Assert.That(property, Is.EqualTo(default(short)));
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out short nullProperty));
            Assert.That(property, Is.EqualTo(default(short)));

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out short? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out short? nullableNotPresent));
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetTimeSpan_Success()
        {
            JsonPatch jp = new();
            TimeSpan value = new(1, 1, 1, 1, 1);

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.That(jp.GetTimeSpan("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<TimeSpan>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<TimeSpan>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out TimeSpan property));
            Assert.That(property, Is.EqualTo(value));

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out TimeSpan? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out TimeSpan? nullProperty));
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":\"1.01:01:01.0010000\",\"nullProperty\":null}"));
        }

        [Test]
        public void GetTimeSpan_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetTimeSpan("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.TimeSpan."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetTimeSpan("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetTimeSpan("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.TimeSpan."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<TimeSpan>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.TimeSpan]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<TimeSpan>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out TimeSpan property));
            Assert.That(property, Is.EqualTo(default(TimeSpan)));
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out TimeSpan notPresent));
            Assert.That(property, Is.EqualTo(default(TimeSpan)));
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out TimeSpan nullProperty));
            Assert.That(property, Is.EqualTo(default(TimeSpan)));

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out TimeSpan? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out TimeSpan? nullableNotPresent));
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetUInt32_Success()
        {
            JsonPatch jp = new();
            uint value = (uint)int.MaxValue + 1;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.That(jp.GetUInt32("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<uint>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<uint>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out uint property));
            Assert.That(property, Is.EqualTo(value));

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out uint? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out uint? nullProperty));
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":2147483648,\"nullProperty\":null}"));
        }

        [Test]
        public void GetUInt32_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetUInt32("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.UInt32."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt32("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetUInt32("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.UInt32."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<uint>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.UInt32]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<uint>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out uint property));
            Assert.That(property, Is.EqualTo(default(uint)));
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out uint notPresent));
            Assert.That(property, Is.EqualTo(default(uint)));
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out uint nullProperty));
            Assert.That(property, Is.EqualTo(default(uint)));

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out uint? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out uint? nullableNotPresent));
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetUInt64_Success()
        {
            JsonPatch jp = new();
            ulong value = (ulong)long.MaxValue + 1;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.That(jp.GetUInt64("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<ulong>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<ulong>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out ulong property));
            Assert.That(property, Is.EqualTo(value));

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out ulong? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out ulong? nullProperty));
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":9223372036854775808,\"nullProperty\":null}"));
        }

        [Test]
        public void GetUInt64_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetUInt64("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.UInt64."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt64("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetUInt64("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.UInt64."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<ulong>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.UInt64]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<ulong>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out ulong property));
            Assert.That(property, Is.EqualTo(default(ulong)));
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out ulong notPresent));
            Assert.That(property, Is.EqualTo(default(ulong)));
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out ulong nullProperty));
            Assert.That(property, Is.EqualTo(default(ulong)));

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out ulong? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out ulong? nullableNotPresent));
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetUInt16_Success()
        {
            JsonPatch jp = new();
            ushort value = (ushort)short.MaxValue + 1;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.That(jp.GetUInt16("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<ushort>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<ushort>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out ushort property));
            Assert.That(property, Is.EqualTo(value));

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out ushort? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out ushort? nullProperty));
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":32768,\"nullProperty\":null}"));
        }

        [Test]
        public void GetUInt16_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetUInt16("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.UInt16."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt16("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetUInt16("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.UInt16."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<ushort>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.UInt16]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<ushort>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out ushort property));
            Assert.That(property, Is.EqualTo(default(ushort)));
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out ushort notPresent));
            Assert.That(property, Is.EqualTo(default(ushort)));
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out ushort nullProperty));
            Assert.That(property, Is.EqualTo(default(ushort)));

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out ushort? nullableProperty));
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out ushort? nullableNotPresent));
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }
        [Test]
        public void GetString_Success()
        {
            JsonPatch jp = new();
            string value = "value";

            jp.Set("$.property"u8, value);
            jp.SetNull("$.property2"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.property2"u8));

            Assert.That(jp.GetString("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetString("$.property2"u8), Is.EqualTo(null));
            Assert.IsTrue(jp.TryGetValue("$.property"u8, out string? property));
            Assert.That(property, Is.EqualTo(value));
            Assert.IsTrue(jp.TryGetValue("$.property2"u8, out property));
            Assert.That(property, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":\"value\",\"property2\":null}"));
        }

        [Test]
        public void GetString_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, true);

            Assert.IsTrue(jp.Contains("$.property"u8));

            Assert.That(jp.GetString("$.property"u8), Is.EqualTo("true"));
            Assert.IsTrue(jp.TryGetValue("$.property"u8, out string? property));
            Assert.That(property, Is.EqualTo("true"));
            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetString("$.notPresent"u8));
            Assert.That(ex!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out property));
        }
    }
}
