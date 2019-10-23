using jktoiuhito.Utility.Extensions.Json;
using System.Runtime.Serialization;
using System.Text;
using System.IO;
using System;
using Xunit;

#pragma warning disable IDE0007 // Use implicit type
namespace jktoiuhito.Utility.UnitTests.Extensions.Json
{
    //DONE 2019-10-07
    public sealed class JsonExtensionsUnitTests
    {
        #region ToJson

        [Fact]
        public void ToJson_Null_ThrowsException ()
        {
            DataContractClass original = null;
            _ = Assert.Throws<ArgumentNullException>(
                () => JsonExtensions.ToJson(original));
        }

        [Fact]
        public void ToJson_NonDataContract_ThrowsException ()
        {
            var name = "name";
            NonDataContractClass original = new NonDataContractClass(name);
            _ = Assert.Throws<InvalidDataContractException>(
                () => JsonExtensions.ToJson(original));
        }

        [Fact]
        public void ToJson_String_ReturnsDeserializableString ()
        {
            string original = "name";
            string serialized = original.ToJson();
            string deserialized = serialized.FromJson<string>();

            Assert.Equal(original, deserialized);
        }

        [Fact]
        public void ToJson_DataContract_ReturnsDeserializableString ()
        {
            string name = "name";
            DataContractClass original = new DataContractClass(name);
            string serialized = original.ToJson();
            DataContractClass deserialized = 
                serialized.FromJson<DataContractClass>();

            Assert.Equal(original, deserialized);
        }

        #endregion

        #region FromJsonString

        [Fact]
        public void FromJsonString_Null_ThrowsException ()
        {
            string original = null;
            _ = Assert.Throws<ArgumentNullException>(
                () => JsonExtensions
                    .FromJson<DataContractClass>(original));
        }

        [Fact]
        public void FromJsonString_Empty_ThrowsException ()
        {
            string original = "";
            _ = Assert.Throws<ArgumentException>(
                () => JsonExtensions
                    .FromJson<DataContractClass>(original));
        }

        [Fact]
        public void FromJsonString_Whitespace_ThrowsException ()
        {
            string original = "    ";
            _ = Assert.Throws<ArgumentException>(
                () => JsonExtensions
                    .FromJson<DataContractClass>(original));
        }

        [Fact]
        public void FromJsonString_NonJson_ThrowsException ()
        {
            string original = "<value>1</value>";
            _ = Assert.Throws<SerializationException>(
                () => JsonExtensions
                    .FromJson<DataContractClass>(original));
        }

        [Fact]
        public void FromJsonString_JsonWrongType_ThrowsException ()
        {
            string original = "{\"anotherField\":\"value\"}";
            _ = Assert.Throws<SerializationException>(
                () => JsonExtensions
                    .FromJson<DataContractClass>(original));
        }

        [Fact]
        public void FromJsonString_Json_DeserializesValues ()
        {
            string name = "value";
            string original = $"{{\"Name\":\"{name}\"}}";

            var deserialized = original.FromJson<DataContractClass>();

            Assert.Equal(name, deserialized.Name);
        }

        #endregion

        #region FromJsonStream

        [Fact]
        public void FromJsonStream_Null_ThrowsException ()
        {
            Stream original = null;
            _ = Assert.Throws<ArgumentNullException>(
                () => JsonExtensions
                    .FromJson<DataContractClass>(original));
        }

        [Fact]
        public void FromJsonStream_Empty_ThrowsException ()
        {
            using Stream original = new MemoryStream();
            _ = Assert.Throws<ArgumentException>(
                () => JsonExtensions
                    .FromJson<DataContractClass>(original));
        }

        [Fact]
        public void FromJsonStream_FilledEmpty_ThrowsException ()
        {
            using Stream original = new MemoryStream(10);
            _ = Assert.Throws<ArgumentException>(
                () => JsonExtensions
                    .FromJson<DataContractClass>(original));
        }

        [Fact]
        public void FromJsonStream_WrongType_ThrowsException ()
        {
            string original = "{\"anotherField\":\"value\"}";
            var bytes = Encoding.UTF8.GetBytes(original);
            using Stream stream = new MemoryStream(bytes);
            _ = Assert.Throws<SerializationException>(
                () => JsonExtensions
                    .FromJson<DataContractClass>(stream));
        }

        [Fact]
        public void FromJsonStream_Deserializable_DeserializesValues ()
        {
            string name = "value";
            string original = $"{{\"Name\":\"{name}\"}}";
            var bytes = Encoding.UTF8.GetBytes(original);
            using Stream stream = new MemoryStream(bytes);

            var deserialized = stream.FromJson<DataContractClass>();

            Assert.Equal(name, deserialized.Name);
        }

        [Fact]
        public void FromJsonStream_Deserializable_SeeksStream ()
        {
            string name = "value";
            string original = $"{{\"Name\":\"{name}\"}}";
            var bytes = Encoding.UTF8.GetBytes(original);
            using Stream stream = new MemoryStream(bytes);
            _ = stream.Seek(0, SeekOrigin.End);

            var deserialized = stream.FromJson<DataContractClass>();

            Assert.Equal(name, deserialized.Name);
        }

        #endregion
    }
}
#pragma warning restore IDE0007