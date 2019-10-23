using jktoiuhito.Utility.Extensions.String;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using System;

namespace jktoiuhito.Utility.Extensions.Json
{
    public static class JsonExtensions
    {
        const string EmptyStream = "stream cannot be empty";

        /// <summary>
        /// Convert an <see cref="object"/> to a Json 
        /// formatted <see cref="string"/>.
        /// </summary>
        /// <typeparam name="T">Type of the <see cref="object"/>.</typeparam>
        /// <param name="object"></param>
        /// <returns><see cref="object"/> serialized to Json.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="object"/> is null.
        /// </exception>
        /// <exception cref="InvalidDataContractException"></exception>
        /// <exception cref="OutOfMemoryException"></exception>
        public static string ToJson<T> (this T @object) where T : class
        {
            if (@object == null)
                throw new ArgumentNullException();

            using (var stream = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                serializer.WriteObject(stream, @object);
                _ = stream.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(stream))
                    return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Deserialize an object from a JSON formatted string.
        /// </summary>
        /// <typeparam name="T">
        ///     Type of the object to be deserialized.
        /// </typeparam>
        /// <param name="string">
        ///     String from which the object is deserialized.
        /// </param>
        /// <returns>The deserialized object.</returns>
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
        /// Deserialize an object from a JSON-stream.
        /// </summary>
        /// <typeparam name="T">
        ///     Type of the object to be deserialized.
        /// </typeparam>
        /// <param name="stream">Stream to deserialize the object from.</param>
        /// <returns>The deserialized object.</returns>
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
                throw new ArgumentException(EmptyStream);

            _ = stream.Seek(0, SeekOrigin.Begin);
            var serializer = new DataContractJsonSerializer(typeof(T));
            return (T)serializer.ReadObject(stream);
        }
    }
}
