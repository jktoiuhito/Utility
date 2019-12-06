using System.Runtime.Serialization.Json;
using jktoiuhito.Utility.IEnumerable;
using System.Runtime.Serialization;
using System.Collections.Generic;
using jktoiuhito.Utility.String;
using System.IO;
using System;

//EDITED 2019-12-06
namespace jktoiuhito.Utility.Json
{
    /// <summary>
    ///     Extensions for easy JSON (de)serialization using
    ///     <see cref="DataContractJsonSerializer"/>.
    /// </summary>
    public static class JsonExtensions
    {
        const string EmptyStreamErrorMessage = "stream cannot be empty";
        const string KnownTypesNullsErrorMessage = 
            "known types cannot contain nulls";

        /// <summary>
        ///     Convert an <see cref="object"/> to a Json 
        ///     formatted <see cref="string"/>.
        /// </summary>
        /// <typeparam name="T">
        ///     Type of the <see cref="object"/>.
        /// </typeparam>
        /// <param name="object">
        ///     <see cref="object"/> to convert to Json.
        /// </param>
        /// <returns>
        ///     <see cref="object"/> serialized to Json.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="object"/> is null.
        /// </exception>
        /// <exception cref="InvalidDataContractException">
        ///     <paramref name="object"/> has an invalid data contract.
        /// </exception>
        /// <exception cref="OutOfMemoryException">
        ///     //TODO: when is this thrown?
        /// </exception>
        public static string ToJson<T> (this T @object) where T : class
        {
            if (@object == null)
                throw new ArgumentNullException();

            return ToJsonImpl<T>(@object, null, null);
        }

        /// <summary>
        ///     Convert an <see cref="object"/> to a Json 
        ///     formatted <see cref="string"/>.
        /// </summary>
        /// <typeparam name="T">
        ///     Type of the <see cref="object"/>.
        /// </typeparam>
        /// <param name="object">
        ///     <see cref="object"/> to convert to Json.
        /// </param>
        /// <param name="indent">
        ///     Should the output string be indented.
        /// </param>
        /// <returns>
        ///     <see cref="object"/> serialized to Json.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="object"/> is null.
        /// </exception>
        /// <exception cref="InvalidDataContractException">
        ///     <paramref name="object"/> has an invalid data contract.
        /// </exception>
        /// <exception cref="OutOfMemoryException">
        ///     //TODO: when is this thrown?
        /// </exception>
        public static string ToJson<T> (this T @object, bool indent) 
            where T : class
        {
            if (@object == null)
                throw new ArgumentNullException();

            return ToJsonImpl<T>(
                @object, indent, null);
        }

        /// <summary>
        ///     Convert an <see cref="object"/> to a Json 
        ///     formatted <see cref="string"/>.
        /// </summary>
        /// <typeparam name="T">
        ///     Type of the <see cref="object"/>.
        /// </typeparam>
        /// <param name="object">
        ///     <see cref="object"/> to convert to Json.
        /// </param>
        /// <param name="knownTypes">
        ///     Types which should be known to the
        ///     <see cref="DataContractJsonSerializer"/>.
        /// </param>
        /// <returns>
        ///     <see cref="object"/> serialized to Json.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="object"/> is null.
        ///     <paramref name="knownTypes"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="knownTypes"/> is empty or contains nulls.
        /// </exception>
        /// <exception cref="InvalidDataContractException">
        ///     <paramref name="object"/> has an invalid data contract.
        /// </exception>
        /// <exception cref="OutOfMemoryException">
        ///     //TODO: when is this thrown?
        /// </exception>
        public static string ToJson<T> (
            this T @object, IEnumerable<Type> knownTypes) where T : class
        {
            if (@object == null)
                throw new ArgumentNullException();

            return ToJsonImpl<T>(
                @object,
                null,
                knownTypes.NotNullEmptyNulls(nameof(knownTypes)));
        }

