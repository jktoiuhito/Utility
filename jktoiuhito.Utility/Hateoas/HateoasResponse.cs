using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System;

namespace jktoiuhito.Utility.Hateoas
{
    /// <summary>
    /// Base class for a response which contains <see cref="HateoasLink"/>s.
    /// </summary>
    [DataContract]
    public class HateoasResponse
    {
        /// <summary>
        /// Name of <see cref="Links"/> when serialized
        /// by <see cref="DataContractSerializer"/>.
        /// </summary>
        public const string LinksSerializedName = "links";

        const string EmptyExceptionMessage = "cannot be empty";
        const string NullsExceptionMessage = "cannot contain nulls";

        /// <summary>
        /// <see cref="HateoasLink"/>s contained in the response.
        /// Is never null or empty.
        /// </summary>
        [DataMember(Name = LinksSerializedName, IsRequired = true)]
        public IEnumerable<HateoasLink> Links { get; private set; }

        /// <param name="links">
        ///     <see cref="HateoasLink"/>s contained in the response.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="links"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="links"/> is empty or contains nulls.
        /// </exception>
        public HateoasResponse (IEnumerable<HateoasLink> links)
        {
            if (links == null)
                throw new ArgumentNullException(nameof(links));
            if (links.Count() <= 0)
                throw new ArgumentException(
                    EmptyExceptionMessage, nameof(links));
            if (links.Where(l => l == null).Count() > 0)
                throw new ArgumentException(
                    NullsExceptionMessage, nameof(links));
            Links = links;
        }
    }
}
