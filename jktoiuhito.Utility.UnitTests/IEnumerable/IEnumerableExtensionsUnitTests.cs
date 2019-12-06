using jktoiuhito.Utility.IEnumerable;
using System.Collections.Generic;
using System;
using Xunit;

#pragma warning disable IDE0007 // Use implicit type
namespace jktoiuhito.Utility.UnitTests.IEnumerable
{
    //EDITED 2019-12-06
    public class IEnumerableExtensionsUnitTests
    {
        #region NotNullEmpty (IEnumerable<T>, string)

        [Theory]
        [InlineData(null)]
        [InlineData("local")]
        public void IENumerable_NotNullEmpty_Null_ThrowsException (
            string localName)
        {
            IEnumerable<int> ienumerable = null;

            _ = Assert.Throws<ArgumentNullException>(
                () => ienumerable.NotNullEmpty(localName));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("local")]
        public void IENumerable_NotNullEmpty_Empty_ThrowsException (
            string localName)
        {
            IEnumerable<int> ienumerable = new int[] { };

            _ = Assert.Throws<ArgumentException>(
                () => ienumerable.NotNullEmpty(localName));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("local")]
        public void IENumerable_NotNullEmpty_FilledNulls_ReturnsInput (
            string localName)
        {
            IEnumerable<int?> ienumerable = new int?[] { null };

            var output = ienumerable.NotNullEmpty(localName);

            Assert.Equal(ienumerable, output);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("local")]
        public void IENumerable_NotNullEmpty_Filled_ReturnsInput (
            string localName)
        {
            IEnumerable<int> ienumerable = new[] { 0 };

            var output = ienumerable.NotNullEmpty(localName);

            Assert.Equal(ienumerable, output);
        }

        [Fact]
        public void NotNullEmptyWhitespace_NullLocalName_Passes ()
        {
            IEnumerable<int> ienumerable = new[] { 0 };
            string localName = null;

            var output = ienumerable.NotNullEmpty(localName);

            Assert.Equal(ienumerable, output);
        }

        [Fact]
        public void NotNullEmptyWhitespace_EmptyLocalName_ThrowsException ()
        {
            IEnumerable<int> ienumerable = new[] { 0 };
            string localName = "";

            _ = Assert.Throws<ArgumentException>(
                () => ienumerable.NotNullEmpty(localName));
        }

        [Fact]
        public void
            NotNullEmptyWhitespace_WhitespaceLocalName_ThrowsException ()
        {
            IEnumerable<int> ienumerable = new[] { 0 };
            string localName = "    ";

            _ = Assert.Throws<ArgumentException>(
                () => ienumerable.NotNullEmpty(localName));
        }

        #endregion

        #region NotNullEmptyNulls (IEnumerable<T>, string)

        [Theory]
        [InlineData(null)]
        [InlineData("local")]
        public void IENumerable_NotNullEmptyNulls_Null_ThrowsException (
            string localName)
        {
            IEnumerable<string> ienumerable = null;

            _ = Assert.Throws<ArgumentNullException>(
                () => ienumerable.NotNullEmptyNulls(localName));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("local")]
        public void IENumerable_NotNullEmptyNulls_Empty_ThrowsException (
            string localName)
        {
            IEnumerable<string> ienumerable = new string[] { };

            _ = Assert.Throws<ArgumentException>(
                () => ienumerable.NotNullEmptyNulls(localName));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("local")]
        public void IENumerable_NotNullEmptyNulls_NullValues_ThrowsException (
            string localName)
        {
            IEnumerable<string> ienumerable = new string[] { null };

            _ = Assert.Throws<ArgumentException>(
                () => ienumerable.NotNullEmptyNulls(localName));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("local")]
        public void IENumerable_NotNullEmptyNulls_Filled_ReturnsInput (
            string localName)
        {
            IEnumerable<string> ienumerable = new[] { "" };

            var output = ienumerable.NotNullEmptyNulls(localName);

            Assert.Equal(ienumerable, output);
        }

        [Fact]
        public void NotNullEmptyNullsWhitespace_NullLocalName_Passes ()
        {
            IEnumerable<string> ienumerable = new[] { "" };
            string localName = null;

            var output = ienumerable.NotNullEmptyNulls(localName);

            Assert.Equal(ienumerable, output);
        }

        [Fact]
        public void NotNullEmptyNullsWhitespace_EmptyLocalName_ThrowsException ()
        {
            IEnumerable<string> ienumerable = new[] { "" };
            string localName = "";

            _ = Assert.Throws<ArgumentException>(
                () => ienumerable.NotNullEmptyNulls(localName));
        }

        [Fact]
        public void
            NotNullEmptyNullsWhitespace_WhitespaceLocalName_ThrowsException ()
        {
            IEnumerable<string> ienumerable = new[] { "" };
            string localName = "    ";

            _ = Assert.Throws<ArgumentException>(
                () => ienumerable.NotNullEmptyNulls(localName));
        }

        #endregion
    }
}
#pragma warning restore IDE0007 // Use implicit type