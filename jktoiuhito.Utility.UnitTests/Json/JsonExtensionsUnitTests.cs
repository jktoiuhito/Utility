using System.Runtime.Serialization;
using System.Collections.Generic;
using jktoiuhito.Utility.Json;
using System.Text;
using System.IO;
using System;
using Xunit;

#pragma warning disable IDE0007 // Use implicit type
namespace jktoiuhito.Utility.UnitTests.Json
{
    //EDITED 2019-12-06
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

        #region ToJson (bool)

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

        #region ToJson (IEnumerable<Type>)

        [Fact]
        public void ToJsonEnum_NullObject_ThrowsException ()
        {
            DataContractClass original = null;
            IEnumerable<Type> types = new[]
            {
                typeof(string)
            };

            _ = Assert.Throws<ArgumentNullException>(
                () => JsonExtensions.ToJson(original, types));
        }

        [Fact]
        public void ToJsonEnum_NonDataContract_ThrowsException ()
        {
            NonDataContractClass original = new NonDataContractClass("name");
            IEnumerable<Type> types = new[]
            {
                typeof(string)
            };

            _ = Assert.Throws<InvalidDataContractException>(
                () => JsonExtensions.ToJson(original, types));
        }

        [Fact]
        public void ToJsonEnum_String_ReturnsDeserializableString ()
        {
            string original = "name";
            IEnumerable<Type> types = new[]
            {
                typeof(string)
            };

            string serialized = original.ToJson(types);
            string deserialized = serialized.FromJson<string>();

            Assert.Equal(original, deserialized);
        }

        [Fact]
        public void ToJsonEnum_NullTypes_ThrowsException ()
        {
            DataContractClass original = new DataContractClass("name");
            IEnumerable<Type> types = null;

            _ = Assert.Throws<ArgumentNullException>(
                () => JsonExtensions.ToJson(original, types));
        }

        [Fact]
        public void ToJsonEnum_EmptyTypes_ThrowsException ()
        {
            DataContractClass original = new DataContractClass("name");
            IEnumerable<Type> types = new Type[] { };

            _ = Assert.Throws<ArgumentException>(
                () => JsonExtensions.ToJson(original, types));
        }

        [Fact]
        public void ToJsonEnum_Types_NullValues_ThrowsException ()
        {
            DataContractClass original = new DataContractClass("name");
            IEnumerable<Type> types = new[]
            {
                typeof(string),
                null
            };

            _ = Assert.Throws<ArgumentException>(
                () => JsonExtensions.ToJson(original, types));
        }

        [Fact]
        public void ToJsonEnum_DataContract_ReturnsDeserializableString ()
        {
            DataContractClass original = new DataContractClass("name");
            IEnumerable<Type> types = new[]
            {
                typeof(string)
            };

            string serialized = original.ToJson(types);
            DataContractClass deserialized =
                serialized.FromJson<DataContractClass>();

            Assert.Equal(original, deserialized);
        }

        [Theory]
        [InlineData(' ')]
        [InlineData('\n')]
        public void ToJsonEnum_DataContract_DoesNotContainUselessWhitespace (
            char whitespace)
        {
            string name = "name";
            DataContractClass original = new DataContractClass(name);
            IEnumerable<Type> types = new[]
            {
                typeof(string)
            };

            string serialized = original.ToJson(types);

            Assert.DoesNotContain(whitespace, serialized);
        }

        #endregion

        #region ToJson (bool, IEnumerable<Type>)

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ToJsonBoolEnum_NullObject_ThrowsException (bool indent)
        {
            DataContractClass original = null;
            IEnumerable<Type> types = new[]
            {
                typeof(string)
            };

            _ = Assert.Throws<ArgumentNullException>(
                () => JsonExtensions.ToJson(original, indent, types));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ToJsonBoolEnum_NonDataContract_ThrowsException (
            bool indent)
        {
            NonDataContractClass original = new NonDataContractClass("name");
            IEnumerable<Type> types = new[]
            {
                typeof(string)
            };

            _ = Assert.Throws<InvalidDataContractException>(
                () => JsonExtensions.ToJson(original, indent, types));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ToJsonBoolEnum_String_ReturnsDeserializableString (
            bool indent)
        {
            string original = "name";
            IEnumerable<Type> types = new[]
            {
                typeof(string)
            };

            string serialized = original.ToJson(indent, types);
            string deserialized = serialized.FromJson<string>();

            Assert.Equal(original, deserialized);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ToJsonBoolEnum_NullTypes_ThrowsException (bool indent)
        {
            DataContractClass original = new DataContractClass("name"); ;
            IEnumerable<Type> types = null;

            _ = Assert.Throws<ArgumentNullException>(
                () => JsonExtensions.ToJson(original, indent, types));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ToJsonBoolEnum_EmptyTypes_ThrowsException (bool indent)
        {
            DataContractClass original = new DataContractClass("name");
            IEnumerable<Type> types = new Type[] { };

            _ = Assert.Throws<ArgumentException>(
                () => JsonExtensions.ToJson(original, indent, types));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ToJsonBoolEnum_Types_NullValues_ThrowsException (
            bool indent)
        {
            DataContractClass original = new DataContractClass("name"); ;
            IEnumerable<Type> types = new[]
            {
                typeof(string),
                null
            };

            _ = Assert.Throws<ArgumentException>(
                () => JsonExtensions.ToJson(original, indent, types));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ToJsonBoolEnum_DataContract_ReturnsDeserializableString (
            bool indent)
        {
            DataContractClass original = new DataContractClass("name");
            IEnumerable<Type> types = new[]
            {
                typeof(string)
            };

            string serialized = original.ToJson(indent, types);
            DataContractClass deserialized =
                serialized.FromJson<DataContractClass>();

            Assert.Equal(original, deserialized);
        }

        //indent

        [Theory]
        [InlineData(' ')]
        [InlineData('\n')]
        public void 
            ToJsonEnum_FalseDataContract_DoesNotContainUselessWhitespace (
            char whitespace)
        {
            DataContractClass original = new DataContractClass("name");
            IEnumerable<Type> types = new[]
            {
                typeof(string)
            };

            string serialized = original.ToJson(false, types);

            Assert.DoesNotContain(whitespace, serialized);
        }


        [Theory]
        [InlineData(' ')]
        [InlineData('\n')]
        public void ToJsonEnum_TrueDataContract_ContainWhitespace (
            char whitespace)
        {
            DataContractClass original = new DataContractClass("name");
            IEnumerable<Type> types = new[]
            {
                typeof(string)
            };

            string serialized = original.ToJson(true, types);

            Assert.Contains(whitespace, serialized);
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