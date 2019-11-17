using System.Runtime.Serialization;
using jktoiuhito.Utility.Json;
using System.Text;
using System.IO;
using System;
using Xunit;

#pragma warning disable IDE0007 // Use implicit type
namespace jktoiuhito.Utility.UnitTests.Json
{
    //EDITED 2019-11-17
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

        [Theory]
        [InlineData(' ')]
        [InlineData('\n')]
        public void ToJson_DataContract_DoesNotContainUselessWhitespace (
            char whitespace)
        {
            string name = "name";
            DataContractClass original = new DataContractClass(name);

            string serialized = original.ToJson();

            Assert.DoesNotContain(whitespace, serialized);
        }

        #endregion

        #region ToJson_Bool

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ToJsonBool_Null_ThrowsException (bool indent)
        {
            DataContractClass original = null;

            _ = Assert.Throws<ArgumentNullException>(
                () => JsonExtensions.ToJson(original, indent));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ToJsonBool_NonDataContract_ThrowsException (bool indent)
        {
            var name = "name";
            NonDataContractClass original = new NonDataContractClass(name);

            _ = Assert.Throws<InvalidDataContractException>(
                () => JsonExtensions.ToJson(original, indent));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ToJsonBool_StringTrue_ReturnsDeserializableString (
            bool indent)
        {
            string original = "name";

            string serialized = original.ToJson(indent);
            string deserialized = serialized.FromJson<string>();

            Assert.Equal(original, deserialized);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ToJsonBool_DataContract_ReturnsDeserializableString (
            bool indent)
        {
            string name = "name";
            DataContractClass original = new DataContractClass(name);

            string serialized = original.ToJson(indent);
            DataContractClass deserialized =
                serialized.FromJson<DataContractClass>();

            Assert.Equal(original, deserialized);
        }

        [Theory]
        [InlineData(' ')]
        [InlineData('\n')]
        public void
            ToJsonBool_DataContractTrue_ContainsWhitespace (
            char whitespace)
        {
            bool indent = true;
            string name = "name";
            DataContractClass original = new DataContractClass(name);

            string serialized = original.ToJson(indent);

            Assert.Contains(whitespace, serialized);
        }

        [Theory]
        [InlineData(' ')]
        [InlineData('\n')]
        public void 
            ToJsonBool_DataContractFalse_DoesNotContainUselessWhitespace (
            char whitespace)
        {
            bool indent = false;
            string name = "name";
            DataContractClass original = new DataContractClass(name);

            string serialized = original.ToJson(indent);

            Assert.DoesNotContain(whitespace, serialized);
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