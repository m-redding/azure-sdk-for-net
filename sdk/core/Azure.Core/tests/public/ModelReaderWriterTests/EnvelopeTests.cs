// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Tests.Public.ModelReaderWriterTests
{
    internal class EnvelopeTests// : ModelJsonTests<Envelope<EnvelopeTests.ModelC>>
    {
        //protected override string JsonPayload => WirePayload;

        //protected override string WirePayload => "{\"readOnlyProperty\":\"read\"," +
        //        "\"modelA\":{\"name\":\"Cat\",\"isHungry\":false,\"weight\":2.5}," +
        //        "\"modelC\":{\"x\":\"hello\",\"y\":\"bye\"}" +
        //        "}";

        //protected override Func<Envelope<ModelC>, RequestContent> ToRequestContent => model => model;

        //protected override Func<Response, Envelope<ModelC>> FromResponse => response => (Envelope<ModelC>)response;

        //protected override Func<Type, ObjectSerializer> GetObjectSerializerFactory(ModelReaderWriterFormat format)
        //{
        //    if (format == ModelReaderWriterFormat.Wire)
        //    {
        //        JsonSerializerSettings settings = new JsonSerializerSettings
        //        {
        //            ContractResolver = new IgnoreReadOnlyPropertiesResolver()
        //        };
        //        return type => type.Equals(typeof(ModelC)) ? new NewtonsoftJsonObjectSerializer(settings) : null;
        //    }
        //    else
        //    {
        //        return type => type.Equals(typeof(ModelC)) ? new NewtonsoftJsonObjectSerializer() : null;
        //    }
        //}

        //protected override void CompareModels(Envelope<ModelC> model, Envelope<ModelC> model2, ModelReaderWriterFormat format)
        //{
        //    if (format == ModelReaderWriterFormat.Json)
        //    {
        //        Assert.That(model2.ReadOnlyProperty, Is.EqualTo(model.ReadOnlyProperty));
        //        Assert.That(model2.ModelA.LatinName, Is.EqualTo(model.ModelA.LatinName));
        //        Assert.That(model2.ModelA.HasWhiskers, Is.EqualTo(model.ModelA.HasWhiskers));
        //    }
        //    Assert.That(model2.ModelA.Name, Is.EqualTo(model.ModelA.Name));
        //    Assert.That(model2.ModelA.IsHungry, Is.EqualTo(model.ModelA.IsHungry));
        //    Assert.That(model2.ModelA.Weight, Is.EqualTo(model.ModelA.Weight));
        //    Assert.That(model2.ModelT.X, Is.EqualTo(model.ModelT.X));
        //    Assert.That(model2.ModelT.Y, Is.EqualTo(model.ModelT.Y));
        //}

        //protected override string GetExpectedResult(ModelReaderWriterFormat format)
        //{
        //    StringBuilder expectedSerialized = new StringBuilder("{");
        //    if (format == ModelReaderWriterFormat.Json)
        //    {
        //        expectedSerialized.Append("\"readOnlyProperty\":\"read\",");
        //    }
        //    expectedSerialized.Append("\"modelA\":{");
        //    if (format == ModelReaderWriterFormat.Json)
        //    {
        //        expectedSerialized.Append("\"latinName\":\"Felis catus\",\"hasWhiskers\":false,");
        //    }
        //    expectedSerialized.Append("\"name\":\"Cat\",\"isHungry\":false,\"weight\":2.5},");
        //    expectedSerialized.Append("\"modelC\":{\"X\":\"hello\",\"Y\":\"bye\"}"); //using NewtonSoft Serializer
        //    expectedSerialized.Append("}");
        //    return expectedSerialized.ToString();
        //}

        //protected override void VerifyModel(Envelope<ModelC> model, ModelReaderWriterFormat format)
        //{
        //    Assert.That(model.ModelA, Is.Not.Null);
        //    if (format == ModelReaderWriterFormat.Json)
        //    {
        //        Assert.That(model.ReadOnlyProperty, Is.EqualTo("read"));
        //        Assert.That(model.ModelA.LatinName, Is.EqualTo("Felis catus"));
        //        Assert.That(model.ModelA.HasWhiskers, Is.EqualTo(false));
        //    }
        //    Assert.That(model.ModelA.Name, Is.EqualTo("Cat"));
        //    Assert.That(model.ModelA.IsHungry, Is.EqualTo(false));
        //    Assert.That(model.ModelA.Weight, Is.EqualTo(2.5));
        //    Assert.That(model.ModelT, Is.Not.Null);
        //    Assert.That(model.ModelT.X, Is.EqualTo("hello"));
        //    Assert.That(model.ModelT.Y, Is.EqualTo("bye"));
        //}

        //// Generate a class that implements the NewtonSoft default contract resolver so that ReadOnly properties are not serialized
        //// This is used to verify that the ReadOnly properties are not serialized when IgnoreReadOnlyProperties is set to true
        //private class IgnoreReadOnlyPropertiesResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
        //{
        //    protected override Newtonsoft.Json.Serialization.JsonProperty CreateProperty(System.Reflection.MemberInfo member, MemberSerialization memberSerialization)
        //    {
        //        Newtonsoft.Json.Serialization.JsonProperty property = base.CreateProperty(member, memberSerialization);

        //        if (!property.Writable)
        //        {
        //            property.ShouldSerialize = obj => false;
        //        }

        //        return property;
        //    }
        //}

        //public class ModelC
        //{
        //    public ModelC(string x1, string y1)
        //    {
        //        X = x1;
        //        Y = y1;
        //    }

        //    public string X { get; set; }
        //    public string Y { get; set; }

        //    public static void VerifyModelC(ModelC c1, ModelC c2)
        //    {
        //        Assert.That(c1.X == c2.X);
        //        Assert.That(c1.Y == c2.Y);
        //    }
        //}
    }
}
