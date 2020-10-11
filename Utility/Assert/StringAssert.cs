using System;

//EDITED 2020-10-09
namespace jktoiuhito.Utility.Assert
{
    /// <summary>
    /// Assertation extensions related to <see cref="string"/>s.
    /// </summary>
    public static class StringAssert
    {
        /// <summary>
        ///     Returns the input <see cref="string"/> if it is not empty and
        ///     does not consist only of whitespace. Otherwise throws an
        ///     <see cref="ArgumentException"/>.
        /// </summary>
        /// <param name="input">
        ///     <see cref="string"/> to test for emptyness and whitespaceness.
        /// </param>
        /// <param name="localName">
        ///     Name of the <see cref="string"/> variable in the local context.
        /// </param>
        /// <returns>The input <see cref="string"/>.</returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="input"/> is empty or whitespace.
        ///     <paramref name="localName"/> is empty or whitespace.
        /// </exception>
        public static string NotEmptyWhitespace (
            this string input, string? localName = null)
        {
            const string ExceptionMessage =
                "String cannot be empty or whitespace";
            return localName != null && string.IsNullOrWhiteSpace(localName)
                ? throw new ArgumentException(
                    ExceptionMessage, nameof(localName))
                : string.IsNullOrWhiteSpace(input)
                ? throw (localName == null
                    ? new ArgumentException(
                        ExceptionMessage)
                    : new ArgumentException(
                        ExceptionMessage, localName))
                : input;
        }
    }
}
