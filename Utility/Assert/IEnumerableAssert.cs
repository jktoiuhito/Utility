using System.Collections.Generic;
using System;

//EDITED 2020-10-09
namespace jktoiuhito.Utility.Assert
{
    /// <summary>
    /// Assertation extensions related to <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class IEnumerableAssert
    {
        /// <summary>
        ///     Returns the input <see cref="IEnumerable{T}"/> if it is not
        ///     empty. Otherwise throws <see cref="ArgumentException"/>.
        /// </summary>
        /// <typeparam name="T">
        ///     Type stored in the <see cref="IEnumerable{T}"/>.
        /// </typeparam>
        /// <param name="enumerable">
        ///     <see cref="IEnumerable{T}"/> to check for emptiness.
        /// </param>
        /// <param name="localName">
        ///     Name of the <see cref="IEnumerable{T}"/>s local variable,
        ///     parameter etc.
        /// </param>
        /// <returns>
        ///     The input <see cref="IEnumerable{T}"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="enumerable"/> is empty.
        /// </exception>
        public static IEnumerable<T> NotEmpty<T> (
            this IEnumerable<T> enumerable, string? localName = null)
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
            throw new ArgumentException("IEnumerable cannot be empty");
        }

        /// <summary>
        ///     Return the input <see cref="IEnumerable{T}"/> if it is not
        ///     empty and does not contain any null values. Otherwise throws an
        ///     <see cref="ArgumentException"/>.
        /// </summary>
        /// <typeparam name="T">
        ///     Type stored in the <see cref="IEnumerable{T}"/>.
        /// </typeparam>
        /// <param name="enumerable">
        ///     <see cref="IEnumerable{T}"/> to check for emptiness and
        ///     contained null values.
        /// </param>
        /// <param name="localName">
        ///     Name of the <see cref="IEnumerable{T}"/>s local variable,
        ///     parameter etc.
        /// </param>
        /// <returns>
        ///     The input <see cref="IEnumerable{T}"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="enumerable"/> is empty or
        ///     contains null values.
        /// </exception>
        public static IEnumerable<T> NotEmptyNulls<T> (
            this IEnumerable<T> enumerable, string? localName = null) 
            where T : class
        {
            const string NullsErrorMessage =
                        "IEnumerable cannot contain null values";
            foreach (var value in enumerable.NotEmpty(localName))
                if (value == null)
                    throw localName == null
                     ? new ArgumentException(NullsErrorMessage)
                     : new ArgumentException(NullsErrorMessage, localName);
            return enumerable;
        }
    }
}
