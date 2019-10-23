using jktoiuhito.Utility.Hateoas;
using System.Collections.Generic;
using System;
using Xunit;

namespace jktoiuhito.Utility.UnitTests.Hateoas
{
    //DONE 2019-10-05
    public sealed class HateoasResponseUnitTests
    {
        [Fact]
        public void HateoasResponse_Null_ThrowsException ()
        {
            IEnumerable<HateoasLink> links = null;

            _ = Assert.Throws<ArgumentNullException>(
                () => new HateoasResponse(links));
        }

        [Fact]
        public void HateoasResponse_Empty_ThrowsException ()
        {
            IEnumerable<HateoasLink> links = new HateoasLink[0];

            _ = Assert.Throws<ArgumentException>(
                () => new HateoasResponse(links));
        }

        [Fact]
        public void HateoasResponse_NullLinks_ThrowsException ()
        {
            IEnumerable<HateoasLink> links = new[]
            {
                new HateoasLink(new Uri("https://www.example.com"), "rel"),
                null
            };

            _ = Assert.Throws<ArgumentException>(
                () => new HateoasResponse(links));
        }

        [Fact]
        public void HateoasResponse_Links_SetsLinks ()
        {
            IEnumerable<HateoasLink> links = new[]
            {
                new HateoasLink(new Uri("https://www.example.com"), "rel1"),
                new HateoasLink(new Uri("https://www.example.com"), "rel2")
            };

            var response = new HateoasResponse(links);

            Assert.Equal(links, response.Links);
        }
    }
}
