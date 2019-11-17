using jktoiuhito.Utility.String;
using System;
using Xunit;

#pragma warning disable IDE0007 // Use implicit type
namespace jktoiuhito.Utility.UnitTests.String
{
    //EDITED 2019-11-17
    public sealed class StringUnitTests
    {
        #region NotNullEmptyWhitespace (string)

        [Fact]
        public void NotNullEmptyWhitespace_Null_ThrowsException ()
        {
            string input = null;

            _ = Assert.Throws<ArgumentNullException>(
                () => input.NotNullEmptyWhitespace());
        }

        [Fact]
        public void NotNullEmptyWhitespace_Empty_ThrowsException ()
        {
            string input = "";

            _ = Assert.Throws<ArgumentException>(
                () => input.NotNullEmptyWhitespace());
        }

        [Fact]
        public void NotNullEmptyWhitespace_Whitespace_ThrowsException ()
        {
            string input = "    ";

            _ = Assert.Throws<ArgumentException>(
                () => input.NotNullEmptyWhitespace());
        }

        [Fact]
        public void NotNullEmptyWhitespace_String_Passes ()
        {
            string input = "input";

            string output = input.NotNullEmptyWhitespace();

            Assert.Equal(input, output);
        }

        #endregion

        #region NotNullEmptyWhitespace (string, string)

        [Fact]
        public void NotNullEmptyWhitespace_NullLocalName_Passes ()
        {
            string input = "input";
            string localName = null;

            string output = input.NotNullEmptyWhitespace(localName);

            Assert.Equal(input, output);
        }

        [Fact]
        public void NotNullEmptyWhitespace_EmptyWhitesLocalName_ThrowsException ()
        {
            string input = "input";
            string localName = "";

            _ = Assert.Throws<ArgumentException>(
                () => input.NotNullEmptyWhitespace(localName));
        }

        [Fact]
        public void
            NotNullEmptyWhitespace_WhitespaceLocalName_ThrowsException ()
        {
            string input = "input";
            string localName = "    ";

            _ = Assert.Throws<ArgumentException>(
                () => input.NotNullEmptyWhitespace(localName));
        }

        #endregion
    }
}
#pragma warning restore IDE0007
