using jktoiuhito.Utility.Hateoas;
using System.Collections.Generic;
using jktoiuhito.Utility.Json;
using System;
using Xunit;

namespace jktoiuhito.Utility.UnitTests.Hateoas
{
    //EDITED 2019-11-17
    public sealed class HateoasResponseUnitTests
    {
        #region Constructor

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

        #endregion

        #region JSON serialized form

        [Theory]
        [InlineData("https://www.example.com", "rel1", "links")]
        [InlineData(
            "https://www.example.com", "rel1", "https:\\/\\/www.example.com")]
        [InlineData("https://www.example.com", "rel1", "rel1")]
        public void HateoasResponse_SerializedJson_ContainsNecessaryData (
            string uri, string rel, string contains)
        {
            IEnumerable<HateoasLink> links = new[]
            {
                new HateoasLink(new Uri(uri), rel)
            };
            var response = new HateoasResponse(links);

            var serialized = response.ToJson();

            Assert.Contains(contains, serialized);
        }

        #endregion
    }
}
