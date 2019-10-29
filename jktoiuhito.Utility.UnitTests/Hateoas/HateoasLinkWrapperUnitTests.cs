using jktoiuhito.Utility.Hateoas;
using System.Collections.Generic;
using System;
using Xunit;

#pragma warning disable IDE0007 // Use implicit type
namespace jktoiuhito.Utility.UnitTests.Hateoas
{
    //DONE 2019-10-29
    public sealed class HateoasLinkWrapperUnitTests
    {
        #region Constructor

        [Fact]
        public void HateoasLinkWrapper_NullContent_ThrowsException ()
        {
            string content = null;
            IEnumerable<HateoasLink> links =
                new[]
                {
                    new HateoasLink("https://www.example.com/", "rel")
                };
            _ = Assert.Throws<ArgumentNullException>(
                () => new HateoasLinkWrapper(content, links));
        }

        [Fact]
        public void HateoasLinkWrapper_ClassContent_SetsContent ()
        {
            string content = "string";
            IEnumerable<HateoasLink> links =
                new[]
                {
                    new HateoasLink("https://www.example.com/", "rel")
                };

            var wrapped = new HateoasLinkWrapper(content, links);

            Assert.Equal(content, wrapped.Content);
        }

        [Fact]
        public void HateoasLinkWrapper_StructContent_SetsContent ()
        {
            DateTime content = DateTime.Now;
            IEnumerable<HateoasLink> links =
                new[]
                {
                    new HateoasLink("https://www.example.com/", "rel")
                };

            var wrapped = new HateoasLinkWrapper(content, links);

            Assert.Equal(content, wrapped.Content);
        }

        [Fact]
        public void HateoasLinkWrapper_NullLinks_ThrowsException ()
        {
            string content = "string";
            IEnumerable<HateoasLink> links = null;
            _ = Assert.Throws<ArgumentNullException>(
                () => new HateoasLinkWrapper(content, links));
        }

        [Fact]
        public void HateoasLinkWrapper_EmptyLinks_ThrowsException ()
        {
            string content = "string";
            IEnumerable<HateoasLink> links = new HateoasLink[] { };

            _ = Assert.Throws<ArgumentException>(
                () => new HateoasLinkWrapper(content, links));
        }

        [Fact]
        public void HateoasLinkWrapper_LinksContainingNulls_ThrowsException ()
        {
            string content = "string";
            IEnumerable<HateoasLink> links = new HateoasLink[]
            {
                new HateoasLink("https://www.example.com/", "rel"),
                null
            };

            _ = Assert.Throws<ArgumentException>(
                () => new HateoasLinkWrapper(content, links));
        }

        [Fact]
        public void HateoasLinkWrapper_Links_SetsLinks ()
        {
            string content = "string";
            IEnumerable<HateoasLink> links =
                new[]
                {
                    new HateoasLink("https://www.example.com/", "rel")
                };

            var wrapped = new HateoasLinkWrapper(content, links);

            Assert.Equal(links, wrapped.Links);
        }

        #endregion

        //TODO: test that serialized form is correct?
    }
}
#pragma warning restore IDE0007