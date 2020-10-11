using System;

// EDITED 2020-10-09
namespace jktoiuhito.Utility.Assert
{
    /// <summary>
    /// Assertation extension related to <see cref="object"/>.
    /// </summary>
    public static class ObjectAssert
    {
        //TODO: test ObjectAsserter

        /// <summary>
        /// Returns the input <see cref="object"/> if it is not null.
        /// Otherwise throws <see cref="ArgumentNullException"/>.
        /// </summary>
        /// <typeparam name="T">Type of the <see cref="object"/>.</typeparam>
        /// <param name="value">
        ///     The <see cref="object"/> to perform non-nullness assertation
        ///     on.
        /// </param>
        /// <param name="name">
        ///     Name of the <see cref="object"/>s local variable, parameter
        ///     etc.
        /// </param>
        /// <returns>The input <see cref="object"/>.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="value"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="name"/> is empty or whitespace.
        /// </exception>
        public static T IsNotNull<T>(this T? value, string? name = null)
           where T : class => value ?? throw new ArgumentNullException();

        /// <summary>
        /// Returns the input <see cref="object"/> if it is not null.
        /// Otherwise throws <see cref="ArgumentNullException"/>.
        /// </summary>
        /// <typeparam name="T">Type of the <see cref="object"/>.</typeparam>
        /// <param name="value">
        ///     The <see cref="object"/> to perform non-nullness assertation
        ///     on.
        /// </param>
        /// <param name="name">
        ///     Name of the <see cref="object"/>s local variable, parameter
        ///     etc.
        /// </param>
        /// <returns>The input <see cref="object"/>.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="value"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="name"/> is empty or whitespace.
        /// </exception>
        public static T IsNotNull<T>(this T? value, string? name = null)
           where T : struct => value ?? throw new ArgumentNullException();
    }
}
