using jktoiuhito.Utility.Hateoas;
using System.Collections.Generic;
using jktoiuhito.Utility.Json;
using System;
using Xunit;

#pragma warning disable IDE0007 // Use implicit type
namespace jktoiuhito.Utility.UnitTests.Hateoas
{
    //EDITED 2019-11-17
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

            var wrapper = new HateoasLinkWrapper(content, links);

            Assert.Equal(content, wrapper.Content);
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

            var wrapper = new HateoasLinkWrapper(content, links);

            Assert.Equal(links, wrapper.Links);
        }

        #endregion

        #region JSON Serialized form

        [Theory]
        [InlineData("cont1", "https://www.example.com", "rel1", "content")]
        [InlineData("cont1", "https://www.example.com", "rel1", "cont1")]
        [InlineData
            ("cont1",
            "https://www.example.com",
            "rel1",
            "https:\\/\\/www.example.com")]
        [InlineData("cont1", "https://www.example.com", "rel1", "rel1")]
        public void HateoasLinkWrapper_SerializedJson_ContainsNecessaryData (
            string content, string uri, string rel, string contains)
        {
            IEnumerable<HateoasLink> links =
                new[]
                {
                    new HateoasLink(uri, rel)
                };
            var wrapper = new HateoasLinkWrapper(content, links);

            var serialized = wrapper.ToJson();

            Assert.Contains(contains, serialized);
        }

        #endregion
    }
}
#pragma warning restore IDE0007