        /// <summary>
        ///     Convert an <see cref="object"/> to a Json 
        ///     formatted <see cref="string"/>.
        /// </summary>
        /// <typeparam name="T">
        ///     Type of the <see cref="object"/>.
        /// </typeparam>
        /// <param name="object">
        ///     <see cref="object"/> to convert to Json.
        /// </param>
        /// <param name="indent">
        ///     Should the output string be indented.
        /// </param>
        /// <param name="knownTypes">
        ///     Types which should be known to the
        ///     <see cref="DataContractJsonSerializer"/>.
        /// </param>
        /// <returns>
        ///     <see cref="object"/> serialized to Json.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="object"/> is null.
        ///     <paramref name="knownTypes"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="knownTypes"/> is empty or contains nulls.
        /// </exception>
        /// <exception cref="InvalidDataContractException">
        ///     <paramref name="object"/> has an invalid data contract.
        /// </exception>
        /// <exception cref="OutOfMemoryException">
        ///     //TODO: when is this thrown?
        /// </exception>
        public static string ToJson<T> (
            this T @object, bool indent, IEnumerable<Type> knownTypes)
            where T : class
        {
            if (@object == null)
                throw new ArgumentNullException();
            foreach (var type in knownTypes.NotNullEmpty())
                if (type == null)
                    throw new ArgumentException(KnownTypesNullsErrorMessage);

            return ToJsonImpl<T>(@object, indent, knownTypes);
        }

        /// <summary>
        ///     Deserialize an <see cref="object"/> from a
        ///     Json <see cref="string"/>.
        /// </summary>
        /// <typeparam name="T">
        ///     Type of the object to be deserialized.
        /// </typeparam>
        /// <param name="string">
        ///     String from which the object is deserialized.
        /// </param>
        /// <returns>
        ///     The deserialized object.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="string"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="string"/> is empty or whitespace.
        /// </exception>
        /// <exception cref="SerializationException">
        ///     <paramref name="string"/> cannot be deserialized
        ///     into the given type.
        /// </exception>
        public static T FromJson<T> (this string @string) where T : class
        {
            var bytes = 
                System.Text.Encoding.UTF8.GetBytes(
                    @string.NotNullEmptyWhitespace());
            var stream = new MemoryStream(bytes);
            return FromJson<T>(stream);
        }

        /// <summary>
        ///     Deserialize an <see cref="object"/> from a
        ///     Json <see cref="Stream"/>.
        /// </summary>
        /// <typeparam name="T">
        ///     Type of the object to be deserialized.
        /// </typeparam>
        /// <param name="stream">
        ///     Stream to deserialize the object from.
        /// </param>
        /// <returns>
        ///     The deserialized object.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="stream"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="stream"/> is empty.
        /// </exception>
        /// <exception cref="SerializationException">
        ///     <paramref name="stream"/> cannot be deserialized
        ///     into the given type.
        /// </exception>
        public static T FromJson<T> (this Stream stream) where T : class
        {
            if (stream == null)
                throw new ArgumentNullException();
            if (stream.Length <= 0)
                throw new ArgumentException(EmptyStreamErrorMessage);

            _ = stream.Seek(0, SeekOrigin.Begin);
            var serializer = new DataContractJsonSerializer(typeof(T));
            return (T)serializer.ReadObject(stream);
        }

        static string ToJsonImpl<T> (
            T obj, bool? indent, IEnumerable<Type> knownTypes)
        {
            var serializer = knownTypes == null
                ? new DataContractJsonSerializer(typeof(T))
                : new DataContractJsonSerializer(typeof(T), knownTypes);
            using (var stream = new MemoryStream())
            {
                if (indent == null)
                {
                    serializer.WriteObject(stream, obj);
                }
                else
                {
                    var encoding = System.Text.Encoding.UTF8;
                    var writer =
                        JsonReaderWriterFactory
                        .CreateJsonWriter(
                            stream, encoding, true, indent.Value);
                    serializer.WriteObject(writer, obj);
                    writer.Flush();
                }
                _ = stream.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(stream))
                    return reader.ReadToEnd();
            }
        }
    }
}
