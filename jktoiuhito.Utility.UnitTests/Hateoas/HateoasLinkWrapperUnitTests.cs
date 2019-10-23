using jktoiuhito.Utility.Hateoas;
using System.Collections.Generic;
using System;
using Xunit;

#pragma warning disable IDE0007 // Use implicit type
namespace jktoiuhito.Utility.UnitTests.Hateoas
{
    //DONE 2019-10-07
    public sealed class HateoasLinkWrapperUnitTests
    {
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
                () => new HateoasLinkWrapper<string>(content, links));
        }

        [Fact]
        public void HateoasLinkWrapper_NullLinks_ThrowsException ()
        {
            string content = "string";
            IEnumerable<HateoasLink> links = null;
            _ = Assert.Throws<ArgumentNullException>(
                () => new HateoasLinkWrapper<string>(content, links));
        }

        [Fact]
        public void HateoasLinkWrapper_Content_SetsContent ()
        {
            string content = "string";
            IEnumerable<HateoasLink> links =
                new[]
                {
                    new HateoasLink("https://www.example.com/", "rel")
                };

            var wrapped = new HateoasLinkWrapper<string>(content, links);

            Assert.Equal(content, wrapped.Content);
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

            var wrapped = new HateoasLinkWrapper<string>(content, links);

            Assert.Equal(links, wrapped.Links);
        }
    }
}
#pragma warning restore IDE0007