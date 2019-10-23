using jktoiuhito.Utility.Extensions.String;
using System;
using Xunit;

#pragma warning disable IDE0007 // Use implicit type
namespace jktoiuhito.Utility.UnitTests.Extensions.String
{
    //DONE 2019-10-05
    public sealed class StringUnitTests
    {
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
        public void NotNullEmptyWhitespace_EmptyLocalName_ThrowsException ()
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

        [Fact]
        public void NotNullEmptyWhitespace_String_Passes ()
        {
            string input = "input";

            string output = input.NotNullEmptyWhitespace();

            Assert.Equal(input, output);
        }

        [Fact]
        public void NotNullEmptyWhitespace_NullLocalName_Passes ()
        {
            string input = "input";
            string localName = null;

            string output = input.NotNullEmptyWhitespace(localName);

            Assert.Equal(input, output);
        }
    }
}
#pragma warning restore IDE0007
