using System.Collections.Generic;
using jktoiuhito.Utility.Assert;
using NUnit.Framework;
using System;

#pragma warning disable IDE0007 // Use implicit type
namespace jktoiuhito.Utility.UnitTests.IEnumerable
{
    //EDITED 2020-10-11
    /// <summary>
    /// Tests for <see cref="IEnumerableAssert"/>.
    /// </summary>
    public class IEnumerableAssertUnitTests
    {
        public static readonly string?[] localNames = new[] { null, "name" };

        /// <summary>
        /// Tests for
        /// <see cref="IEnumerableAssert.NotEmpty{T}(IEnumerable{T}, string?)"/>
        /// </summary>
        public class NotEmpty
        {
            [Theory]
            public void Empty_ThrowsException(string localName)
            {
                IEnumerable<int> ienumerable = new int[] { };

                _ = NUnit.Framework.Assert.Throws<ArgumentException>(
                    () => ienumerable.NotEmpty(localName));
            }

            [Theory]
            public void NotEmptyContainsNulls_ReturnsInput(string localName)
            {
                IEnumerable<int?> ienumerable = new int?[] { null };

                var output = ienumerable.NotEmpty(localName);

                NUnit.Framework.Assert.AreEqual(ienumerable, output);
            }

            [Theory]
            public void NotEmpty_ReturnsInput(string localName)
            {
                IEnumerable<int> ienumerable = new[] { 0 };

                var output = ienumerable.NotEmpty(localName);

                NUnit.Framework.Assert.AreEqual(ienumerable, output);
            }

            /*
             * Null and not-empty-whitespace localNames have already been
             * tested above.
             */

            [Test]
            public void EmptyLocalName_ThrowsException()
            {
                IEnumerable<int> ienumerable = new[] { 0 };
                string localName = "";

                _ = NUnit.Framework.Assert.Throws<ArgumentException>(
                    () => ienumerable.NotEmpty(localName));
            }

            [Test]
            public void
                WhitespaceLocalName_ThrowsException()
            {
                IEnumerable<int> ienumerable = new[] { 0 };
                string localName = "    ";

                _ = NUnit.Framework.Assert.Throws<ArgumentException>(
                    () => ienumerable.NotEmpty(localName));
            }

            // TODO: testaa että nimi trimmataan poikkeusviestissä

            [Theory]
            [InlineData("  name")]
            [InlineData("name  ")]
            [InlineData("  name  ")]
            public void
                LocalName_IsTrimmed(string localName)
            {
                IEnumerable<int> ienumerable = new[] { 0 };

                _ = NUnit.Framework.Assert.Throws<ArgumentException>(
                    () => ienumerable.NotEmpty(localName));
            }
        }

        /// <summary>
        /// Tests for
        /// <see cref="IEnumerableAssert.NotEmptyNulls{T}(IEnumerable{T}, string?)"/>
        /// </summary>
        public class NotEmptyNulls
        {
            public class EmptyValue
            {
                [Theory]
                public void ThrowsException(string localName)
                {
                    IEnumerable<string> ienumerable = new string[] { };

                    _ = NUnit.Framework.Assert.Throws<ArgumentException>(
                        () => ienumerable.NotEmptyNulls(localName));
                }
            }

            public class NullContainingValue
            {
                [Theory]
                public void ThrowsException(string localName)
                {
                    IEnumerable<string?> ienumerable = new string?[] { null };

                    _ = NUnit.Framework.Assert.Throws<ArgumentException>(
                        () => ienumerable.NotEmptyNulls(localName));
                }
            }

            public class NullessValue
            {
                [Theory]
                public void ReturnsInput(string localName)
                {
                    IEnumerable<string> ienumerable = new[] { "" };

                    var output = ienumerable.NotEmptyNulls(localName);

                    NUnit.Framework.Assert.AreEqual(ienumerable, output);
                }

                public class EmptyLocalname
                {
                    [Test]
                    public void ThrowsException()
                    {
                        IEnumerable<string> ienumerable = new[] { "" };
                        string localName = "";

                        _ = NUnit.Framework.Assert.Throws<ArgumentException>(
                            () => ienumerable.NotEmptyNulls(localName));
                    }
                }

                public class WhitespaceLocalname
                {
                    public static readonly string?[] localNames = 
                        new[] { " ", "　", "	", "\n", "\nr" };

                    [Theory]
                    public void ThrowsException(string localName)
                    {
                        IEnumerable<string> ienumerable = new[] { "" };

                        _ = NUnit.Framework.Assert.Throws<ArgumentException>(
                            () => ienumerable.NotEmptyNulls(localName));
                    }
                }
            }
        }
    }
}
#pragma warning restore IDE0007 // Use implicit type