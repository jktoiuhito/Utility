using jktoiuhito.Utility.IEnumerable;
using System.Collections.Generic;
using System;
using Xunit;

#pragma warning disable IDE0007 // Use implicit type
namespace jktoiuhito.Utility.UnitTests.IEnumerable
{
    //EDITED 2019-11-17
    public class IEnumerableExtensionsUnitTests
    {
        #region NotNullEmpty (IEnumerable)

        [Fact]
        public void IENumerable_NotNullEmpty_Null_ThrowsException ()
        {
            IEnumerable<int> ienumerable = null;

            _ = Assert.Throws<ArgumentNullException>(
                () => ienumerable.NotNullEmpty());
        }

        [Fact]
        public void IENumerable_NotNullEmpty_Empty_ThrowsException ()
        {
            IEnumerable<int> ienumerable = new int[] { };

            _ = Assert.Throws<ArgumentException>(
                () => ienumerable.NotNullEmpty());
        }

        [Fact]
        public void IENumerable_NotNullEmpty_FilledNulls_ReturnsInput ()
        {
            IEnumerable<int?> ienumerable = new int?[] { null };

            var output = ienumerable.NotNullEmpty();

            Assert.Equal(ienumerable, output);
        }

        [Fact]
        public void IENumerable_NotNullEmpty_Filled_ReturnsInput ()
        {
            IEnumerable<int> ienumerable = new[] { 0 };

            var output = ienumerable.NotNullEmpty();

            Assert.Equal(ienumerable, output);
        }

        #endregion

        #region NotNullEmpty (IEnumerable, string)

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
    }
}
#pragma warning restore IDE0007 // Use implicit type