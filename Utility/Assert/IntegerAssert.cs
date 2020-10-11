using jktoiuhito.Utility.Assert;
using System;

/*
 * This file was automatically generated 2020/10/11 07:52:10 UTC time.
 * All manual changes will be lost.
 */

namespace jktoiuhito.Utility.Assert
{
    /// <summary>
    /// Assertion extension methods related to integers.
    /// </summary>
    public static class IntegerAssert
    {
            /// <summary>
        /// Returns the input <see cref="sbyte"/> if it is not zero.
        /// Otherwise throws an <see cref="ArgumentException"/>.
        /// </summary>
        /// <param name="number">
        ///     Input <see cref="sbyte"/> to check for zeroness.
        /// </param>
        /// <param name="localname">
        ///     Name of the <see cref="sbyte"/>s local variable,
        ///     parameter etc.
        /// </param>
        /// <returns>Thei input <see cref="sbyte"/></returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="number"/> is zero.
        ///     <paramref name="localname"/> is empty or whitespace.
        /// </exception>
        public static sbyte NotZero (this sbyte number, string? localname = null)
        {
            if (localname != null)
                localname = localname.NotEmptyWhitespace(nameof(localname));
            if (number == 0)
                throw localname == null
                    ? new ArgumentException("number cannot be zero")
                    : new ArgumentException("number cannot be zero", localname);
            return number;
        }
            /// <summary>
        /// Returns the input <see cref="short"/> if it is not zero.
        /// Otherwise throws an <see cref="ArgumentException"/>.
        /// </summary>
        /// <param name="number">
        ///     Input <see cref="short"/> to check for zeroness.
        /// </param>
        /// <param name="localname">
        ///     Name of the <see cref="short"/>s local variable,
        ///     parameter etc.
        /// </param>
        /// <returns>Thei input <see cref="short"/></returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="number"/> is zero.
        ///     <paramref name="localname"/> is empty or whitespace.
        /// </exception>
        public static short NotZero (this short number, string? localname = null)
        {
            if (localname != null)
                localname = localname.NotEmptyWhitespace(nameof(localname));
            if (number == 0)
                throw localname == null
                    ? new ArgumentException("number cannot be zero")
                    : new ArgumentException("number cannot be zero", localname);
            return number;
        }
            /// <summary>
        /// Returns the input <see cref="int"/> if it is not zero.
        /// Otherwise throws an <see cref="ArgumentException"/>.
        /// </summary>
        /// <param name="number">
        ///     Input <see cref="int"/> to check for zeroness.
        /// </param>
        /// <param name="localname">
        ///     Name of the <see cref="int"/>s local variable,
        ///     parameter etc.
        /// </param>
        /// <returns>Thei input <see cref="int"/></returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="number"/> is zero.
        ///     <paramref name="localname"/> is empty or whitespace.
        /// </exception>
        public static int NotZero (this int number, string? localname = null)
        {
            if (localname != null)
                localname = localname.NotEmptyWhitespace(nameof(localname));
            if (number == 0)
                throw localname == null
                    ? new ArgumentException("number cannot be zero")
                    : new ArgumentException("number cannot be zero", localname);
            return number;
        }
            /// <summary>
        /// Returns the input <see cref="long"/> if it is not zero.
        /// Otherwise throws an <see cref="ArgumentException"/>.
        /// </summary>
        /// <param name="number">
        ///     Input <see cref="long"/> to check for zeroness.
        /// </param>
        /// <param name="localname">
        ///     Name of the <see cref="long"/>s local variable,
        ///     parameter etc.
        /// </param>
        /// <returns>Thei input <see cref="long"/></returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="number"/> is zero.
        ///     <paramref name="localname"/> is empty or whitespace.
        /// </exception>
        public static long NotZero (this long number, string? localname = null)
        {
            if (localname != null)
                localname = localname.NotEmptyWhitespace(nameof(localname));
            if (number == 0)
                throw localname == null
                    ? new ArgumentException("number cannot be zero")
                    : new ArgumentException("number cannot be zero", localname);
            return number;
        }
                /// <summary>
        /// Returns the input <see cref="byte"/> if it is not zero.
        /// Otherwise throws an <see cref="ArgumentException"/>.
        /// </summary>
        /// <param name="number">
        ///     Input <see cref="byte"/> to check for zeroness.
        /// </param>
        /// <param name="localname">
        ///     Name of the <see cref="byte"/>s local variable,
        ///     parameter etc.
        /// </param>
        /// <returns>The input <see cref="byte"/></returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="number"/> is zero.
        ///     <paramref name="localname"/> is empty or whitespace.
        /// </exception>
        public static byte NotZero (this byte number, string? localname = null)
        {
            if (localname != null)
                localname = localname.NotEmptyWhitespace(nameof(localname));
            if (number == 0)
                throw localname == null
                    ? new ArgumentException("number cannot be zero")
                    : new ArgumentException("number cannot be zero", localname);
            return number;
        }
            /// <summary>
        /// Returns the input <see cref="ushort"/> if it is not zero.
        /// Otherwise throws an <see cref="ArgumentException"/>.
        /// </summary>
        /// <param name="number">
        ///     Input <see cref="ushort"/> to check for zeroness.
        /// </param>
        /// <param name="localname">
        ///     Name of the <see cref="ushort"/>s local variable,
        ///     parameter etc.
        /// </param>
        /// <returns>The input <see cref="ushort"/></returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="number"/> is zero.
        ///     <paramref name="localname"/> is empty or whitespace.
        /// </exception>
        public static ushort NotZero (this ushort number, string? localname = null)
        {
            if (localname != null)
                localname = localname.NotEmptyWhitespace(nameof(localname));
            if (number == 0)
                throw localname == null
                    ? new ArgumentException("number cannot be zero")
                    : new ArgumentException("number cannot be zero", localname);
            return number;
        }
            /// <summary>
        /// Returns the input <see cref="uint"/> if it is not zero.
        /// Otherwise throws an <see cref="ArgumentException"/>.
        /// </summary>
        /// <param name="number">
        ///     Input <see cref="uint"/> to check for zeroness.
        /// </param>
        /// <param name="localname">
        ///     Name of the <see cref="uint"/>s local variable,
        ///     parameter etc.
        /// </param>
        /// <returns>The input <see cref="uint"/></returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="number"/> is zero.
        ///     <paramref name="localname"/> is empty or whitespace.
        /// </exception>
        public static uint NotZero (this uint number, string? localname = null)
        {
            if (localname != null)
                localname = localname.NotEmptyWhitespace(nameof(localname));
            if (number == 0)
                throw localname == null
                    ? new ArgumentException("number cannot be zero")
                    : new ArgumentException("number cannot be zero", localname);
            return number;
        }
            /// <summary>
        /// Returns the input <see cref="ulong"/> if it is not zero.
        /// Otherwise throws an <see cref="ArgumentException"/>.
        /// </summary>
        /// <param name="number">
        ///     Input <see cref="ulong"/> to check for zeroness.
        /// </param>
        /// <param name="localname">
        ///     Name of the <see cref="ulong"/>s local variable,
        ///     parameter etc.
        /// </param>
        /// <returns>The input <see cref="ulong"/></returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="number"/> is zero.
        ///     <paramref name="localname"/> is empty or whitespace.
        /// </exception>
        public static ulong NotZero (this ulong number, string? localname = null)
        {
            if (localname != null)
                localname = localname.NotEmptyWhitespace(nameof(localname));
            if (number == 0)
                throw localname == null
                    ? new ArgumentException("number cannot be zero")
                    : new ArgumentException("number cannot be zero", localname);
            return number;
        }
        }
}