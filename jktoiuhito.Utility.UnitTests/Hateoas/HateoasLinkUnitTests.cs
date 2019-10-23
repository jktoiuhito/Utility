using jktoiuhito.Utility.Hateoas;
using System;
using Xunit;

#pragma warning disable IDE0007 // Use implicit type
namespace jktoiuhito.Utility.UnitTests.Hateoas
{
    //DONE 2019-10-05
    public sealed class HateoasLinkUnitTests
    {
        #region Constructors

        [Fact]
        public void HateoasLink_NullStringHref_ThrowsException ()
        {
            string href = null;
            string rel = "rel";

            _ = Assert.Throws<ArgumentNullException>(
                () => new HateoasLink(href, rel));
        }

        [Fact]
        public void HateoasLink_EmptyStringHref_ThrowsException ()
        {
            string href = "";
            string rel = "rel";

            _ = Assert.Throws<UriFormatException>(
                () => new HateoasLink(href, rel));
        }

        [Fact]
        public void HateoasLink_WhitespaceStringHref_ThrowsException ()
        {
            string href = "     ";
            string rel = "rel";

            _ = Assert.Throws<UriFormatException>(
                () => new HateoasLink(href, rel));
        }

        [Fact]
        public void HateoasLink_NonUriStringHref_ThrowsException ()
        {
            string href = "not-an-uri";
            string rel = "rel";

            _ = Assert.Throws<UriFormatException>(
                () => new HateoasLink(href, rel));
        }

        [Fact]
        public void HateoasLink_NullUriHref_ThrowsException ()
        {
            Uri href = null;
            string rel = "rel";

            _ = Assert.Throws<ArgumentNullException>(
                () => new HateoasLink(href, rel));
        }

        [Fact]
        public void HateoasLink_NullRel_ThrowsException ()
        {
            Uri href = new Uri("https://www.example.com/");
            string rel = null;

            _ = Assert.Throws<ArgumentNullException>(
                () => new HateoasLink(href, rel));
        }

        [Fact]
        public void HateoasLink_EmptyRel_ThrowsException ()
        {
            Uri href = new Uri("https://www.example.com/");
            string rel = "";

            _ = Assert.Throws<ArgumentException>(
                () => new HateoasLink(href, rel));
        }

        [Fact]
        public void HateoasLink_WhitespaceRel_ThrowsException ()
        {
            Uri href = new Uri("https://www.example.com/");
            string rel = "";

            _ = Assert.Throws<ArgumentException>(
                () => new HateoasLink(href, rel));
        }

        [Fact]
        public void HateoasLink_StringHref_AcceptsString ()
        {
            string href = new Uri("https://www.example.com/").AbsoluteUri;
            string rel = "rel";

            var link = new HateoasLink(href, rel);

            Assert.Equal(href, link.Href.AbsoluteUri);
        }

        [Fact]
        public void HateoasLink_UriHref_AcceptsUri ()
        {
            Uri href = new Uri("https://www.example.com/");
            string rel = "rel";

            var link = new HateoasLink(href, rel);

            Assert.Equal(href, link.Href);
        }

        [Fact]
        public void HateoasLink_Rel_AcceptsString ()
        {
            Uri href = new Uri("https://www.example.com/");
            string rel = "rel";

            var link = new HateoasLink(href, rel);

            Assert.Equal(rel, link.Rel);
        }

        #endregion

        #region Self

        [Fact]
        public void HateoasLink_Self_NullUri_ThrowsException ()
        {
            Uri href = null;

            _ = Assert.Throws<ArgumentNullException>(
                () => HateoasLink.Self(href));
        }

        [Fact]
        public void HateoasLink_Self_NullString_ThrowsException ()
        {
            string href = null;

            _ = Assert.Throws<ArgumentNullException>(
                () => HateoasLink.Self(href));
        }

        [Fact]
        public void HateoasLink_Self_EmptyString_ThrowsException ()
        {
            string href = "";

            _ = Assert.Throws<UriFormatException>(
                () => HateoasLink.Self(href));
        }

        [Fact]
        public void HateoasLink_Self_WhitespaceString_ThrowsException ()
        {
            string href = "    ";

            _ = Assert.Throws<UriFormatException>(
                () => HateoasLink.Self(href));
        }

        [Fact]
        public void HateoasLink_Self_UriHref_SetsUri ()
        {
            Uri href = new Uri("https://www.example.com/");

            var link = HateoasLink.Self(href);

            Assert.Equal(href, link.Href);
        }

        [Fact]
        public void HateoasLink_Self_UriHref_RelIsSelf ()
        {
            Uri href = new Uri("https://www.example.com/");
            const string self = "self";

            var link = HateoasLink.Self(href);

            Assert.Equal(self, link.Rel);
        }

        [Fact]
        public void HateoasLink_Self_StringHref_SetsUri ()
        {
            string href = new Uri("https://www.example.com/").AbsoluteUri;

            var link = HateoasLink.Self(href);

            Assert.Equal(href, link.Href.AbsoluteUri);
        }

        [Fact]
        public void HateoasLink_Self_StringHref_RelIsSelf ()
        {
            string href = new Uri("https://www.example.com/").AbsoluteUri;
            const string self = "self";

            var link = HateoasLink.Self(href);

            Assert.Equal(self, link.Rel);
        }

        #endregion
    }
}
#pragma warning restore IDE0007
