using jktoiuhito.Utility.Hateoas;
using jktoiuhito.Utility.Json;
using System;
using Xunit;

#pragma warning disable IDE0007 // Use implicit type
namespace jktoiuhito.Utility.UnitTests.Hateoas
{
    //EDITED 2019-11-17
    public sealed class HateoasLinkUnitTests
    {
        #region HateoasLink (String, String)

        [Fact]
        public void HateoasLink_NullStringHref_ThrowsException ()
        {
            string href = null;
            string rel = "rel";

            _ = Assert.Throws<ArgumentNullException>(
                () => new HateoasLink(href, rel));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("not-an-uri")]
        public void HateoasLink_NonUriStringHref_ThrowsException (string href)
        {
            string rel = "rel";

            _ = Assert.Throws<UriFormatException>(
                () => new HateoasLink(href, rel));
        }

        [Fact]
        public void HateoasLink_StringHref_NullRel_ThrowsException ()
        {
            string href = "https://www.example.com/";
            string rel = null;

            _ = Assert.Throws<ArgumentNullException>(
                () => new HateoasLink(href, rel));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void HateoasLink_StringHref_EmptyWHitespaceRel_ThrowsException (
            string rel)
        {
            string href = "https://www.example.com/";

            _ = Assert.Throws<ArgumentException>(
                () => new HateoasLink(href, rel));
        }

        [Fact]
        public void HateoasLink_StringHref_HrefAcceptsString ()
        {
            string href = new Uri("https://www.example.com/").AbsoluteUri;
            string rel = "rel";

            var link = new HateoasLink(href, rel);

            Assert.Equal(href, link.Href.AbsoluteUri);
        }

        [Fact]
        public void HateoasLink_StringHref_RelAcceptsString ()
        {
            string href = "https://www.example.com/";
            string rel = "rel";

            var link = new HateoasLink(href, rel);

            Assert.Equal(rel, link.Rel);
        }

        #endregion

        #region HateoasLink (Uri, String)

        [Fact]
        public void HateoasLink_NullUriref_ThrowsException ()
        {
            Uri href = null;
            string rel = "rel";

            _ = Assert.Throws<ArgumentNullException>(
                () => new HateoasLink(href, rel));
        }

        [Fact]
        public void HateoasLink_UriHref_NullRel_ThrowsException ()
        {
            Uri href = new Uri("https://www.example.com/");
            string rel = null;

            _ = Assert.Throws<ArgumentNullException>(
                () => new HateoasLink(href, rel));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void HateoasLink_UriHref_EmptyWHitespaceRel_ThrowsException (
            string rel)
        {
            Uri href = new Uri("https://www.example.com/");

            _ = Assert.Throws<ArgumentException>(
                () => new HateoasLink(href, rel));
        }

        [Fact]
        public void HateoasLink_UriHref_HrefAcceptsUri ()
        {
            Uri href = new Uri("https://www.example.com/");
            string rel = "rel";

            var link = new HateoasLink(href, rel);

            Assert.Equal(href, link.Href);
        }

        [Fact]
        public void HateoasLink_UriHref_RelAcceptsString ()
        {
            Uri href = new Uri("https://www.example.com/");
            string rel = "rel";

            var link = new HateoasLink(href, rel);

            Assert.Equal(rel, link.Rel);
        }

        #endregion

        #region HateoasLink.Self (String)

        [Fact]
        public void HateoasLink_StringSelf_NullHref_ThrowsException ()
        {
            string href = null;

            _ = Assert.Throws<ArgumentNullException>(
                () => HateoasLink.Self(href));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("not-an-uri")]
        public void HateoasLink_StringSelf_NonUriHref_ThrowsException (
            string href)
        {
            _ = Assert.Throws<UriFormatException>(
                () => HateoasLink.Self(href));
        }

        [Fact]
        public void HateoasLink_StringSelf_SetsHref ()
        {
            string href = "https://www.example.com/";

            var link = HateoasLink.Self(href);

            Assert.Equal(href, link.Href.AbsoluteUri);
        }

        [Fact]
        public void HateoasLink_StringSelf_RelIsSelf ()
        {
            string href = "https://www.example.com/";
            const string self = "self";

            var link = HateoasLink.Self(href);

            Assert.Equal(self, link.Rel);
        }

        #endregion

        #region HateoasLink.Self (Uri)

        [Fact]
        public void HateoasLink_UriSelf_NullHref_ThrowsException ()
        {
            Uri href = null;

            _ = Assert.Throws<ArgumentNullException>(
                () => HateoasLink.Self(href));
        }

        [Fact]
        public void HateoasLink_UriSelf_SetsHref ()
        {
            Uri href = new Uri("https://www.example.com/");

            var link = HateoasLink.Self(href);

            Assert.Equal(href, link.Href);
        }

        [Fact]
        public void HateoasLink_UriSelf_RelIsSelf ()
        {
            Uri href = new Uri("https://www.example.com/");
            const string self = "self";

            var link = HateoasLink.Self(href);

            Assert.Equal(self, link.Rel);
        }

        #endregion

        #region Serialized forms

        [Theory]
        [InlineData("https://www.example.com", "rlvncy", "href")]
        [InlineData("https://www.example.com", "rlvncy", "rel")]
        [InlineData(
            "https://www.example.com", "rlvncy", "https:\\/\\/www.example.com")]
        [InlineData("https://www.example.com", "rlvncy", "rlvncy")]
        public void HateoasLink_SerializedJson_ContainsNecessaryData (
            string href, string rel, string contains)
        {
            var link = new HateoasLink(href, rel);

            var serialized = link.ToJson();

            Assert.Contains(contains, serialized);
        }

        [Theory]
        [InlineData("https://www.example.com", "href")]
        [InlineData("https://www.example.com", "rel")]
        [InlineData("https://www.example.com", "https:\\/\\/www.example.com")]
        [InlineData("https://www.example.com", "self")]
        public void HateoasLink_Self_SerializedJson_ContainsNecessaryData (
            string href, string contains)
        {
            var link = HateoasLink.Self(href);

            var serialized = link.ToJson();

            Assert.Contains(contains, serialized);
        }

        #endregion
    }
}
#pragma warning restore IDE0007
