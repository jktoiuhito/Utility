using jktoiuhito.Utility.String;
using System;

/*
 * This file was automatically generated 2020/09/01 12:19:26 UTC time.
 * All manual changes will be lost.
 */

namespace jktoiuhito.Utility.Numbers
{
    /// <summary>
    /// Extension methods related to numbers.
    /// </summary>
    public static class Numbers
    {
            /// <summary>
        /// Returns the input <see cref="sbyte"/> if it is not zero.
        /// Otherwise throws an exception.
        /// </summary>
        /// <param name="number">Input <see cref="sbyte"/>.</param>
        /// <param name="localname">Name of the variable in local context.</param>
        /// <returns>Input <see cref="sbyte"/></returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="number"/> is zero.
        ///     <paramref name="localname"/> is empty or whitespace.
        /// </exception>
        public static sbyte NotZero (this sbyte number, string localname = null)
        {
            if (localname != null)
                localname = localname.NotNullEmptyWhitespace(nameof(localname));
            if (number == 0)
                throw localname == null
                    ? new ArgumentException("number cannot be zero")
                    : new ArgumentException("number cannot be zero", localname);
            return number;
        }
            /// <summary>
        /// Returns the input <see cref="short"/> if it is not zero.
        /// Otherwise throws an exception.
        /// </summary>
        /// <param name="number">Input <see cref="short"/>.</param>
        /// <param name="localname">Name of the variable in local context.</param>
        /// <returns>Input <see cref="short"/></returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="number"/> is zero.
        ///     <paramref name="localname"/> is empty or whitespace.
        /// </exception>
        public static short NotZero (this short number, string localname = null)
        {
            if (localname != null)
                localname = localname.NotNullEmptyWhitespace(nameof(localname));
            if (number == 0)
                throw localname == null
                    ? new ArgumentException("number cannot be zero")
                    : new ArgumentException("number cannot be zero", localname);
            return number;
        }
            /// <summary>
        /// Returns the input <see cref="int"/> if it is not zero.
        /// Otherwise throws an exception.
        /// </summary>
        /// <param name="number">Input <see cref="int"/>.</param>
        /// <param name="localname">Name of the variable in local context.</param>
        /// <returns>Input <see cref="int"/></returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="number"/> is zero.
        ///     <paramref name="localname"/> is empty or whitespace.
        /// </exception>
        public static int NotZero (this int number, string localname = null)
        {
            if (localname != null)
                localname = localname.NotNullEmptyWhitespace(nameof(localname));
            if (number == 0)
                throw localname == null
                    ? new ArgumentException("number cannot be zero")
                    : new ArgumentException("number cannot be zero", localname);
            return number;
        }
            /// <summary>
        /// Returns the input <see cref="long"/> if it is not zero.
        /// Otherwise throws an exception.
        /// </summary>
        /// <param name="number">Input <see cref="long"/>.</param>
        /// <param name="localname">Name of the variable in local context.</param>
        /// <returns>Input <see cref="long"/></returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="number"/> is zero.
        ///     <paramref name="localname"/> is empty or whitespace.
        /// </exception>
        public static long NotZero (this long number, string localname = null)
        {
            if (localname != null)
                localname = localname.NotNullEmptyWhitespace(nameof(localname));
            if (number == 0)
                throw localname == null
                    ? new ArgumentException("number cannot be zero")
                    : new ArgumentException("number cannot be zero", localname);
            return number;
        }
                /// <summary>
        /// Returns the input <see cref="byte"/> if it is not zero.
        /// Otherwise throws an exception.
        /// </summary>
        /// <param name="number">Input <see cref="byte"/>.</param>
        /// <param name="localname">Name of the variable in local context.</param>
        /// <returns>Input <see cref="byte"/></returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="number"/> is zero.
        ///     <paramref name="localname"/> is empty or whitespace.
        /// </exception>
        public static byte NotZero (this byte number, string localname = null)
        {
            if (localname != null)
                localname = localname.NotNullEmptyWhitespace(nameof(localname));
            if (number == 0)
                throw localname == null
                    ? new ArgumentException("number cannot be zero")
                    : new ArgumentException("number cannot be zero", localname);
            return number;
        }
            /// <summary>
        /// Returns the input <see cref="ushort"/> if it is not zero.
        /// Otherwise throws an exception.
        /// </summary>
        /// <param name="number">Input <see cref="ushort"/>.</param>
        /// <param name="localname">Name of the variable in local context.</param>
        /// <returns>Input <see cref="ushort"/></returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="number"/> is zero.
        ///     <paramref name="localname"/> is empty or whitespace.
        /// </exception>
        public static ushort NotZero (this ushort number, string localname = null)
        {
            if (localname != null)
                localname = localname.NotNullEmptyWhitespace(nameof(localname));
            if (number == 0)
                throw localname == null
                    ? new ArgumentException("number cannot be zero")
                    : new ArgumentException("number cannot be zero", localname);
            return number;
        }
            /// <summary>
        /// Returns the input <see cref="uint"/> if it is not zero.
        /// Otherwise throws an exception.
        /// </summary>
        /// <param name="number">Input <see cref="uint"/>.</param>
        /// <param name="localname">Name of the variable in local context.</param>
        /// <returns>Input <see cref="uint"/></returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="number"/> is zero.
        ///     <paramref name="localname"/> is empty or whitespace.
        /// </exception>
        public static uint NotZero (this uint number, string localname = null)
        {
            if (localname != null)
                localname = localname.NotNullEmptyWhitespace(nameof(localname));
            if (number == 0)
                throw localname == null
                    ? new ArgumentException("number cannot be zero")
                    : new ArgumentException("number cannot be zero", localname);
            return number;
        }
            /// <summary>
        /// Returns the input <see cref="ulong"/> if it is not zero.
        /// Otherwise throws an exception.
        /// </summary>
        /// <param name="number">Input <see cref="ulong"/>.</param>
        /// <param name="localname">Name of the variable in local context.</param>
        /// <returns>Input <see cref="ulong"/></returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="number"/> is zero.
        ///     <paramref name="localname"/> is empty or whitespace.
        /// </exception>
        public static ulong NotZero (this ulong number, string localname = null)
        {
            if (localname != null)
                localname = localname.NotNullEmptyWhitespace(nameof(localname));
            if (number == 0)
                throw localname == null
                    ? new ArgumentException("number cannot be zero")
                    : new ArgumentException("number cannot be zero", localname);
            return number;
        }
        }
}