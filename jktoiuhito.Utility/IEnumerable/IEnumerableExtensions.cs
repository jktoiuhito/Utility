using System.Collections.Generic;
using System;

//EDITED 2019-12-06
namespace jktoiuhito.Utility.IEnumerable
{
    /// <summary>
    /// Extensions related to <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class IEnumerableExtensions
    {
        const string EmptyErrorMessage = 
            "IEnumerable cannot be empty";
        const string NullsErrorMessage =
            "IEnumerable cannot contain null values";

        /// <summary>
        ///     Return the input <see cref="IEnumerable{T}"/> if it is
        ///     not null and not empty. Otherwise throws an exception.
        /// </summary>
        /// <typeparam name="T">
        ///     Type stored in the <see cref="IEnumerable{T}"/>.
        /// </typeparam>
        /// <param name="enumerable">
        ///     <see cref="IEnumerable{T}"/> to check for
        ///     nullness and emptiness.
        /// </param>
        /// <param name="localName">
        ///     Name of the variable in local context.
        /// </param>
        /// <returns>
        ///     The input <see cref="IEnumerable{T}"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="enumerable"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="enumerable"/> is empty.
        /// </exception>
        public static IEnumerable<T> NotNullEmpty<T> (
            this IEnumerable<T> enumerable, string localName = null)
        {
            if (localName != null && string.IsNullOrWhiteSpace(localName))
                throw new ArgumentException();
            if (enumerable == null) throw localName == null
                    ? new ArgumentNullException()
                    : new ArgumentNullException(localName);
            var counter = 0;
            foreach (var obj in enumerable)
            {
                counter += 1;
                if (counter > 0)
                    return enumerable;
            }
            throw new ArgumentException(EmptyErrorMessage);
        }

        /// <summary>
        ///     Return the input <see cref="IEnumerable{T}"/> if it is
        ///     not null, not empty and does not contain any null values.
        ///     Otherwise throws an exception.
        /// </summary>
        /// <typeparam name="T">
        ///     Type stored in the <see cref="IEnumerable{T}"/>.
        /// </typeparam>
        /// <param name="enumerable">
        ///     <see cref="IEnumerable{T}"/> to check for
        ///     nullness, emptiness and null values.
        /// </param>
        /// <param name="localName">
        ///     Name of the variable in local context.
        /// </param>
        /// <returns>
        ///     The input <see cref="IEnumerable{T}"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="enumerable"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="enumerable"/> is empty or
        ///     contains null values.
        /// </exception>
        public static IEnumerable<T> NotNullEmptyNulls<T> (
            this IEnumerable<T> enumerable, string localName = null) 
            where T : class
        {
            foreach (var value in enumerable.NotNullEmpty(localName))
                if (value == null)
                    throw localName == null
                     ? new ArgumentException(NullsErrorMessage)
                     : new ArgumentException(NullsErrorMessage, localName);
            return enumerable;
        }
    }
}
