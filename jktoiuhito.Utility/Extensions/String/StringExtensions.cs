using System.Threading.Tasks;
using System;

namespace jktoiuhito.Utility.Extensions.String
{
    /// <summary>
    /// Extensions related to <see cref="string"/>s.
    /// </summary>
    public static class StringExtensions
    {
        const string ExceptionMessage = "cannot be empty or whitespace";

        /// <summary>
        /// Check that a <see cref="string"/> is not null, empty or
        /// consists only of whitespace.
        /// </summary>
        /// <param name="input"><see cref="string"/> to test.</param>
        /// <param name="localName">
        ///     Name of the <see cref="string"/> variable in the local context.
        /// </param>
        /// <returns>The input <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="input"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="input"/> is empty or whitespace.
        ///     <paramref name="localName"/> is empty or whitespace.
        /// </exception>
        public static string NotNullEmptyWhitespace (
            this string input, string localName = null)
        {
            if (localName != null && string.IsNullOrWhiteSpace(localName))
                throw new ArgumentException(
                    ExceptionMessage, nameof(localName));
            if (input == null)
                throw localName == null
                    ? new ArgumentNullException()
                    : new ArgumentNullException(localName);
            if (string.IsNullOrWhiteSpace(input))
                throw localName == null
                    ? new ArgumentException(
                        ExceptionMessage)
                    : new ArgumentException(
                        ExceptionMessage, localName);
            return input;
        }
    }
}
